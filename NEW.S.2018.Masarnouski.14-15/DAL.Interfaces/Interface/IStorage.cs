using DAL.Interfaces.DTO;
using System;
using System.Collections.Generic;


namespace DAL.Interfaces.Interface
{
    public interface IStorage
    {
        List<AccountDTO> Load();
        void Save(List<AccountDTO> accountsList);
    }
}
