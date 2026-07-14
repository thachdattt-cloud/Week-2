using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.QuanLyNhanVien
{
    internal class PartTimeEmployee : Employee
    {
        public int HourlyRate { get; set; }
        public double HourWork { get; set; }


        public PartTimeEmployee(string name, int id, int hourlyRate, double hourWork) : base(name, id)
        {
            HourlyRate = hourlyRate;
            HourWork = hourWork;
        }

        public override double CalculateSalary()
        {
            return HourlyRate * HourWork;
        }
    }
}
