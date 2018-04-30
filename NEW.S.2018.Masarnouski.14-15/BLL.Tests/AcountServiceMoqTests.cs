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
        public void IStorage_Save_LoadTests()
        {
            Mock<IStorage> mockStorage = new Mock<IStorage>();

            mockStorage
                .Setup(m => m.Load())
                .Returns(() =>
                {
                    return new List<AccountDTO>();
                });
            mockStorage
                .Setup(m => m.Save(It.IsAny<List<AccountDTO>>()));
            mockStorage.Verify();
        }

        [Test]
        public void IBonusCounter_GetBonusFromFill_GetBonusFromWithdrawTests()
        {
            Mock<IBonusCounter> mockBonusCounter = new Mock<IBonusCounter>();

            mockBonusCounter
               .Setup(m => m.GetBonusFromFill(It.IsAny<BankAccount>(), It.IsAny<decimal>()))
               .Returns(It.IsAny<int>());
            mockBonusCounter
              .Setup(m => m.GetBonusFromWithdraw(It.IsAny<BankAccount>(), It.IsAny<decimal>()))
              .Returns(It.IsAny<int>());

            mockBonusCounter.Verify();
        }

        [Test]
        public void AccountService_Storage_And_BonusCounter_FunctionalTests()
        {
            Mock<IStorage> mockStorage = new Mock<IStorage>();
            mockStorage
               .Setup(m => m.Load())
               .Returns(() =>
               {
                   return new List<AccountDTO>();
               });
            Mock<IBonusCounter> mockCounter = new Mock<IBonusCounter>();
            Mock<AccountMapper> mockMapper = new Mock<AccountMapper>();
            AccountService service = new AccountService(mockStorage.Object, mockMapper.Object);
            mockStorage.Verify();
            BankAccount account = new BankAccount(1, "Eugene", "Masarnouski", 1000, AccountType.Base, 0);
            service.Add(account);
            mockStorage.Verify();
        }
    }
}