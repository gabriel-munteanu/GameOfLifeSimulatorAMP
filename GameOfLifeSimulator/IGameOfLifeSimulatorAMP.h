class IGameOfLifeSimulatorAMP {
public:
	virtual void SetData(bool *data, int width, int height) = 0;
	virtual int GetWidth() = 0;
	virtual int GetHeight() = 0;

	virtual bool *GetDataPointer() = 0;
	virtual void SimulateCycles(int cycles) = 0;
	virtual void Dispose() = 0;
};
