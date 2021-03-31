
using OOP_2;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OOP_3
{
    public partial class Form3 : Form
    {
        public static List<Student> result = new List<Student>();
        public Form3()
        {
            InitializeComponent();
           
        }

        private void Form3_Shown(object sender, System.EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (Student x in Form3.result)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["NSL"].Value = x.FullName;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Course"].Value = x.Course;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Group"].Value = x.Group;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["PROF"].Value = x.Profession;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Avg"].Value = x.AverageGrade;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Birth"].Value = x.Birthday;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Age"].Value = x.Age;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["SEX"].Value = x.Sex;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Adr"].Value = x.adress;
            }
        }
    }
}
