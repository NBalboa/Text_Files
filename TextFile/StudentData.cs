using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile.Model;

namespace TextFile
{
    public static class StudentData
    {
        static List<StudentModel> students = new List<StudentModel>();
        static StudentModel student = new StudentModel();


        public static void AddStudent()
        {
            string firstName, lastName, address;
            int age;

            firstName = GetString("Enter Student First name: ");
            lastName = GetString("Enter Student Last name: ");
            age = GetInt("Enter a Student age: ");
            address = GetString("Enter Student address: ");

            student.FirstName = firstName;
            student.LastName = lastName;
            student.Age = age;
            student.Address = address;

            students.Add(student);
            

            using (StreamWriter sw = new StreamWriter("student.txt"))
            {
                foreach (var studentModel in students)
                {
                    sw.WriteLine($"{studentModel.FirstName}, {studentModel.LastName}, {studentModel.Age}, {studentModel.Address}");
                }
            }
            using (StreamReader sr = new StreamReader("student.txt"))
            {
                string ageString = student.Age.ToString();

                student.FirstName = sr.ReadLine();
                student.LastName = sr.ReadLine();
                ageString = sr.ReadLine();
                student.Address = sr.ReadLine();
            }

        }

        public static void ShowStudent()
        {
            using (StreamReader rd = new StreamReader("student.txt"))
            {
                string line = rd.ReadLine();
                string[] studentInfo = line.Split(',');
                foreach (var student in studentInfo)
                {
                    Console.WriteLine($"First name : {student[0]} Last name: {student[1]} Age : {student[2]} Address: {student[3]}");
                }
            }
        }

        public static string GetString(string message)
        {
            string output = "";
            while (string.IsNullOrEmpty(output))
            {
                Console.Write(message);
                output = Console.ReadLine();
            }

            return output;
        }

        public static int GetInt(string message)
        {
            string numberText = GetString(message);
            int number;
            bool isValidNumber = int.TryParse(numberText, out number);

            while (!isValidNumber)
            {
                Console.WriteLine("Invalid input. Please enter a digit");
                numberText = GetString(message);
                isValidNumber = int.TryParse(numberText, out number);
            }

            return number;
        }
    }
}
