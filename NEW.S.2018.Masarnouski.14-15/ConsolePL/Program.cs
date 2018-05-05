using BLL.Interfaces.Entities;
using BLL.Interfaces.Interface;
using Ninject;
using DependencyResolver;
using System;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel Resolver;
        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolver(); 
        }

        static void Main(string[] args)
        {
            IIDGenerator generator = Resolver.Get<IIDGenerator>();
            IAccountService service = Resolver.Get<IAccountService>();
            IBonusCounter counter = Resolver.Get<IBonusCounter>();

            BankAccount account1 = new BankAccount(generator.GenerateId(), "Eugene", "Masarnouski",counter, 1000, AccountType.Base,0);
            BankAccount account2 = new BankAccount(generator.GenerateId(), "Alesya", "Dzehachova",counter, 200, AccountType.Gold,0);
            BankAccount account3 = new BankAccount(generator.GenerateId(), "Vitaliy", "Masarnouski",counter, 200, AccountType.Premium,0);

            service.Create(account1);
            service.Create(account2);
            service.Create(account3);

            service.View();
            Console.ReadLine();
            service.Delete(account2);
            BankAccount account4 = new BankAccount(0, "AlesyaNEW", "DzehachovaNEW", counter, 200, AccountType.Gold, 0);
            service.Update(account4);

            service.View();
            Console.ReadLine();

            //account1.Fill(1000);
            //account2.Fill(1000);
            //account3.Fill(1000);

        }
    }
}
   
