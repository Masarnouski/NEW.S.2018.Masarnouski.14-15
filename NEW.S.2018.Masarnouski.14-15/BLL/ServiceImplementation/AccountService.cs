using System;
using System.Collections.Generic;
using BLL.Interfaces.Entities;
using DAL.Interfaces.Interface;
using BLL.Interfaces.Interface;

namespace BLL
{
    public class AccountService
    {
        private readonly List<BankAccount> accountsList;
        IStorage storage;
        IBonusCounter bonusCounter;
        public AccountService(IStorageFactory storage, IBonusCounter bonusCounter)
        {
            this.storage = storage;
            this.bonusCounter = bonusCounter;
            accountsList = storage.GetInstance().Load();
        }

        public void AddAccount(BankAccount account)
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

        public void RemoveAccount(BankAccount account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }
            if (accountsList.Contains(account))
            {
                accountsList.Remove(account);
                storage.GetInstance().Save(accountsList);
            }
            else
                throw new Exception("This account is alrady exists");
        }
        public void FillAccount(BankAccount account, decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount to fill must be greater or equal to 0");
            }
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (!accountsList.Contains(account))
            {
                throw new ArgumentException("This bank account not found.");
            }
            account.SetBonus(bonusCounter.GetBonusFromWithdraw(account, amount));
            account.Fill(amount);
        }
        public void WithdrawAccount(BankAccount account, decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount to fill must be greater or equal to 0");
            }
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (!accountsList.Contains(account))
            {
                throw new ArgumentException("This bank account not found.");
            }

            account.SetBonus(bonusCounter.GetBonusFromWithdraw(account, amount));
            account.Withdraw(amount);
        }
        public void LoadFromStorage()
        {
            storage.GetInstance().Load();
        }

        public void SaveToStorage()
        {
            storage.GetInstance().Save(accountsList);
        }

    }
}
