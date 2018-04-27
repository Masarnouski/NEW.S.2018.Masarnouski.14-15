using DAL.Interfaces.DTO;
using BLL.Interfaces.Entities;

namespace BLL.Mappers
{
    class AccountMapper
    {
        public AccountDTO ToAccount(BankAccount bankAccount)
        {
            return new AccountDTO()
            {
                Id = bankAccount.Id,
                HolderName = bankAccount.HolderName,
                HolderSurName = bankAccount.HolderSurName,
                Balance = bankAccount.Balance,
                Bonus = bankAccount.Bonus,
                Type = (int)bankAccount.Type
            };
        }

        public BankAccount ToBankAccount(AccountDTO accountDTO)
        {
            return new BankAccount(accountDTO.Id, accountDTO.HolderName, accountDTO.HolderSurName,
                accountDTO.Balance, (AccountType)accountDTO.Type, accountDTO.Bonus);
        }
    }
}
   
