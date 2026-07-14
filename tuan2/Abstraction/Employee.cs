using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.Abstraction
{
    internal abstract class Employee
    {
        public string Name {  get; set; }
        public double BaseSalary {  get; set; }

        public abstract double CalculateBonus();
        public Employee(string name,double baseSalary)
        {
            Name= name;
            BaseSalary= baseSalary;
        }

        public void ShowInter()
        {
            Console.WriteLine($"luong cua thuc tap : {CalculateBonus()}");
           
        }
        public void ShowFullTimeEmployee()
        {

            Console.WriteLine($"luong cua nhanvien full time : {CalculateBonus()}");
        }

  
    }
}
