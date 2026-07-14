using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.QuanLyNhanVien
{
    internal abstract class Employee : IReportable
    {
        public string Name {  get; set; }
        public int Id {  get; set; }

        public Employee(string name, int id)
        {
            Name= name;
            Id = id;
        }

        public abstract double CalculateSalary();
        public string GetReport()
        {
            return $"{Name} - {Id} - nhan luong {CalculateSalary()}";
        }

    }
}
