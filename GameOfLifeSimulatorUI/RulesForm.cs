using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLifeSimulatorUI
{
    public partial class RulesForm : Form
    {
        public string Born { get; set; }
        public string Survive { get; set; }
        public bool Save { get; set; }

        public RulesForm(string born, string survive)
        {
            InitializeComponent();
            Save = false;
            txt_Born.Text = born;
            txt_Survive.Text = survive;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Born = txt_Born.Text;
            Survive = txt_Survive.Text;
            Save = true;
            this.Close();
        }
    }
}
