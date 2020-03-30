using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
   public class Student
    {
        public string firstName;
        public string middleName;
        public string lastName;
        public string faculty;
        public string speciality;
        public string degree;
        public string status;
        public int facultyNumber;
        public int course;
        public int stream;
        public int group;

        public Student(string firstName, string middleName, string lastName, string faculty, string speciality, string degree, string status, int facultyNumber, int course, int stream, int group)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.faculty = faculty;
            this.speciality = speciality;
            this.degree = degree;
            this.status = status;
            this.facultyNumber = facultyNumber;
            this.course = course;
            this.stream = stream;
            this.group = group;

        }

   
    }
}
