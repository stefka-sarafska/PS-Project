using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static class UserData
    {

        static private List<User> _testUsers = new List<User>();

        static public List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }
        public static User getUserByName(String name)
        {

            foreach (User user in TestUsers)
            {
                if (user.name.Equals(name))
                {
                    return user;
                }
            }
            return null;
        }

        static private void ResetTestUserData()
        {
            if (!_testUsers.Any())
            {

                _testUsers.Add(new User("Ivana", "123a45", 12345973, UserRoles.STUDENT, DateTime.Now, DateTime.MaxValue));

                _testUsers.Add(new User("Petko", "123a70", 12345974, UserRoles.PROFESSOR, DateTime.Now, DateTime.MaxValue));

                _testUsers.Add(new User("Maria", "123a80", 12345975, UserRoles.ADMIN, DateTime.Now, DateTime.MaxValue));

            }
            /*   _testUsers[0] = new User("Ivana", "123a45", 12345973, 4,DateTime.Now,date);
              _testUsers[1] = new User("Petko", "123a70", 12345974, 4,DateTime.Now,date);
              _testUsers[2] = new User("Maria", "123a80", 12345975, 1,DateTime.Now,date);
              */
        }

        static public User IsUserPassCorrect(String name, String pass)
        {
            foreach (User testUser in TestUsers)
            {
                if (name.Equals(testUser.name) && pass.Equals(testUser.password))
                {
                    return testUser;
                }
            }
            return null;
        }
        static public void SetUserActivitiTo(String name, DateTime activeDate)
        {
            foreach (User t in TestUsers)
            {
                if (name.Equals(t.name))
                {
                    Logger.LogActivity("Changing activity of  " + t.name);
                    t.expiryDate = activeDate;
                }
            }
        }
        static public void AssignUserRole(String name, String newRole)
        {
            foreach (User user in TestUsers)
            {
                if (name.Equals(user.name))
                {
                    Logger.LogActivity("Changing the role of " + user.name);
                    user.role = GetRolesByName(newRole);

                }
            }
        }
        public static UserRoles GetRolesByName(string name)
        {
            if (name.Equals(UserRoles.ADMIN))
            {
                return UserRoles.ADMIN;
            }
            else if (name.Equals(UserRoles.ANONYMOUS))
            {
                return UserRoles.ANONYMOUS;
            }
            else if (name.Equals(UserRoles.INSPECTOR))
            {
                return UserRoles.INSPECTOR;
            }
            else if (name.Equals(UserRoles.PROFESSOR))
            {
                return UserRoles.PROFESSOR;
            }
            else
            {
                return UserRoles.STUDENT;
            }
          
        }
        public static void ListAllUsers()
        {
           // StringBuilder builder = new StringBuilder();
           // builder.Append("\n*******************\n");
            foreach (User user in TestUsers)
            {
                Console.WriteLine(user.ToString() + "*******************\n");
            }
          //  Console.WriteLine(builder.ToString());
        }
    }


}



