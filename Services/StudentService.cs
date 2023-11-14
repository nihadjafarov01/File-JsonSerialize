using ConsoleApp1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    internal class StudentService
    {

        public static List<Student> students = new List<Student>();
        
        //{ new Student { Name = "Royal", Surname = "Asgarov", Code = "abc123" } , new Student { Name = "Vugar", Surname = "Samadov", Code = "fsd" }
        static string dataPath = @"C:\Users\nihad\Desktop\code_academy\File, JsonSerialize\ConsoleApp1\Data";
        static string jsonFile = "students.json";

        public static void SaveChangesToJson()
        {
            using (StreamReader sr = new StreamReader(Path.Combine(dataPath, jsonFile)))
            {
                string stds = sr.ReadToEnd();
                students = JsonConvert.DeserializeObject<List<Student>>(stds);
            }
        }
        public static void SaveChangesToList()
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(dataPath, jsonFile)))
            {
                string stds = JsonConvert.SerializeObject(students);
                sw.WriteLine(stds);
            }
        }
        public static bool IsExist(string code)
        {
            if (students != null)
            {
                foreach (var item in students)
                {
                    if (item.Code.Equals(code))
                    {
                        return true;
                    }
                }
            }
                return false;

        }
        public static void AddStudent(Student student)
        {
            if (IsExist(student.Code) == false)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(dataPath, jsonFile)))
                {
                    students.Add(student);
                    string stds = JsonConvert.SerializeObject(students);
                    sw.WriteLine(stds);
                }
            }
            else
            {
                Console.WriteLine("Bele bir student var");
            }
        }
        public static void RemoveStudent(string code)
        {
            if (IsExist(code))
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(dataPath, jsonFile)))
                {
                    students = students.FindAll(e => !e.Code.Equals(code));
                    string stds = JsonConvert.SerializeObject(students);
                    sw.WriteLine(stds);
                }
            }
            else { Console.WriteLine("Bele student yoxdur"); }
        }
        public static void GetAllStudents()
        {
            if (students != null)
            {
                foreach (var item in students)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Student yoxdur");
            }
        }
        public static void EditStudent(string code, Student student)
        {
            if (IsExist(code))
            {
                int indexToUpdate = students.FindIndex(student => student.Code == code);
                students[indexToUpdate] = student;
            }
            else
            {
                Console.WriteLine("Bele student yoxdu");
            }
        }
        }
    }
