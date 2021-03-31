using OOP_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    public class MementoStudentList
    {
        public List<Student> studentList = new List<Student>();
        public MementoStudentList(List<Student> state)
        {
            if (state != null)
            {
                foreach (Student x in state)
                {
                    this.studentList.Add(x);
                }
            }
            else if (state == null)
                this.studentList.Clear();
        }
    }

    public class CaretakerStudentList
    {
        public Stack<MementoStudentList> History { get; private set; }
        public CaretakerStudentList()
        {
            History = new Stack<MementoStudentList>();
        }
    }

    public class StudentListChangeControl
    {
        public List<Student> studentList = new List<Student>();
        public void RestoreState(MementoStudentList memento)
        {
            studentList = memento.studentList;
        }
        public MementoStudentList SaveState()
        {
            return new MementoStudentList(studentList);
        }
    }
}
