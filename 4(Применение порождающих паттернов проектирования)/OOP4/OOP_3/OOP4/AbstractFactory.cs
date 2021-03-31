using OOP_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3.AbstractFactory
{
    public abstract class AbstractFactory
    {
        public abstract Exam CreateExam();
    }

    public abstract class Exam
    {
        public string message = default;
        public string typeOfStudent = default;
        public abstract void TakeExam();
        public override string ToString()
        {
            return message + "▬" +typeOfStudent;
        }
    }

    class InUniversity : Exam
    {
        public override void TakeExam()
        {
            this.typeOfStudent = "Очник";
            this.message = "Экзамены сдаются очно";
        }
    }
    class OnDistance: Exam
    {
        public override void TakeExam()
        {
            this.typeOfStudent = "Заочник";
            this.message = "Экзамены сдаются дистанционно";
        }
    }
    class ExtramuralStudentFactory : AbstractFactory
    {
        public override Exam CreateExam()
        {
            return new OnDistance();
        }
    }
    class IntramuralStudentFactory : AbstractFactory
    {
        public override Exam CreateExam()
        {
            return new InUniversity();
        }
    }
}

