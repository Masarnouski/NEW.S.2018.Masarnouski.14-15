using BLL.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Interface
{
    public interface IAccountService
    {
        void Add(BankAccount account);

        void Remove(BankAccount account);

        void Save();

        void View();

        void Load();
    }
}
