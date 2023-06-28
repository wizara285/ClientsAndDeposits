using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class SpecialDeposit : Deposit, IProlongable
    {
        public SpecialDeposit(decimal Amount, int Period) : base(Amount, Period) { }

        public override decimal Income()
        {
            decimal totalAmount = Amount;
            decimal percent = 0.01m;

            for (int i = 0; i < Period; i++)
            {
                totalAmount += totalAmount * percent;
                percent += 0.01m;
            }

            return totalAmount - Amount;
        }

        public bool CanToProlong()
        {
            if (Amount > 1000)
                return true;
            else return false;
        }
    }
}
