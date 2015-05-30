using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLifeSimulatorUI
{
    public partial class MainForm : Form
    {
        GameOfLifeSimulatorAMP _gol;
        public MainForm()
        {
            InitializeComponent();
            _gol = new GameOfLifeSimulatorAMP();
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            int width, height, rarity;
            if (!int.TryParse(txt_Height.Text, out height))
                return;
            if (!int.TryParse(txt_Width.Text, out width))
                return;
            if (!int.TryParse(txt_Rarity.Text, out rarity))
                return;

            bool[] data = new bool[width * height];
            Random rnd = new Random();
            for (int i = 0; i < data.Length; i++)
                data[i] = rnd.Next(0, rarity) == 1 ? true : false;

            _gol.SetData(data, width, height);
            picturebox_Preview.Image = CreateImageFromRawData(data, height, width);
            lbl_Cycles.Text = _gol.Cycles.ToString();
        }

        Bitmap CreateImageFromRawData(bool[] data, int height, int width)
        {
            var bitmap = new Bitmap(width, height);
            for (int i = 0; i < height; ++i)
                for (int j = 0; j < width; ++j)
                    bitmap.SetPixel(j, i, data[i * width + j] ? Color.Black : Color.White);
            return bitmap;
        }

        private void btn_Simulate_Click(object sender, EventArgs e)
        {
            int cycles;
            if (!int.TryParse(txt_Cycles.Text, out cycles))
                return;

            SimulateAndUpdate(cycles);
        }


        void SimulateAndUpdate(int cycles)
        {
            _gol.SimulateCycles(cycles);
            picturebox_Preview.Image = CreateImageFromResult(_gol.GetResult(), _gol.Height, _gol.Width);
            lbl_Cycles.Text = _gol.Cycles.ToString();
        }

        Bitmap CreateImageFromResult(int[] data, int height, int width)
        {
            var bitmap = new Bitmap(width, height);
            for (int i = 0; i < height; ++i)
                for (int j = 0; j < width; ++j)
                    bitmap.SetPixel(j, i, data[i * width + j] == 1 ? Color.Black : Color.White);
            return bitmap;
        }

        private void btn_PlayControl_Click(object sender, EventArgs e)
        {
            if (btn_PlayControl.Text == "Stop")
            {
                timer_Autoplay.Stop();
                btn_PlayControl.Text = "Play";
                return;
            }

            int fps;
            if (!int.TryParse(txt_Fps.Text, out fps))
                return;

            timer_Autoplay.Interval = 1000 / fps;
            timer_Autoplay.Start();
            btn_PlayControl.Text = "Stop";
        }

        private void timer_Autoplay_Tick(object sender, EventArgs e)
        {
            SimulateAndUpdate(1);
        }

        private void btn_Filter_Click(object sender, EventArgs e)
        {
            _gol.FilterStaticFormations();
            picturebox_Preview.Image = CreateImageFromResult(_gol.GetResult(), _gol.Height, _gol.Width);
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (saveFileDialog_Export.ShowDialog() != DialogResult.OK)
                return;

            int[] data = _gol.GetResult();
            var stream = new StreamWriter(saveFileDialog_Export.OpenFile());

            stream.WriteLine(_gol.Height);
            stream.WriteLine(_gol.Width);
            for (int i = 0; i < _gol.Height; i++)
            {
                for (int j = 0; j < _gol.Width; j++)
                    stream.Write(data[i * _gol.Width + j]);
                stream.WriteLine();
            }

            stream.Close();
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            if (openFileDialog_Import.ShowDialog() != DialogResult.OK)
                return;

            var stream = new StreamReader(openFileDialog_Import.OpenFile());
            int height = int.Parse(stream.ReadLine());
            int width = int.Parse(stream.ReadLine());

            bool[] data = new bool[height * width];
            for(int i=0; i<height; i++)
            {
                var line = stream.ReadLine();
                for (int j = 0; j < width; j++)
                    data[i * width + j] = line[j] == '0' ? false : true;
            }
            stream.Close();

            _gol.SetData(data, width, height);
            picturebox_Preview.Image = CreateImageFromRawData(data, height, width);
            lbl_Cycles.Text = _gol.Cycles.ToString();
        }

        private void btn_SetRules_Click(object sender, EventArgs e)
        {
            var rulesForm = new RulesForm(_gol.BornRule, _gol.SurviveRule);
            rulesForm.ShowDialog();
            if (rulesForm.Save)
                _gol.SetRule(rulesForm.Born, rulesForm.Survive);
        }



    }
}
