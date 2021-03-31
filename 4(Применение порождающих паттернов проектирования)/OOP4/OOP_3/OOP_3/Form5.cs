using OOP_2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_3
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            textBox1.Tag = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3.result.Clear();
            if ((bool)textBox1.Tag == true)
            {
                foreach (Student x in Form1.studentListControl.studentList)
                {
                    if (x.Course == int.Parse(textBox1.Text))
                    {
                        Form3.result.Add(x);
                    }
                }
            }
            Form3 form3 = new Form3();
            form3.Show();
        }
        private void EnableButton()
        {
            button1.Enabled = (bool)textBox1.Tag;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"[1-4]$"))
            {
                textBox1.Tag = false;
            }
            else
            {
                textBox1.BackColor = Color.White;
                textBox1.Tag = true;
            }
            EnableButton();
        }
    }
}
