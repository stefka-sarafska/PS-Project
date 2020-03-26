using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
   static class Logger
    {
        private static string filePath = "C:\\Users\\Dell\\Desktop\\PS_74_Stefka\\UserLogin\\logFile.txt";
        static private List<string> currentSessionActivities = new List<string>();
        static public void LogActivity(string activity)
        {
            string nameOfCurrUser = LoginValidation.getCurrUserName();
            string activityLine = DateTime.Now + ";"
                  + LoginValidation.getCurrUserName()+ ";"
                          + LoginValidation.currentUserRole + ";"
                                          + activity;
            currentSessionActivities.Add(activityLine);
            if (File.Exists(filePath))
            {

                File.AppendAllText(filePath, activityLine, Encoding.UTF8);
            }
            else
            {
                Console.WriteLine("Error while working with log file.");
            }

            currentSessionActivities.Add(activityLine);
        }
        public static string ViewLogs()
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                return reader.ReadToEnd();
            }
        }
        public static void ViewCurrentSessionActivities()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string activity in currentSessionActivities)
            {
                builder.Append(activity);
            }
            Console.WriteLine(builder.ToString());
        }
        static public void GetLogFileActivities()
        {
            StreamReader sr = new StreamReader(filePath);
             string line = sr.ReadLine();
            Console.WriteLine(line);
            line = sr.ReadLine();
            Console.WriteLine(line);
            line = sr.ReadLine();
            Console.WriteLine(line);
            sr.Close();

        }
        public static void GetCurrentSessionActivities()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string activity in currentSessionActivities)
            {
                builder.Append(activity);
            }
            Console.WriteLine(builder.ToString());
        }
    }
}
