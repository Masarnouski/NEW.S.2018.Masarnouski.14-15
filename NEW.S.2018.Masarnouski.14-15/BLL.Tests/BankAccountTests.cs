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
    public class BankAccountTests
    {
        [Test]
        public void BankAccount_FillTests()
        {
            Mock <IBonusCounter> mockCounter = new Mock<IBonusCounter>();
            mockCounter.Setup(m => m.GetBonusFromFill(It.IsAny<BankAccount>(), 1000)).Returns(100);
            BankAccount account = new BankAccount(1, "Eugene", "Masarnouski",mockCounter.Object, 1000, AccountType.Base, 50);
            account.Fill(1000);
            mockCounter.Verify();
        }
        [Test]
        public void BankAccount_WithdrawalTests()
        {
            Mock<IBonusCounter> mockCounter = new Mock<IBonusCounter>();
            mockCounter.Setup(m => m.GetBonusFromWithdraw(It.IsAny<BankAccount>(), 500)).Returns(62);
            BankAccount account = new BankAccount(1, "Eugene", "Masarnouski", mockCounter.Object, 1000, AccountType.Base, 50);
            account.Withdraw(500);
            mockCounter.Verify();
        }
    }
}
