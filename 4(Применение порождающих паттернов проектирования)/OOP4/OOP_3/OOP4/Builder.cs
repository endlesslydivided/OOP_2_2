using OOP_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3.OOP4
{
    abstract class StudentStringBuilder
    {
        public StudentInforamation info = new StudentInforamation();
        public void CreateStudentStringInfo()
        {
            info = new StudentInforamation();
        }
        public abstract void BuildStudentPrivateInformation(Student st);
        public abstract void BuildStudentAdressInformation(Student st);
        public abstract void BuildStudentGroupInformation(Student st);
    }

    public class StudentPrivateInformation 
    {
        public string BirthdayINFO { get; set; }
        public string AgeINFO { get; set; }
        public string NameInfo { get; set; }
        public string SexInfo { get; set; }
    }
    public class StudentAdressInformation 
    {
        public string CityINFO { get; set; }
        public string IndexINFO { get; set; }
        public string StreetINFO { get; set; }
        public string HouseINFO { get; set; }
        public string FlatINFO { get; set; }
    }
    public class StudentGroupInformation 
    {
        public string GroupNumberINFO { get; set; }
        public string ProfessionNameINFO { get; set; }
        public string CourseINFO { get; set; }
        public string AVGGradeINFO { get; set; }
    }


    public class StudentInforamation
    {
    public  StudentPrivateInformation   StudentPrivateINFO { get; set; }
    public  StudentAdressInformation    StudentAdressINFO { get; set; }
    public  StudentGroupInformation     StudentGroupINFO { get; set; }

    public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if(StudentPrivateINFO != null)
            {
                sb.Append( "ФИО: " +             StudentPrivateINFO.NameInfo +
                           "\nДень рождения: " + StudentPrivateINFO.BirthdayINFO +
                           "\nВозраст: " +       StudentPrivateINFO.AgeINFO +
                           "\nПол: " +           StudentPrivateINFO.SexInfo);
            }

            if (StudentAdressINFO != null)
            {
                sb.Append(  "Город: " +               StudentAdressINFO.CityINFO +
                           "\nИндекс: " +    StudentAdressINFO.IndexINFO +
                           "\nУлица: " +          StudentAdressINFO.StreetINFO +
                           "\nДом: " +              StudentAdressINFO.HouseINFO +
                           "\nКвартира: " +              StudentAdressINFO.FlatINFO);
            }

            if (StudentGroupINFO != null)
            {
                sb.Append("Номер группы: " + StudentGroupINFO.GroupNumberINFO +
                           "\nСпециальность: " + StudentGroupINFO.ProfessionNameINFO +
                           "\nКурс: " + StudentGroupINFO.CourseINFO +
                           "\nСредняя оценка: " + StudentGroupINFO.AVGGradeINFO);
            }

            return sb.ToString();
        }
    }


    class PrivateInformationBuilder : StudentStringBuilder
    {
        public override void BuildStudentAdressInformation(Student st)
        {
        }

        public override void BuildStudentGroupInformation(Student st)
        {
        }

        public override void BuildStudentPrivateInformation(Student st)
        {
            this.info.StudentPrivateINFO = new StudentPrivateInformation();
            this.info.StudentPrivateINFO.AgeINFO = st.Age.ToString();
            this.info.StudentPrivateINFO.SexInfo = st.Sex.ToString();
            this.info.StudentPrivateINFO.NameInfo= st.FullName;
            this.info.StudentPrivateINFO.BirthdayINFO = st.Birthday;
        }
    }

    class AdressInformationBuilder : StudentStringBuilder
    {
        public override void BuildStudentAdressInformation(Student st)
        {
            this.info.StudentAdressINFO = new StudentAdressInformation();
            this.info.StudentAdressINFO.CityINFO = st.adress.city;
            this.info.StudentAdressINFO.StreetINFO = st.adress.street;
            this.info.StudentAdressINFO.FlatINFO = st.adress.apartment.ToString();
            this.info.StudentAdressINFO.HouseINFO = st.adress.house.ToString();
            this.info.StudentAdressINFO.IndexINFO = st.adress.index;
        }

        public override void BuildStudentGroupInformation(Student st)
        {

        }

        public override void BuildStudentPrivateInformation(Student st)
        {
           
        }
    }

    class GroupInformationBuilder : StudentStringBuilder
    {
        public override void BuildStudentAdressInformation(Student st)
        {
        }

        public override void BuildStudentGroupInformation(Student st)
        {
            this.info.StudentGroupINFO = new StudentGroupInformation();
            this.info.StudentGroupINFO.GroupNumberINFO = st.Group.ToString();
            this.info.StudentGroupINFO.ProfessionNameINFO = st.Profession;
            this.info.StudentGroupINFO.CourseINFO = st.Course.ToString();
            this.info.StudentGroupINFO.AVGGradeINFO = st.AverageGrade.ToString();
        }

        public override void BuildStudentPrivateInformation(Student st)
        {

        }
    }

    class StudentDirector
    {
        public StudentInforamation BuildString(StudentStringBuilder studentStringBuilder,Student st)
        {
            studentStringBuilder.BuildStudentAdressInformation(st);
            studentStringBuilder.BuildStudentGroupInformation(st);
            studentStringBuilder.BuildStudentPrivateInformation(st);
            return studentStringBuilder.info;
        }
    }

}
