using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.service
{
    internal class StudentService
    {
        private List<Studentt> danhsach = new List<Studentt>();

        public void AddStudent(Studentt s)
        {
            
            danhsach.Add(s);


        }

        public void RemoveStudent(int id)
        {
            Studentt? student = danhsach.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                danhsach.Remove(student);

            }
            else
            {
                Console.WriteLine($"khong tim thay sinh vien co id :{id}");
            }

        }

        public List<Studentt> GetAllStudent()
        {
            return danhsach;
        }

    }
}

