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
        void Create(BankAccount account);
        BankAccount Read(int id);
        void Update(BankAccount account);
        void Delete(BankAccount account);
        void View();
    }
}
