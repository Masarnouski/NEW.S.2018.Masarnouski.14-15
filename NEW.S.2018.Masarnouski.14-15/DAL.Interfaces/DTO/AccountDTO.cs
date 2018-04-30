

namespace DAL.Interfaces.DTO
{
    public class AccountDTO
    {
        public AccountDTO() { }
        public AccountDTO(int id, string holderName, string holderSurName,decimal balance, int bonus, int type)
        {
            this.Id = id;
            this.HolderName = holderName;
            this.HolderSurName = holderSurName;
            this.Balance = balance;
            this.Bonus = bonus;
            this.Type = type;
        }
        /// <summary>
        /// The identifier of the bank account.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The holder of the bank account.
        /// </summary>
        public string HolderName { get; set; }

        /// <summary>
        /// The holder of the bank account.
        /// </summary>
        public string HolderSurName { get; set; }
        
        /// <summary>
        /// Amount of money on a bank account.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// The bank account's bonus points
        /// </summary>
        public int Bonus { get; set; }

        /// <summary>
        /// The type of the bank account.
        /// </summary>
        public int Type { get; set; }
    }
}