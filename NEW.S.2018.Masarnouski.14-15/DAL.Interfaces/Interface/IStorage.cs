using System;
using System.Collections.Generic;

namespace DAL.Interfaces.Interface
{
    public interface IStorage
    {
        List<BankAccount> Load();
        void Save(List<BankAccount> accountsList);
    }
}
