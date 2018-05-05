
using System.Configuration;
using System.Data.Entity;

namespace DAL.Interfaces.DTO
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class AccountDTOContext: DbContext
    {
        public AccountDTOContext():base(ConfigurationManager.ConnectionStrings["EntityConnection"].ConnectionString)
        {}

        public DbSet<AccountDTO> Accounts { get; set; }
    }
}
