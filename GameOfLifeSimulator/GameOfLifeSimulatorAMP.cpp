#include "GameOfLifeSimulatorAMP.h"
#include <memory.h>

GameOfLifeSimulatorAMP::GameOfLifeSimulatorAMP()
{
	this->_g_ext = NULL;
	this->_old_data = NULL;
	this->_new_data = NULL;
	this->_result = NULL;
	//default rules
	_rules = { { 0 }, { 0 } };
	_rules.born[3] = 1;
	_rules.survive[2] = 1;
	_rules.survive[3] = 1;
}

void GameOfLifeSimulatorAMP::SetData(bool *data, int width, int height)
{
	long size = width*height;

	this->_width = width;
	this->_height = height;

	if (this->_g_ext != NULL)
	{
		delete this->_g_ext;
		delete this->_old_data;
		delete this->_new_data;
	}

	this->_g_ext = new extent<2>(height, width);
	this->_old_data = new array<int, 2>(*this->_g_ext);
	this->_new_data = new array<int, 2>(*this->_g_ext);

	int *dataAsInt = TransformDataAsInt(data);
	copy(dataAsInt, *this->_new_data);
	if (this->_result != NULL)
		memcpy(this->_result, dataAsInt, size*sizeof(int));
	delete[] dataAsInt;
}

int *GameOfLifeSimulatorAMP::TransformDataAsInt(bool *data)
{
	int dataLenght = this->_width*this->_height;

	int *dataInt = new int[dataLenght];

	int *pi = dataInt;
	bool *pb = data;
	for (int i = 0; i < dataLenght; i++, pi++, pb++)
		*pi = (int)*pb;

	return dataInt;
}

void GameOfLifeSimulatorAMP::SetRules(int born, int survive)
{
	for (int i = 0; i < 8; i++)
		this->_rules.born[i + 1] = (born & (1 << i)) ? 1 : 0;
	for (int i = 0; i < 8; i++)
		this->_rules.survive[i + 1] = (survive & (1 << i)) ? 1 : 0;
}


int GameOfLifeSimulatorAMP::FixIndex(int index, int limit) restrict(amp)
{
	if (index < 0)
		return limit - 1;
	if (index == limit)
		return 0;

	return index;
}

#include <fstream>
void debug(int *data, int width, int height)
{
	std::ofstream fout = std::ofstream("dbg.txt", std::ios::out);
	for (int i = 0; i < height; i++){
		for (int j = 0; j < width; j++)
			fout << data[i*width + j] << " ";
		fout << "\n";
	}
	fout.close();

}

void GameOfLifeSimulatorAMP::SimulateCycles(int cycles)
{
	for (long i = 1; i <= cycles; i++) {
		copy(*this->_new_data, *this->_old_data);//new data is old now :D
		SimulateCycleKernel(*this->_g_ext, *this->_old_data, *this->_new_data);
	}

	copy(*this->_new_data, this->_result);
	//debug(_result, _width, _height);
}

void GameOfLifeSimulatorAMP::SimulateCycleKernel(extent<2> &g_ext, array<int, 2> &old_data, array<int, 2> &new_data)
{
	int width = this->_width,
		height = this->_height;

	GameOfLifeRules rules = this->_rules;
	parallel_for_each(g_ext, [=, &old_data, &new_data](index<2> idx) restrict(amp) { //GPU kernel
		int row = idx[0], col = idx[1];

		int me = old_data(idx),
			new_me = 0;
		int neighbours = old_data[FixIndex(row - 1, height)][FixIndex(col - 1, width)] +
			old_data[FixIndex(row - 1, height)][FixIndex(col, width)] +
			old_data[FixIndex(row - 1, height)][FixIndex(col + 1, width)] +
			old_data[FixIndex(row, height)][FixIndex(col - 1, width)] +
			old_data[FixIndex(row, height)][FixIndex(col + 1, width)] +
			old_data[FixIndex(row + 1, height)][FixIndex(col - 1, width)] +
			old_data[FixIndex(row + 1, height)][FixIndex(col, width)] +
			old_data[FixIndex(row + 1, height)][FixIndex(col + 1, width)];

		if (me == 1 && rules.survive[neighbours] == 1)
			new_me = 1;

		if (me == 0 && rules.born[neighbours] == 1)
			new_me = 1;

		new_data(idx) = new_me;
	});//end of GPU kernel	
}

void GameOfLifeSimulatorAMP::FilterStaticFormations()
{
	FilterStaticKernel(*this->_g_ext, *this->_old_data, *this->_new_data);
	copy(*this->_new_data, this->_result);
}

void GameOfLifeSimulatorAMP::FilterStaticKernel(extent<2> &g_ext, array<int, 2> &old_data, array<int, 2> &new_data)
{
	//0 = no life
	//1 = static life
	//2 = dinamic life

	int width = this->_width,
		height = this->_height;

	array<int, 2> diff_map(g_ext);

	copy(new_data, diff_map);
	//if there are cell that are changing then mark those with 2
	parallel_for_each(g_ext, [=, &old_data, &new_data, &diff_map](index<2> idx) restrict(amp) { //GPU kernel
		if (old_data(idx) != new_data(idx))
			diff_map(idx) = 2;
	});//end of GPU kernel	

	//extend cells 2 by lengh of 32
	for (int i = 0; i < 32; i++) {
		//if current position eq 1 and at least one neighbour is 2 then we set current as 2
		parallel_for_each(g_ext, [=, &diff_map](index<2> idx) restrict(amp) { //GPU kernel
			int row = idx[0], col = idx[1];
			if (diff_map(idx) != 1)
				return;
			if (diff_map[FixIndex(row - 1, height)][FixIndex(col - 1, width)] == 2 ||
				diff_map[FixIndex(row - 1, height)][FixIndex(col, width)] == 2 ||
				diff_map[FixIndex(row - 1, height)][FixIndex(col + 1, width)] == 2 ||
				diff_map[FixIndex(row, height)][FixIndex(col - 1, width)] == 2 ||
				diff_map[FixIndex(row, height)][FixIndex(col + 1, width)] == 2 ||
				diff_map[FixIndex(row + 1, height)][FixIndex(col - 1, width)] == 2 ||
				diff_map[FixIndex(row + 1, height)][FixIndex(col, width)] == 2 ||
				diff_map[FixIndex(row + 1, height)][FixIndex(col + 1, width)] == 2)
				diff_map(idx) = 2;

		});//end of GPU kernel	
	}

	//remove static formations
	parallel_for_each(g_ext, [=, &new_data, &diff_map](index<2> idx) restrict(amp) { //GPU kernel
		if (diff_map(idx) == 1)
			new_data(idx) = 0;
	});//end of GPU kernel
}

GameOfLifeSimulatorAMP::~GameOfLifeSimulatorAMP()
{

}
