using DAL.Exceptions;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class Storage : IStorage
    {
        private List<AccountDTO> accountsList;
        public Storage()
        {
            accountsList = new List<AccountDTO>();
        }
        public Storage(IEnumerable <AccountDTO> accountsList)
        {
            this.accountsList = accountsList.ToList();
        }

        public void Create(AccountDTO account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }
            if (!accountsList.Exists(n => n.Id == account.Id))
            {
                accountsList.Add(account);
            }
            else
            {
                throw new AccountAlreadyExistsException("Such account have already exists");
            }
        }

        public void Delete(AccountDTO account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }
            if (accountsList.Exists(n => n.Id == account.Id))
            {
                accountsList.Remove(accountsList.Find(n => n.Id == account.Id));
            }
            else
            {
                throw new AccountNotFoundException("Such account haven't  exist");
            }
        }

        public AccountDTO Read(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException($"nameof(id) must be grater then zero");
            }
            if (!accountsList.Exists(n => n.Id == id))
            {
                throw new AccountNotFoundException();
            }
            return accountsList.Find(n => n.Id == id);
        }

        public void Update(AccountDTO account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (!accountsList.Exists(n => n.Id == account.Id))
            {
                throw new AccountNotFoundException("Account with such ID not found.");
            }

            accountsList.Remove(accountsList.Find(n => n.Id == account.Id));
            accountsList.Add(account);
        }
        public List<AccountDTO> GETLIST()
        {
            return accountsList;
        }
      
    }
}
