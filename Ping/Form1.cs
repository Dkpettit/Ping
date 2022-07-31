using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ping
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ReadInput input = new ReadInput();
        OutputToList outPut = new OutputToList();
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to close this window?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> list = input.getInput();
            outPut.PopulateListBox(list, listBox1, listBox2);
        }
    }
}
