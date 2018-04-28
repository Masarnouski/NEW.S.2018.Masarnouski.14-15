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
            Resolver.ConfigurateResolver(); ;
        }

        static void Main(string[] args)
        {
            IIDGenerator generator = Resolver.Get<IIDGenerator>();
            IAccountService service = Resolver.Get<IAccountService>();

            BankAccount account1 = new BankAccount(generator.GenerateId(), "Eugene", "Masarnouski", 100, AccountType.Base);
            BankAccount account2 = new BankAccount(generator.GenerateId(), "Alesya", "Dzehachova", 200, AccountType.Gold);
            BankAccount account3 = new BankAccount(generator.GenerateId(), "Vitaliy", "Masarnouski", 200, AccountType.Gold);
            service.Add(account1);
            service.Add(account2);
            service.Add(account3);
            
            Console.WriteLine(account1);
            Console.WriteLine(account2);
            Console.WriteLine(account3);
            Console.ReadLine();

            service.Save();
            service.View();
            Console.ReadLine();

            service.Load();
            service.View();
            Console.ReadLine();

            service.Save();
            service.View();
            Console.ReadLine();

            Console.ReadLine();
        }
    }
}
   
