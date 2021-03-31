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
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            textBox1.Tag = false;
            textBox2.Tag = false;
            textBox3.Tag = false;
        }


        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"[А-Я][а-я]+\s[А-Я][а-я]+\s[А-Я][а-я]+$"))
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

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox2.Text, @"[А-Я][а-я]+$"))
            {
                textBox2.Tag = false;
            }
            else
            {
                textBox2.BackColor = Color.White;
                textBox2.Tag = true;
            }
            EnableButton();
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox3.Text, @"[А-Я]$"))
            {
                textBox3.Tag = false;
            }
            else
            {
                textBox3.BackColor = Color.White;
                textBox3.Tag = true;
            }
            EnableButton();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3.result.Clear();
            if ((bool)textBox1.Tag == true)
            {
                foreach (Student x in Form1.studentListControl.studentList)
                {
                    if (x.FullName == textBox1.Text)
                    {
                        Form3.result.Add(x);
                    }
                }
            }
            else if ((bool)textBox2.Tag == true)
            {
                foreach (Student x in Form1.studentListControl.studentList)
                {
                    if (Regex.IsMatch(x.FullName, textBox2.Text))
                    {
                        Form3.result.Add(x);
                    }
                }
            }
            else if ((bool)textBox3.Tag == true)
            {

                foreach (Student x in Form1.studentListControl.studentList)
                {
                    if (Regex.IsMatch(x.FullName, "^" + textBox3.Text))
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
            button1.Enabled = (bool)textBox1.Tag || (bool)textBox2.Tag || (bool)textBox3.Tag;
        }

    }
}
