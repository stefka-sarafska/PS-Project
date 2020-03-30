using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
   public class LoginValidation
    {
        public delegate void ActionOnError(string errorMsg);
        private ActionOnError error;
        private string userName;
        private string password;
        private string errorMessage;

        public String getMessage()
        {
            return errorMessage;
        }

        public LoginValidation(string userName,string password,ActionOnError error)
        {
            this.userName = userName;
            this.password = password;
            this.error = error;
        }

        static public String currentUserName
        { get; private set; }
     //   static public UserRoles currentUserRole
       // { get; private set; }
        static public UserRoles currentUserRole
        { get; private set; }
        static public String getCurrUserName()
        {
            return currentUserName;
        }
        public String getError()
        {
            return this.errorMessage;
        }


        public Boolean ValidateUserInput(User user)
        {
            Boolean emptyUserName;
            emptyUserName = userName.Equals(String.Empty);
            if (emptyUserName == true)
            {
                errorMessage = "Username is empty.";
             
                error(errorMessage);
                return false;
                
            }
            Boolean emptyPassword;
            emptyPassword = password.Equals(String.Empty);
            if (emptyPassword == true)
            {
                errorMessage = "Password is empty.";
           
                error(errorMessage);
                return false;
            }
            if (userName.Length < 5)
            {
                errorMessage = "Username must be more then 5 symbols";
             
                error(errorMessage);
                return false;
            }
            if (password.Length < 5)
            {
                errorMessage = "Password must be more then 5 symbols";
             
                error(errorMessage);
                return false;
            }
            if (UserData.IsUserPassCorrect(userName, password) != null)
            {
                User newUser = UserData.IsUserPassCorrect(userName, password);
                user = newUser;
                currentUserRole = (UserRoles)user.role;
                currentUserName = newUser.name;
                errorMessage = "Successful Login";
                Logger.LogActivity("Successful Login");
                  return true;

            
          
        }  else
                {
                errorMessage = "Searched user does not exist.";
                error(errorMessage);
                return false;
                }

}
       
public Boolean LogInStatus(String errorMsg)
        {
            if(errorMessage!=null&&this.errorMessage.Equals("Successful Login"))
            {
                return true;

            }
            else
            {
                return false;
            }


        }

    }
}
