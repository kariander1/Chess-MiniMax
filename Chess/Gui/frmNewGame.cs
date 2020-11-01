using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form2 : Form
    {
        public  bool CompMode;

        public Form2()
        {
            InitializeComponent();
            CompMode = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CompMode = radioButton6.Checked;
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton4.Checked)
                MainWindow.playerFirst = true;
            else
                MainWindow.playerFirst = false;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
                groupBox1.Enabled = true;
            else
                groupBox1.Enabled = false;
        }
    }
}
