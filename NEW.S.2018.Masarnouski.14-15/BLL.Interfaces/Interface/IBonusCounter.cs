using BLL.Interfaces.Entities;
namespace BLL.Interfaces.Interface
{
    public interface IBonusCounter
    {
        int GetBonusFromFill(BankAccount account, decimal amount);
        int GetBonusFromWithdraw(BankAccount account, decimal amount);
    }
}
