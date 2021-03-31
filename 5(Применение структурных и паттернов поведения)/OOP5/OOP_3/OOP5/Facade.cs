using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_3.OOP5
{
    class Facade
    {
        StudentListChangeControl subsystemA;

        public Facade(StudentListChangeControl sa)
        {
            subsystemA = sa;
        }
        public void DeductPaying()
        {
            subsystemA.Deduct();
        }
        public void DeductFree()
        {
            subsystemA.PayScholarship();
            subsystemA.Deduct();
        }
    }

    partial class StudentListChangeControl
    {
        public void Deduct()
        {
            MessageBox.Show("Студент отчислен"); 
        }

        public void PayScholarship()
        {
            MessageBox.Show("Студенту выплачена стипендия");  
        }
    }

}
