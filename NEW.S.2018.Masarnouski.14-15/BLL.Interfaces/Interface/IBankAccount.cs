using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Interface
{
    interface IBankAccount
    {
        void SetBonus(int bonus);
        void Fill(decimal amount);
        void Withdraw(decimal amount);
    }
}
