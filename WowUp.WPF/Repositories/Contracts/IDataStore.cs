﻿using SQLite;
using System;
using System.Collections.Generic;

namespace WowUp.WPF.Repositories.Contracts
{
    public interface IDataStore<T>
    {
        bool AddItem(T item);
        bool AddItems(IEnumerable<T> item);
        bool SaveItems(IEnumerable<T> items);
        bool UpdateItem(T item);
        bool DeleteItem(string id);
        IEnumerable<T> Query(Func<TableQuery<T>, TableQuery<T>> action);
        T Query(Func<TableQuery<T>, T> action);
    }
}
