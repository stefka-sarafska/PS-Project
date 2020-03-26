using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UserLogin
{

    class Program
    {
        static void Main(string[] args)
        {
            administrator();
            Console.ReadLine();
        }
        public static void ErrorAction(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }
        private static void showMenu()
        {
            Console.WriteLine("Choose option: ");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Change the role of user");
            Console.WriteLine("2: Change the activity of user");
            Console.WriteLine("3: List of users");
            Console.WriteLine("4: Show log activity");
            Console.WriteLine("5: Show current log activity");
        }
        private static void administrator()
        {
  
            User u = getSuccessfulLogInUser();
            if (u != null)
            {
                Console.WriteLine("Username: " + u.name);
                Console.WriteLine("Password: " + u.password);
                Console.WriteLine("Faculty Number: " + u.fNumber);
                Console.WriteLine("Date: " + u.Created);
                Console.WriteLine("Active until: " + u.expiryDate);



                String type = LoginValidation.currentUserRole.ToString();
                switch (type)
                {
                    case "ANONYMOUS":
                        Console.WriteLine("This person is an anonymous.");
                        break;
                    case "ADMIN":
                        Console.WriteLine("This person is an admin.");
                        break;
                    case " INSPECTOR":
                        Console.WriteLine("This person is an inspector.");
                        break;
                    case " PROFESSOR":
                        Console.WriteLine("This person is a professor.");
                        break;
                    case "STUDENT":
                        Console.WriteLine("This person is a student.");
                        break;
                }
               
                showMenu();
                Console.WriteLine("Enter person name for search: ");
                String searchedName = Console.ReadLine();
                User searchedUser = UserData.getUserByName(searchedName);
                Console.WriteLine("Enter choice from menu options:");
                String choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        return;
                    case "1":
                        Console.WriteLine("You choose to set new role to user "+u.name);
                        Console.WriteLine("New role:");
                        String newRole = Console.ReadLine();
                        UserData.AssignUserRole(searchedName, newRole);
                        break;
                    case "2":
                        Console.WriteLine("New expiry date: ");
                        DateTime date = new DateTime(Console.Read(), Console.Read(), Console.Read());
                        searchedUser.expiryDate = date;
                        break;
                    case "3":
                        UserData.ListAllUsers();
                        break;
                    case "4":
                        Logger.GetLogFileActivities();
                        break;
                    case "5":
                        Logger.GetCurrentSessionActivities();
                        break;
                    default:
                        Console.WriteLine("Your choice does not exist.");
                        break;


                }
            }
        }
        private static User getSuccessfulLogInUser()
        {
            Console.WriteLine("------Login--------");
            
            int counter = 0;
            while (true)
            {

                Console.WriteLine("Please enter username: ");
                String usernameInput = Console.ReadLine();
                Console.WriteLine("Please enter password: ");
                String passwordInput = Console.ReadLine();
                User user = UserData.getUserByName(usernameInput);
                LoginValidation log = new LoginValidation(usernameInput, passwordInput, ErrorAction);
                log.ValidateUserInput(user);
                Boolean userLoginTry = log.LogInStatus(log.getMessage());
                
                if (userLoginTry == true)
                {
                    Console.WriteLine("Log in successfully.");
                    return user;

                }
                else
                {
                    Console.WriteLine("Log in fail");
                    counter++;
                    if (counter == 3)
                    {
                        Console.WriteLine("You have 3 unseccessful traing please wait 3 minutes and try again");
                        Console.WriteLine(DateTime.Now.ToLongTimeString());
                        var stopwatch = Stopwatch.StartNew();
                        Thread.Sleep(180000);
                        stopwatch.Stop();
                        Console.WriteLine(stopwatch.ElapsedMilliseconds);
                        Console.WriteLine(DateTime.Now.ToLongTimeString());
                        counter = 0;
                    }
                }
            }
        }
     
       
    }
}

