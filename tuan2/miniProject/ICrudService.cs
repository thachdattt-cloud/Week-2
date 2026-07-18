using System;
using System.Collections.Generic;

namespace tuan2.miniProject;

internal interface ICrudService<T>
{
    bool Add(T item);
    int Remove(int id);
    List<T> GetAll();
}