using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.QuanLyNhanVien
{
    internal class EmployeeService : ICrudService<Employee>
    {
        List<Employee> employees = new List<Employee>();
        public void Add(Employee item)
        {
            employees.Add(item);
        }

        public bool Removee(int id)
        {
            Employee? employee = employees.FirstOrDefault(s => s.Id == id);
            if (employee != null)
            {
                 employees.Remove(employee);
                return true;
            }
            return false;


        }

        public List<Employee> GetAll()
        {
            return employees;  
        }

        public void DisplayInfo()
        {
            foreach (var x in employees)
            {
                Console.WriteLine(x.GetReport());
            }
        }
    }
}
