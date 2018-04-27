using BLL.Interfaces.Interfaces;
using System;


namespace BLL.Interfaces.Entities
{
    class BonusCounter
    {
        public class BonusCounter : IBonusCounter
        {
            public decimal FillPrice { get; private set; }

            public decimal WithdrawPrice { get; private set; }

            public void SetBonusPrice(BankAccount account)
            {
                AccountType type = account.Type;
                switch (type)
                {
                    case AccountType.Base:
                        {
                            FillPrice = 10;
                            WithdrawPrice = 8;
                            break;
                        }

                    case AccountType.Gold:
                        {
                            FillPrice = 8;
                            WithdrawPrice = 6;
                            break;
                        }

                    case AccountType.Premium:
                        {
                            FillPrice = 6;
                            WithdrawPrice = 8;
                            break;
                        }
                    default:
                        {
                            throw new ArgumentException("No such type of bank account.", nameof(type));
                        }
                }
            }
            public int GetBonusFromFill(BankAccount account, decimal amount)
            {
                SetBonusPrice(account);
                decimal result = amount / FillPrice;
                return (int)result;
            }

            public int GetBonusFromWithdraw(BankAccount account, decimal amount)
            {
                SetBonusPrice(account);
                decimal result = amount / WithdrawPrice;
                return (int)result;
            }
        }
    }
}
