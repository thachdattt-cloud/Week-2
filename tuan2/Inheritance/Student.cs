using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.Inheritance
{
    internal class Student : Person
    {
        public string Class { get; set; }
        public double Gpa {  get; set; }

        public Student (string name,int age,string @class,double gpa) : base(name, age)
        {
            Class= @class;
            Gpa= gpa;
        }

        public Student()
        {
           
        }

        public override void show()
        {
            
            base.show();
            Console.WriteLine($"toi hoc lop {Class} co gpa : {Gpa}");

        }
    }
}
