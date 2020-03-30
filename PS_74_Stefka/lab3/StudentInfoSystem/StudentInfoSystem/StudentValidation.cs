using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
   public class StudentValidation
    {
        public Student GetStudentDataByUser(User user)
        {
            Student existingStudent = null;
            if (user.fNumber == 0)
            {
                Console.WriteLine("This user don't have faculty number!");
            }
            
            foreach (Student student in StudentData.getStudents())
            {
                if (student.facultyNumber.Equals(user.fNumber))
                {
                    existingStudent = student;
                }
            }
            if (existingStudent == null)
            {
                Console.WriteLine("Student with faculty number " + user.fNumber + " does not exist.");
            }
            return existingStudent;
        }
    }
}
