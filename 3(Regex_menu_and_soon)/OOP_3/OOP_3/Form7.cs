using OOP_2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_3
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3.result.Clear();
            Form3.result.AddRange(Form1.studentListControl.studentList.OrderBy(n => n.Group));
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3.result.Clear();
            Form3.result.AddRange(Form1.studentListControl.studentList.OrderBy(n => n.Course));
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
