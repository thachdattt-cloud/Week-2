using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.QuanLyNhanVien
{
    internal interface ICrudService<T>
    {
        public void Add(T item);
        public bool Removee(int id);

        public List<Employee> GetAll ();

    }
}
