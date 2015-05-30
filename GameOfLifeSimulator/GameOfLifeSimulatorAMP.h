#pragma once
#include <amp.h>

using namespace concurrency;

#define NULL 0

struct GameOfLifeRules{
	int born[9];
	int survive[9];
};

class GameOfLifeSimulatorAMP
{

private:
	int _width, _height;
	int *_result;
	extent<2> *_g_ext;
	array<int, 2> *_old_data;
	array<int, 2> *_new_data;
	GameOfLifeRules _rules;

	int *TransformDataAsInt(bool *data);
	static int FixIndex(int index, int limit) restrict(amp);
	void SimulateCycleKernel(extent<2> &g_ext, array<int, 2> &old_data, array<int, 2> &new_data);
	void FilterStaticKernel(extent<2> &g_ext, array<int, 2> &old_data, array<int, 2> &new_data);

public:
	GameOfLifeSimulatorAMP();
	~GameOfLifeSimulatorAMP();

	void SetData(bool *data, int width, int height);
	void SetResultPointer(int *result) { this->_result = result; };
	int GetWidth() { return this->_width; };
	int GetHeight() { return this->_height; };

	void SimulateCycles(int cycles);
	void FilterStaticFormations();
	void SetRules(int, int);

};


//DLL export

extern "C" {
	__declspec(dllexport) GameOfLifeSimulatorAMP* __cdecl CreateGameOfLifeSimulatorAMP()
	{
		return new GameOfLifeSimulatorAMP;
	}

	__declspec(dllexport) void  GOLSimAMPSetData(GameOfLifeSimulatorAMP* golSimInstance, bool data[], int width, int height)
	{
		golSimInstance->SetData(data, width, height);
	}

	__declspec(dllexport) int  GOLSimAMPGetWidth(GameOfLifeSimulatorAMP* golSimInstance)
	{
		return golSimInstance->GetWidth();
	}

	__declspec(dllexport) int  GOLSimAMPGetHeight(GameOfLifeSimulatorAMP* golSimInstance)
	{
		return golSimInstance->GetWidth();
	}

	__declspec(dllexport) void GOLSimAMPSimulateCycles(GameOfLifeSimulatorAMP* golSimInstance, int cycles)
	{
		golSimInstance->SimulateCycles(cycles);
	}

	__declspec(dllexport) void  GOLSimAMPDispose(GameOfLifeSimulatorAMP* golSimInstance)
	{
		delete golSimInstance;
	}

	__declspec(dllexport) void GOLSimAMPSetResultLocation(GameOfLifeSimulatorAMP* golSimInstance, int *result)
	{
		golSimInstance->SetResultPointer(result);
	}

	__declspec(dllexport) void GOLSimAMPFilterStaticFormations(GameOfLifeSimulatorAMP* golSimInstance)
	{
		golSimInstance->FilterStaticFormations();
	}

	__declspec(dllexport) void GOLSimAMPSetRules(GameOfLifeSimulatorAMP* golSimInstance, int born, int survive)
	{
		golSimInstance->SetRules(born, survive);
	}

}


