using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class LongDeposit : Deposit, IProlongable
    {
        public LongDeposit(decimal Amount, int Period) : base(Amount, Period) { }

        public override decimal Income()
        {
            decimal totalAmount = Amount;

            for (int i = 0; i <= Period; i++)
            {
                if (i > 6)
                    totalAmount += totalAmount * 0.15m;
            }

            return totalAmount - Amount;
        }

        public bool CanToProlong()
        {
            if (Period < 36)
                return true;
            else return false;
        }
    }
}
