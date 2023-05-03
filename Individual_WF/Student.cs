using System.Linq;

namespace Individual_WF
{
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Group { get; set; }
        public double[] Grades { get; set; }

        public double AverageGrade
        {
            get { return Grades.Average(); }
        }

        public Student(string lastName, string firstName, string middleName, string group, double[] grades)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Group = group;
            Grades = grades;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}, Группа {Group}, Средняя оценка: {AverageGrade}";
        }
    }
}