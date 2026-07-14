using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.Inheritance
{
    internal class Teacher :Person
    {
      public string Subject {  get; set; }
        public double Salary {  get; set; }

        public Teacher(string name,int age,string subject,double salary) :base(name,age){
            Subject = subject;
            Salary = salary;

        }
    }
}
