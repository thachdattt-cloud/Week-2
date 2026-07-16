using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace tuan2.LINQ
{
    internal class Student
    {
        public int Id { get; set; }
        public string  ? Name { get; set; }
        
        public int Age {  get; set; }
        public string ? Class {  get; set; }
        public double Score {  get; set; }
        public string ? Gender {  get; set; }

        public Student(int id,string? name , int age, string? @class, double score, string? gender)
        {
            Id = id;
            Name = name;
            
            Age = age;
            Class = @class;
            Score = score;
            Gender = gender;
        }
    public Student() { }


        public void handle()
        {
            Func<int, int, int> sum = (a, b) => a + b;
            Console.WriteLine("check sum : "+sum(5,7));
            Func<string,int> LengName=(name)=>name.Length;
            Console.WriteLine("check length name : "+LengName("quang dep trai"));

            Predicate<double> isPass = score => score >= 5;
            if (isPass(5))
            {
                Console.WriteLine("pass");
            }
            else
            {
                Console.WriteLine("fail");
            }
        }

            
        
    }
}
