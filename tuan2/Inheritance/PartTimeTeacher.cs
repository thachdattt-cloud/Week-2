using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.Inheritance
{
    internal class PartTimeTeacher : Teacher
    {
        public int HourlyRate {  get; set; }
        


        public PartTimeTeacher(string name,int age,string subject,double salary,int hourlyRate) : base(name,age,subject,salary)
        {
            HourlyRate= hourlyRate;
        }
        public double CalculateSalary()
        {
            return HourlyRate * Salary; 
        }

        public override void show()
        {
            base.show();
            Console.WriteLine($"tong luong {CalculateSalary().ToString("F2")}");
        }
    }
}
