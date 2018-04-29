using Moq;
using NUnit.Framework;
using BLL.Interfaces.Entities;
using DAL.Interfaces.Interface;
using BLL.Interfaces.Interface;
using BLL.ServiceImplementation;
using BLL.Mappers;
using DAL.Interfaces.DTO;
using System.Collections.Generic;

namespace BLL.Tests
{
    [TestFixture]
    public class AcountServiseMoqTests
    { 
        [Test]
        public void OpenAccount_AddNewBankAccountTests()
        {
            Mock <IStorage> mockStorage = new Mock<IStorage>();
            Mock <IBonusCounter> mockCounter = new Mock<IBonusCounter>();
            Mock <AccountMapper> mockMapper = new Mock <AccountMapper>();
            IDGenerator generator = new IDGenerator();

            mockStorage
                .Setup(m => m.Load())
                .Returns(() =>
                {
                    return new List<AccountDTO>();
                });
            mockStorage
                .Setup(m => m.Save(It.IsAny<List<AccountDTO>>()));
            AccountService service = new AccountService(mockStorage.Object, mockCounter.Object, mockMapper.Object);
            service.Add(new BankAccount(1, "Eugene", "Masarnouski",1000,AccountType.Gold,500));
            service.Save();
            mockStorage.Verify(storage => storage.Save(It.IsAny<List<AccountDTO>>()));

        }
    }    
}