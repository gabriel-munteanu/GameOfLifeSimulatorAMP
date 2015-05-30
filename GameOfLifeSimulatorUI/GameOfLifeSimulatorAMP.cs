using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeSimulatorUI
{
    //wrapper class over C++ AMP implementation of Game Of Life
    class GameOfLifeSimulatorAMP : IDisposable
    {
        #region PInvokes
        [DllImport("GameOfLifeSimulator.dll")]
        static private extern IntPtr CreateGameOfLifeSimulatorAMP();

        [DllImport("GameOfLifeSimulator.dll")]
        static private extern void GOLSimAMPSetData(IntPtr classObject, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1)] bool[] data, int width, int height);

        [DllImport("GameOfLifeSimulator.dll")]
        static private extern int GOLSimAMPGetWidth(IntPtr classObject);

        [DllImport("GameOfLifeSimulator.dll")]
        static private extern int GOLSimAMPGetHeight(IntPtr classObject);

        [DllImport("GameOfLifeSimulator.dll")]
        static private extern void GOLSimAMPSimulateCycles(IntPtr classObject, int cycles);

        [DllImport("GameOfLifeSimulator.dll")]
        static private extern void GOLSimAMPDispose(IntPtr classObject);

        [DllImport("GameOfLifeSimulator.dll")]
        static private extern void GOLSimAMPSetResultLocation(IntPtr classObject, IntPtr resultPointer);

        [DllImport("GameOfLifeSimulator.dll")]
        static private extern void GOLSimAMPFilterStaticFormations(IntPtr classObject);

        [DllImport("GameOfLifeSimulator.dll")]
        static private extern void GOLSimAMPSetRules(IntPtr classObject, int born, int survive);

        #endregion

        private IntPtr _unmanagedObject;
        private int[] _result;
        GCHandle _pin;
        int _width, _height;
        long _cycles;
        string _born, _survive;

        public GameOfLifeSimulatorAMP()
        {
            _unmanagedObject = CreateGameOfLifeSimulatorAMP();
            _cycles = 0;
            _born = "3";
            _survive = "23";
        }

        ~GameOfLifeSimulatorAMP()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._unmanagedObject != IntPtr.Zero)
            {
                // Call the DLL Export to dispose this class
                GOLSimAMPDispose(this._unmanagedObject);
                this._unmanagedObject = IntPtr.Zero;
                if (_pin.IsAllocated)
                    _pin.Free();
            }

            if (disposing)
            {
                // No need to call the finalizer since we've now cleaned
                // up the unmanaged memory
                GC.SuppressFinalize(this);
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void SetData(bool[] data, int width, int height)
        {
            _width = width;
            _height = height;
            _cycles = 0;

            _result = new int[width * height];
            if (_pin.IsAllocated)
                _pin.Free();
            _pin = GCHandle.Alloc(_result, GCHandleType.Pinned);

            GOLSimAMPSetResultLocation(this._unmanagedObject, _pin.AddrOfPinnedObject());
            GOLSimAMPSetData(this._unmanagedObject, data, width, height);
        }

        public void SimulateCycles(int cycles)
        {
            GOLSimAMPSimulateCycles(this._unmanagedObject, cycles);
            _cycles += cycles;
        }

        public void FilterStaticFormations()
        {
            GOLSimAMPFilterStaticFormations(this._unmanagedObject);
        }

        public void SetRule(string born, string survive)
        {
            _born = born;
            _survive = survive;

            int iborn = 0, isurvive = 0;
            for (int i = 0; i < born.Length; i++)
            {
                iborn += 1 << (born[i] - 48 - 1);
            }
            for (int i = 0; i < survive.Length; i++)
            {
                isurvive += 1 << (survive[i] - 48 - 1);
            }
            GOLSimAMPSetRules(this._unmanagedObject, iborn, isurvive);
        }

        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
        public long Cycles { get { return _cycles; } }
        public string BornRule { get { return _born; } }
        public string SurviveRule { get { return _survive; } }

        public int[] GetResult()
        {
            return _result;
        }

    }
}
