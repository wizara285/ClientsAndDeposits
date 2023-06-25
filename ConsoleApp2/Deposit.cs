using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public abstract class Deposit : IComparable<Deposit>
    {
        public decimal Amount { get; }
        public int Period { get; }


        public Deposit(decimal Amount, int Period)
        {
            this.Amount = Amount;
            this.Period = Period;
        }

        public abstract decimal Income();

        public int CompareTo(Deposit other)
        {
            return (Amount + Income()).CompareTo(other.Amount + other.Income());
        }
    }
}
