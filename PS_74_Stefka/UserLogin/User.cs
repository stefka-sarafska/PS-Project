using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public string name;
        public string password;
        public int fNumber;
        public UserRoles role;
        public DateTime Created;
        public DateTime expiryDate;



        public User(string name,string pass,int number,UserRoles role,DateTime Created,DateTime expiryDate)
        {
            this.name = name;
            password = pass;
            fNumber = number;
            this.role = role;
            this.Created = Created;
            this.expiryDate = expiryDate;

        }

        public override String ToString()
        {
            return "Name: "+this.name+", Faculty Number: "+this.fNumber+", Role: "+this.role+", Expiry date: "+this.expiryDate+"\n";
        }


    /*   public void setRole(int role)
        {
            if (role == 1)
            {
                Console.Write("Administrator");
            }else if (role == 2)
            {
                Console.Write("Inspektor");
            }
            else if (role == 3)
            {
                Console.Write("prepodavatel");
            }
            else if (role == 4)
            {
                Console.Write("Student");
            }
            else
            {
                Console.Write("Invalid input");
            }
        }
        
        public int getRole(int role)
        {
            return role;
        }
        */
    }
}
