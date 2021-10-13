using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282_Milestone_2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogInForm());

            // To create a text file for the logIn and the details.

            //string path1 = @"C:\Users\corre\Desktop\Study\Second year subjects\PRG 282\Project\Milestone_2\PRG282_Project_Milestone2\PRG282_Milestone_2\bin\Debug\LoginDetails.txt";
            //string path2 = @"C:\Users\corre\Desktop\Study\Second year subjects\PRG 282\Project\Milestone_2\PRG282_Project_Milestone2\PRG282_Milestone_2\bin\Debug\LoginTimes.txt";

            //string loginDetail = "Miguel;Miguel123";
            //string loginTime = "Miguel;16:00 pm";

            //File.WriteAllText(path1, loginDetail);
            //File.WriteAllText(path2, loginTime);

            //Console.ReadLine();
        }
    }
}
