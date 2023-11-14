using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Code { get; set; }
        
        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, Code: {Code}";
        }
    }
}
