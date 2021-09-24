using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowUI();
            bool isContinue = true;
            int select;

            while (isContinue)
            {
                select = StudentData.GetInt("Select Option: ");
                if (select == 1)
                {
                    GetStudentInfoFromUi();
                }
                else if (select == 2)
                {
                    DisplayStudent();
                }
                else if (select == 3)
                {
                    isContinue = false;
                }
            }

            Console.ReadLine();
        }

        private static void DisplayStudent()
        {
            StudentData.ShowStudent();
        }
        private static void GetStudentInfoFromUi()
        {
            bool isContinue = true;

            while (isContinue)
            {
                StudentData.AddStudent();
                string answer = StudentData.GetString("Add Student? (Y/N): ");

                if (answer.ToLower() == "y")
                {
                    
                    isContinue = true;
                }
                else if (answer.ToLower() == "n")
                {
                    isContinue = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input. Please enter y or n only");
                }
            }
        }
      
        private static void ShowUI()
        {
            Console.WriteLine("1. Add Student: ");
            Console.WriteLine("2. Show Student: ");
            Console.WriteLine("3. Exit: ");
        }
    }
}
