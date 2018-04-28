using System;

namespace BLL.Interfaces.Entities
{
    public class BankAccount
    {
        #region fields
        private int id;
        private decimal balance;
        private string holderName;
        private string holderSurName;
        int bonus;

        #endregion

        #region Constructors
        public BankAccount(int id, string holderName, string holderSurName)
        {
            this.id = id;
            this.holderName = holderName;
            this.holderSurName = holderSurName;
            Type = 0;
            Bonus = 0;
        }
        public BankAccount(int id, string holderName, string holderSurName, decimal balance) : this(id, holderName, holderSurName)
        {
            this.balance = balance;
        }
        public BankAccount(int id, string holderName, string holderSurName, decimal balance, AccountType type) : this(id, holderName, holderSurName,balance)
        {
            Type = type;
        }
        public BankAccount(int id, string holderName, string holderSurName, decimal balance, AccountType type, int bonus):this(id, holderName, holderSurName, balance, type)
        {
            Bonus = bonus;
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
        #endregion

        #region Methods

        public void SetBonus(int bonus)
        {
            if (bonus < 0)
            {
                throw new ArgumentOutOfRangeException($"Bonus{nameof(bonus)} must be greater than 0.");
            }

            Bonus += bonus;
        }

        public void Fill(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount to fill must be greater or equal to 0");
            }
            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount to fill must be greater or equal to 0");
            }
            Balance -= amount;
        }
        public override string ToString()
        {
            return $"id = {this.Id} , name = {this.HolderName}, surname = {HolderSurName}, balanse = {this.balance}, bonus points = {this.Bonus}";
        }
        #endregion
    }
}
