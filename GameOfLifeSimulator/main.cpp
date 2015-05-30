#include <iostream>
#include <conio.h>
#include "GameOfLifeSimulatorAMP.h"

using namespace std;

void showResult(bool *data)
{
	for (int i = 0; i < 5; i++) {
		for (int j = 0; j < 5; j++)
			if (data[i * 5 + j])
				cout << (char)254;
			else
				cout << (char)176;
		cout << "\n";
	}
	cout << "\n";
}

int main()
{
	bool test[5][5] = {
		{ false, false, false, false, false },
		{ false, false, false, true, false },
		{ false, true, false, true, false },
		{ false, false, true, true, false },
		{ false, false, false, false, false } };
	showResult((bool*)test);

	GameOfLifeSimulatorAMP gol;
	gol.SetData((bool*)test, 5, 5);
	bool *result = gol.GetDataPointer();

	gol.SimulateCycles(10);

	for (int i = 0; i < 5; i++){
		gol.SimulateCycles(1);
		showResult(result);
	}

	_getch();
	return 0;
}