
using System.Configuration;
using System.Data.Entity;

namespace DAL.Interfaces.DTO
{
    public class AccountDTOContext: DbContext
    {
        public AccountDTOContext() : base()
        {}

        public DbSet<AccountDTO> Accounts { get; set; }
    }
}
