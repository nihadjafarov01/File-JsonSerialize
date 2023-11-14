using ConsoleApp1.Models;
using ConsoleApp1.Services;
using Newtonsoft.Json;
using System.Threading.Channels;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentService.students.Add(new Student());
            char option = '0';
            char option2 = '0';
            do
            {
                // string dataPath = @"C:\Users\nihad\Desktop\code_academy\File, JsonSerialize\ConsoleApp1\Data";
                // string jsonFile = "students.json";
                //using (StreamWriter sw = new StreamWriter(Path.Combine(dataPath, jsonFile)))
                //{
                //    StudentService.students.Add(new Student { Name = "Royal", Surname = "Asgarov", Code = "abc123" });
                //    string stds = JsonConvert.SerializeObject(StudentService.students);
                //    sw.WriteLine(stds);
                //}
                StudentService.SaveChangesToJson();
                Console.WriteLine("1. Add student\n2. Remove student\n3. Edit student\n4. Get all students\n5. Exit");
                option = Convert.ToChar(Console.ReadLine());
                switch (option)
                {
                    case '1':
                        Student student = new Student();
                        Console.WriteLine("Name: ");
                        student.Name = Console.ReadLine();
                        Console.WriteLine("Surname: ");
                        student.Surname = Console.ReadLine();
                        Console.WriteLine("Code: ");
                        student.Code = Console.ReadLine();
                        StudentService.AddStudent(student);
                        
                        break;
                    case '2':
                        Console.WriteLine("Code: ");
                        string code = Console.ReadLine();
                        StudentService.RemoveStudent(code);
                        break;
                    case '3':
                        Console.WriteLine("Code: ");
                        string code2 = Console.ReadLine();
                        Student getStudent = StudentService.students.FirstOrDefault(student => student.Code == code2);
                        if (getStudent != null)
                        {
                            do
                            {
                                //StudentService.SaveChanges();
                                Console.WriteLine(StudentService.students.FirstOrDefault(student => student.Code == code2));
                                Console.WriteLine("1. Name\n2. Surname\n3. Quit");
                                option2 = Convert.ToChar(Console.ReadLine());
                                switch (option2)
                                {
                                    case '1':
                                        Console.WriteLine("Name: ");
                                        StudentService.students.FirstOrDefault(student => student.Code == code2).Name = Console.ReadLine();
                                        StudentService.EditStudent(code2, getStudent);
                                        StudentService.SaveChangesToList();
                                        break;
                                    case '2':
                                        Console.WriteLine("Surname: ");
                                        StudentService.students.FirstOrDefault(student => student.Code == code2).Surname = Console.ReadLine();
                                        StudentService.EditStudent(code2, getStudent);
                                        StudentService.SaveChangesToList();
                                        break;
                                }
                            }
                            while (option2 != '3');                       
                        }                      
                        break;
                    case '4':
                        StudentService.GetAllStudents();
                        break;
                }
            }
            while (option != '5');
        }
    }
}