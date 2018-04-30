using System;
using System.Linq;
using System.Collections.Generic;
using BLL.Interfaces.Entities;
using DAL.Interfaces.Interface;
using BLL.Interfaces.Interface;
using BLL.Mappers;

namespace BLL.ServiceImplementation
{
    public class AccountService: IAccountService
    {
        private List<BankAccount> accountsList;
        IStorage storage;
        AccountMapper mapper;

        public AccountService(IStorage storage,AccountMapper mapper)
        {
            this.mapper = mapper;
            this.storage = storage;
            accountsList = new List<BankAccount>();
            Load();
        }

        public void Add(BankAccount account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }
            if (accountsList.Contains(account))
                throw new Exception("This account is alrady exists");
            else
                accountsList.Add(account);
        }

        public void Remove(BankAccount account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }
            if (accountsList.Contains(account))
            {
                accountsList.Remove(account);
            }
            else
                throw new Exception("This account is alrady exists");
        }
        
        public void Load()
        {
           accountsList = storage.Load().Select(m => mapper.ToBankAccount(m)).ToList();
        }

        public void Save()
        {
            storage.Save(accountsList.Select(m => mapper.ToDTOAccount(m)).ToList());
            accountsList.Clear();
        }
        public void View()
        {
            foreach (var item in accountsList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
