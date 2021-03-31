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

namespace OOP_2
{
    public partial class Form1 : Form
    {
        string profession;
        List<Student> studentList = new List<Student>();
        string date;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            monthCalendar1.Tag = false;
            textBox1.Tag = false;
            radioButton4.Tag = false;
            radioButton3.Tag = false;
            radioButton2.Tag = false;
            radioButton1.Tag = false;
            listBox2.Tag = false;
            comboBox1.Tag = false;
            maskedTextBox1.Tag = false;
            textBox4.Tag = false;
            textBox5.Tag = false;
            textBox6.Tag = false;
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = String.Format("{0}", trackBar1.Value);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            profession = radioButton1.Text;
        }
        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {
            progressBar1.Value = int.Parse(domainUpDown2.Text);
        }
        private void button4_Click(object sender, EventArgs e)
        {
                Student student = new Student(
                    textBox1.Text,
                    trackBar1.Value,
                    profession,
                    date,
                    int.Parse(domainUpDown2.Text),
                    int.Parse(listBox2.SelectedItem.ToString()),
                    Convert.ToDouble(numericUpDown1.Value),
                    domainUpDown1.Text,
                    new Adress(comboBox1.SelectedItem.ToString(), maskedTextBox1.Text, textBox4.Text,
                    int.Parse(textBox5.Text), int.Parse(textBox6.Text))
                    );
                studentList.Add(student);
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["NSL"].Value = student.FullName;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Course"].Value = student.Course;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Group"].Value = student.Group;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Avg"].Value = student.AverageGrade;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Birth"].Value = student.Birthday;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Age"].Value = student.Age;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Adr"].Value = student.adress;
            textBox1.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            comboBox1.ResetText();
            maskedTextBox1.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            domainUpDown2.SelectedIndex = 0;
            listBox2.ClearSelected();
            numericUpDown1.ResetText();

            monthCalendar1.Tag = false;
            textBox1.Tag = false;
            radioButton4.Tag = false;
            radioButton3.Tag = false;
            radioButton2.Tag = false;
            radioButton1.Tag = false;
            listBox2.Tag = false;
            comboBox1.Tag = false;
            maskedTextBox1.Tag = false;
            textBox4.Tag = false;
            textBox5.Tag = false;
            textBox6.Tag = false;

            EnableButton();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            date = monthCalendar1.SelectionRange.Start.Day.ToString();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"[А-Я][а-я]+\s[А-Я][а-я]+\s[А-Я][а-я]+$"))
            {
                textBox1.BackColor = Color.Coral;
                textBox1.Tag =false;
            }
            else
            {
                textBox1.BackColor = Color.White;
                textBox1.Tag = true;
            }
            EnableButton();
        }

        private void radioButton1_Validating(object sender, CancelEventArgs e)
        {
            if (radioButton1.Checked)
            {
                profession = radioButton1.Text;
                radioButton1.BackColor = Color.White;
                radioButton1.Tag = true;
            }
            else if(!radioButton1.Checked && (radioButton2.Checked || radioButton3.Checked || radioButton4.Checked))
            {
                radioButton1.BackColor = Color.White;
                radioButton1.Tag = true;
            }
            else
            {
                radioButton1.BackColor = Color.Coral ;
            }
            EnableButton();
        }

        private void radioButton2_Validating(object sender, CancelEventArgs e)
        {
            if (radioButton2.Checked)
            {
                profession = radioButton2.Text;
                radioButton2.BackColor = Color.White;
                radioButton2.Tag = true;
            }
            else if (!radioButton2.Checked && (radioButton1.Checked || radioButton3.Checked || radioButton4.Checked))
            {
                radioButton2.BackColor = Color.White;
                radioButton2.Tag = true;
            }
            else
            {
                radioButton2.BackColor = Color.Coral;
            }
            EnableButton();
        }

        private void radioButton3_Validating(object sender, CancelEventArgs e)
        {
            if (radioButton3.Checked)
            {
                profession = radioButton3.Text;
                radioButton3.BackColor = Color.White;
                radioButton3.Tag = true;
            }
            else if (!radioButton3.Checked && (radioButton2.Checked || radioButton1.Checked || radioButton4.Checked))
            {
                radioButton3.BackColor = Color.White;
                radioButton3.Tag = true;
            }
            else
            {
                radioButton3.BackColor = Color.Coral;
            }
            EnableButton();
        }

        private void radioButton4_Validating(object sender, CancelEventArgs e)
        {
            if (radioButton4.Checked)
            {
                profession = radioButton4.Text;
                radioButton4.BackColor = Color.White;
                radioButton4.Tag = true;
            }
            else if (!radioButton4.Checked && (radioButton2.Checked || radioButton3.Checked || radioButton1.Checked))
            {
                radioButton4.BackColor = Color.White;
                radioButton4.Tag = true;
            }
            else
            {
                radioButton4.BackColor = Color.Coral;
            }
            EnableButton();
        }

        private void listBox2_Validating(object sender, CancelEventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                listBox2.BackColor = Color.White;
                listBox2.Tag = true;
            }
            else
            {
                listBox2.BackColor = Color.Coral;
                listBox2.Tag = false;
            }
            EnableButton();
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                comboBox1.BackColor = Color.White;
                comboBox1.Tag = true;
            }
            else
            {
                comboBox1.BackColor = Color.Coral;
                comboBox1.Tag = false;
            }
            EnableButton();
        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (maskedTextBox1.MaskCompleted == true)
            {
                maskedTextBox1.BackColor = Color.White;
                maskedTextBox1.Tag = true;
            }
            else
            {
                maskedTextBox1.BackColor = Color.Coral;
                maskedTextBox1.Tag = false;
            }
            EnableButton();
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox4.Text, @"(([А-Я][а-я]+(\s?))+$)|([А-Я][а-я]+(-?)([А-Я]?)([а-я]+)$)"))
            {
                textBox4.BackColor = Color.Coral;
                textBox4.Tag = false;
            }
            else
            {
                textBox4.BackColor = Color.White;
                textBox4.Tag = true;
            }
            EnableButton();
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox5.Text, @"[0-9]+$"))
            {
                textBox5.BackColor = Color.Coral;
                textBox5.Tag = false;
            }
            else
            {
                textBox5.BackColor = Color.White;
                textBox5.Tag = true;
            }
            EnableButton();
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox6.Text, @"[0-9]+[а-я]*$"))
            {
                textBox6.BackColor = Color.Coral;
                textBox6.Tag = false;
            }
            else
            {
                textBox6.BackColor = Color.White;
                textBox6.Tag = true;
            }
            EnableButton();
        }

        private void EnableButton()
        {   
            button4.Enabled = (bool)textBox1.Tag &&
                ((bool)radioButton4.Tag || (bool)radioButton3.Tag ||(bool)radioButton2.Tag || (bool)radioButton1.Tag) &&
                (bool)listBox2.Tag && (bool)comboBox1.Tag && (bool)maskedTextBox1.Tag && (bool)textBox4.Tag &&
                (bool)textBox5.Tag && (bool)textBox6.Tag && (bool)monthCalendar1.Tag;
        }

        private void monthCalendar1_Validating(object sender, CancelEventArgs e)
        {
            if(monthCalendar1.SelectionRange.Start.Date == DateTime.Today.Date)
            {
                monthCalendar1.Tag = false;
                monthCalendar1.BackColor = Color.Coral;
            }
            else
            {
                monthCalendar1.Tag = true;
                monthCalendar1.BackColor = Color.White;
            }
            EnableButton();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            if (Regex.IsMatch(filename, $".xml$"))
                XmlSerializeWrapper.Serialize(studentList, filename);
            else
            {
                MessageBox.Show("Неверный формат файла!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            if (Regex.IsMatch(filename, $".xml$"))
            {
                studentList = XmlSerializeWrapper.Deserialize<List<Student>>(filename);
                dataGridView1.Rows.Clear();
                foreach (Student x in studentList)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["NSL"].Value = x.FullName;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Course"].Value = x.Course;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Group"].Value = x.Group;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Avg"].Value = x.AverageGrade;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Birth"].Value = x.Birthday;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Age"].Value = x.Age;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Adr"].Value = x.adress;
                }
            }
            else
            {
                MessageBox.Show("Неверный формат файла!");
            }
        }
    }

}
