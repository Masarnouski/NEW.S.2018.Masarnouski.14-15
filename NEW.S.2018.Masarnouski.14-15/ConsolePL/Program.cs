using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.S._2018.Masarnouski._14_15
{
    class Program
    {
        static void Main()
        {
            BankAccount account1 = new BankAccount(1, "Eugene", "Masarnouski", 100, AccountType.Base);
            BankAccount account2 = new BankAccount(1, "Alesya", "Dzehachova", 200, AccountType.Gold);

            var counter = new BonusCounter();
            var storageFactory = new BinaryStorageFactory();
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
