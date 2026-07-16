using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.LINQ
{
    internal class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Class { get; set; }
        public double Score { get; set; }
        public string? Gender { get; set; }

        public Student(int id, string? name, int age, string? studentClass, double score, string? gender)
        {
            Id = id;
            Name = name;
            Age = age;
            Class = studentClass;
            Score = score;
            Gender = gender;
        }

        public Student() { }
    }
}