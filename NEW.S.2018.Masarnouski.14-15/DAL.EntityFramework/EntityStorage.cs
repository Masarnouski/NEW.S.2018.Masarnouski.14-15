using DAL.Interfaces.DTO;
using DAL.Interfaces.Interface;
using System;
using System.Collections.Generic;
using DAL.Exceptions;

namespace DAL.Entity
{
    public class EntityStorage : IStorage
    {
        AccountDTOContext db = new AccountDTOContext();

        public void Create(AccountDTO account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (!ReferenceEquals(db.Accounts.Find(account.Id), null))
            {
                throw new AccountAlreadyExistsException("Account with such ID already exists.");
            }

            db.Accounts.Add(account);
            db.SaveChanges();
        }
        

        public void Delete(AccountDTO account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            AccountDTO accountForDelete = db.Accounts.Find(account.Id);

            if (ReferenceEquals(accountForDelete, null))
            {
                throw new AccountNotFoundException("This account not found.");
            }

            db.Accounts.Remove(accountForDelete);
            db.SaveChanges();
        }

        public List<AccountDTO> GETLIST()
        {
            throw new NotImplementedException();
        }

        public AccountDTO Read(int id)
        {
            AccountDTO account = db.Accounts.Find(id);

            if (ReferenceEquals(account, null))
            {
                throw new AccountNotFoundException("Account with such ID not found.");
            }

            return account;
        }

        public void Update(AccountDTO account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            AccountDTO accountForUpdate = db.Accounts.Find(account.Id);

            if (ReferenceEquals(accountForUpdate, null))
            {
                throw new AccountNotFoundException("Account with such ID not found.");
            }

            db.Accounts.Remove(accountForUpdate);
            db.Accounts.Add(account);
            db.SaveChanges();
        }
    }
}
