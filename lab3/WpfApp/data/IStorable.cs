﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public interface IStorable<T>
    {
        void AddAndSaveItem(T item);

        IEnumerable<T> GetList();
    }
}
