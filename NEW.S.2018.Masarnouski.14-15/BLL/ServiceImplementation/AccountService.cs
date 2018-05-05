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
        IStorage storage;
        AccountMapper mapper;

        public AccountService(IStorage storage,AccountMapper mapper)
        {
            this.mapper = mapper;
            this.storage = storage;
        }

        public void Create(BankAccount account)
        {
            storage.Create(mapper.ToDTOAccount(account));
        }

        public void Delete(BankAccount account)
        {
            storage.Delete(mapper.ToDTOAccount(account));
        }
        
        public void Update(BankAccount account)
        {
            storage.Update(mapper.ToDTOAccount(account));
        }

        public BankAccount Read(int id)
        {
            return mapper.ToBankAccount(storage.Read(id));
        }
        public void View()
        {
            foreach (var item in storage.GETLIST())
            {
                Console.WriteLine(mapper.ToBankAccount(item));
            }
            
        }
    }
}
