using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        List<string> list = new List<string>();
        
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
            list = input.getInput(textBox2, timer1);            
        }

        /// <summary>
        /// Timer to increment the progress bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(3);
            if(progressBar1.Value >= progressBar1.Maximum)
            {
                timer1.Stop();
                MessageBox.Show("...Use the Ping button to get results.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            if (textBox2.Text.Length == 0)
            {
                if (list.Count > 0)
                {
                    outPut.PopulateListBox(list, listBox1, listBox2);
                }
                else
                {
                    MessageBox.Show("Please load a CSV file, or enter a URL...");
                }
                
            }
            else
            {
                outPut.PopulateListBox(list, listBox1, listBox2, textBox2.Text.ToString());
                
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox2.Text = "";
            progressBar1.Value = progressBar1.Minimum;
        }

        
    }
}
