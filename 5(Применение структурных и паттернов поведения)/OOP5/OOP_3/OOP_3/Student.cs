using OOP_3.AbstractFactory;
using OOP_3.OOP4;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OOP_2
{
    [Serializable]
    [XmlRoot(Namespace = "STUDENTS")]
    [XmlType("student")]
    public class Student : StudentPrototype
    {
        public Student(string FN, int AGE, string PRF, string BDAY, int CRS, int GRP, double AVG, string SEX, Adress ADRS, AbstractFactory factory)
        {
            FullName = FN;
            Age = AGE;
            Profession = PRF;
            Birthday = BDAY;
            Course = CRS;
            Group = GRP;
            AverageGrade = AVG;
            Sex = SEX;
            adress = ADRS;
            exam = factory.CreateExam();
        }
        public Student(string FN, int AGE, string PRF, string BDAY, int CRS, int GRP, double AVG, string SEX, Adress ADRS)
        {
            FullName = FN;
            Age = AGE;
            Profession = PRF;
            Birthday = BDAY;
            Course = CRS;
            Group = GRP;
            AverageGrade = AVG;
            Sex = SEX;
            adress = ADRS;
        }
        public Student()
        {
            FullName = "";
            Age = 0;
            Profession = "";
            Birthday = "";
            Course = 0;
            Group = 0;
            AverageGrade = 0.0;
            Sex = "";
            adress = new Adress();
        }

        [XmlElement(ElementName = "name")]
        [Required(ErrorMessage = "Значение ФИО должно быть задано", AllowEmptyStrings = false)]
        public string FullName;
        [XmlElement(ElementName = "age")]
        public int Age;
        [XmlElement(ElementName = "prof")]
        public string Profession;
        [XmlElement(ElementName = "birthday")]
        public string Birthday;
        [XmlElement(ElementName = "course")]
        public int Course;
        [XmlElement(ElementName = "group")]
        public int Group;
        [XmlElement(ElementName = "avgG")]
        [Range(0, 10, ErrorMessage = "Неверное значение среднего балла!")]
        public double AverageGrade;
        [XmlElement(ElementName = "sex")]
        public string Sex;
        [XmlElement(ElementName = "adress")]
        public Adress adress;

        public Exam exam;

        public void TakingExam()
        {
            exam.TakeExam();
        }

        public override StudentPrototype Clone()
        {
            if (this.exam.typeOfStudent == "Заочник")
            {
                return new Student(FullName, Age, Profession, Birthday, Course, Group, AverageGrade, Sex, adress, new ExtramuralStudentFactory());
            }
            else if (this.exam.typeOfStudent == "Очник")
            {
                return new Student(FullName, Age, Profession, Birthday, Course, Group, AverageGrade, Sex, adress, new IntramuralStudentFactory());
            }
            return new Student(FullName, Age, Profession, Birthday, Course, Group, AverageGrade, Sex, adress);
        }

        public Student(AbstractFactory factory)
        {
            exam = factory.CreateExam();
        }
    } 
}
