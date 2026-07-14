using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.Interface.Interface_service
{
    internal interface ICrudService<T>
    {

        public void Add(T item);
        public bool Remove(int id);


        public List<T> GetAll();
    }
}
