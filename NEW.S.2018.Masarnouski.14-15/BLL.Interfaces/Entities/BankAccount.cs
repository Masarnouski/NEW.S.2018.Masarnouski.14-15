using BLL.Interfaces.Interface;
using System;

namespace BLL.Interfaces.Entities
{
    public class BankAccount : IBankAccount
    {
        #region fields
        private int id;
        private decimal balance;
        private string holderName;
        private string holderSurName;
        int bonus;
        IBonusCounter counter;

        #endregion

        #region Constructors

        public BankAccount(int id, string holderName, string holderSurName, decimal balance, AccountType type, int bonus)
        {
            this.Id = id;
            this.HolderName = holderName;
            this.HolderSurName = holderSurName;
            Type = type;
            Bonus = bonus;
            Balance = balance;
        }
        public BankAccount(int id, string holderName, string holderSurName, IBonusCounter counter, decimal balance, AccountType type, int bonus):this(id, holderName, holderSurName, balance, type,bonus)
        { 
            this.Counter = counter;
        }
        #endregion 

        #region Properties

        public AccountType Type { get; set; }

        public int Id
        {
            get { return this.id; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)}  must be greater than 0");
                }

                this.id = value;
            }
        }

        public string HolderName
        {
            get { return this.holderName; }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException($"{nameof(value)}");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException($"{nameof(value)} must be not empty");
                }

                this.holderName = value;
            }
        }
        public string HolderSurName
        {
            get { return this.holderSurName; }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException($"{nameof(value)}");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException($"{nameof(value)} must be not empty");
                }

                this.holderSurName = value;
            }
        }

        public decimal Balance
        {
            get { return this.balance; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)}  must be greater than 0");
                }

                this.balance = value;
            }
        }

        public int Bonus
        {
            get { return this.bonus; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)}  must be greater than 0");
                }

                this.bonus = value;
            }
        }

        public IBonusCounter Counter {
            get => counter;
            set
            {
                if (ReferenceEquals(value,null))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                counter = value;
            }
        }
        #endregion

        #region Methods
        public void Fill(decimal amount)
        {
            SetBonus(Counter.GetBonusFromFill(this,amount));
            FillNative(amount);
        }
        public void Withdraw(decimal amount)
        {
            SetBonus(Counter.GetBonusFromWithdraw(this, amount));
            WithdrawNative(amount);
        }

        private void SetBonus(int bonus)
        {
            if (bonus < 0)
            {
                throw new ArgumentOutOfRangeException($"Bonus{nameof(bonus)} must be greater than 0.");
            }

            Bonus += bonus;
        }

        private void FillNative(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount to fill must be greater or equal to 0");
            }
            Balance += amount;
        }
        private void WithdrawNative(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount to withdraw must be greater or equal to 0");
            }
            Balance -= amount;
        }
        public override string ToString()
        {
            return $"id = {this.Id} , name = {this.HolderName}, surname = {HolderSurName}," +
                $" balanse = {this.balance}, bonus points = {this.Bonus}";
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                throw new ArgumentNullException(nameof(obj));

            if (this.GetType() != obj.GetType())
                throw new ArgumentException($"{obj} has a wrong type");

            BankAccount account = (BankAccount)obj;
            return this.Id == account.Id && this.HolderName == account.HolderName && this.HolderSurName == account.HolderSurName;
        }
        #endregion
    }

}
