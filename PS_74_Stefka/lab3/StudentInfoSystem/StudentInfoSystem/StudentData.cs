using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class StudentData
    {
        private static List<Student> students=new List<Student>();


        private static void setStudents(Student student)
        {
            students.Add(student);
        }
        public static List<Student> getStudents()
        {
         
            return students;
        }
        
        public static void addStudents()
        {
            setStudents(new Student("Ivan", "Ivanov", "Ivonov", "FKSU", "KSI", "bachelor", "interrupted", 121217056, 3, 7, 45));
            setStudents(new Student("Maria", "Georgieva", "Petkova", "FKSU", "KSI", "master", "assured", 121217011, 5, 8, 35));
        }

        
    }
}
