using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DTO
{

    public class AccountDTO
    {
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
        /// Size of money on a bank account.
        /// </summary>
        /// 
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