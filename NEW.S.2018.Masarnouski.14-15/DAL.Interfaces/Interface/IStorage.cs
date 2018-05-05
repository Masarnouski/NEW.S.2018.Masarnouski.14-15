using DAL.Interfaces.DTO;
using System;
using System.Collections.Generic;


namespace DAL.Interfaces.Interface
{
    public interface IStorage
    {
        void Create(AccountDTO account);
        AccountDTO Read(int id);
        void Update(AccountDTO account);
        void Delete(AccountDTO account);
        List<AccountDTO> GETLIST();
    }
}
