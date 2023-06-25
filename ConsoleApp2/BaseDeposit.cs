using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class BaseDeposit : Deposit
    {
        public BaseDeposit(decimal Amount, int Period) : base(Amount, Period) { }

        public override decimal Income()
        {
            decimal totalAmount = Amount;

            for (int i = 0; i < Period; i++)
            {
                totalAmount += totalAmount * 0.05m;
            }

            return totalAmount - Amount;
        }
    }
}
