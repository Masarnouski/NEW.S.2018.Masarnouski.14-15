using BLL.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Main()
            {
                BankAccount account1 = new BankAccount(1, "Eugene", "Masarnouski", 100, AccountType.Base);
                BankAccount account2 = new BankAccount(1, "Alesya", "Dzehachova", 200, AccountType.Gold);

                IBonusCounter counter;
                IStorage storage;
                AccountService service = new AccountService(storageFactory, counter);

                service.AddAccount(account1);
                service.AddAccount(account2);
                service.FillAccount(account1, 35);
                service.FillAccount(account2, 20);

                service.SaveToStorage();
                service.LoadFromStorage();
            }
        }
    }
}
