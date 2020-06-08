using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin.Exceptions
{
    class StudentExeption : Exception
    {
        public string StudentName { get; }
        public StudentExeption() { }

        public StudentExeption(string message):base(message)
        {
        }

        public StudentExeption(string message,Exception inner) : base(message, inner)
        {

        }
        public StudentExeption(string message,string studentName) : base(message)
        {
            StudentName = studentName;
        }
    }
}
