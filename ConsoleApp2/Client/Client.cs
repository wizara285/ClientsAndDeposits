using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace Interfaces
{
    public class Client : IEnumerable<Deposit>
    {
        private List<Deposit> Deposits { get; }
        public int AmountSpecialDeposits
        {
            get
            {
                int countDeposits = 0;
                foreach (var deposit in Deposits)
                {
                    if (deposit != null && deposit is SpecialDeposit)
                        countDeposits++;
                }
                return countDeposits;
            }
        }
        public int AmountBaseDeposits
        {
            get
            {
                int countDeposits = 0;
                foreach (var deposit in Deposits)
                {
                    if (deposit != null && deposit is BaseDeposit)
                        countDeposits++;
                }
                return countDeposits;
            }
        }
        public int AmountLongDeposits
        {
            get
            {
                int countDeposits = 0;
                foreach (var deposit in Deposits)
                {
                    if (deposit != null && deposit is LongDeposit)
                        countDeposits++;
                }
                return countDeposits;
            }
        }



        public Client() { }

        public Client(List<Deposit> deposits)
        {
            Deposits = deposits;
        }

        public Client(params Deposit[] deposits)
        {
            Deposits = deposits.ToList<Deposit>();
        }


        public void AddDeposit(Deposit deposit)
        {
            Deposits.Add(deposit);
        }

        public decimal TotalIncome()
        {
            decimal totalIncome = 0;
            foreach (Deposit deposit in Deposits)
            {
                if (deposit != null)
                    totalIncome += deposit.Income();
            }
            return totalIncome;
        }

        public decimal MaxIncome()
        {
            decimal maxIncome = -79228162514264337593543950335M;

            foreach (Deposit deposit in Deposits)
            {
                if (deposit != null && deposit.Income() > maxIncome)
                {
                    maxIncome = deposit.Income();
                }
            }
            return maxIncome;
        }

        public decimal GetIncomeByNumber(int n)
        {
            if (Deposits[n - 1] != null)
                return Deposits[n - 1].Income();
            else return 0;
        }

        public IEnumerator<Deposit> GetEnumerator()
        {
            foreach (Deposit deposit in Deposits)
            {
                yield return deposit;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void SortDeposits()
        {
            Deposits.Sort();
        }

        public int CountPossibleToProlongDeposit()
        {
            int DepositsThatCanBeProlonged = 0;

            foreach (Deposit deposit in Deposits)
            {
                if (deposit is IProlongable && (deposit as IProlongable).CanToProlong())
                {
                    DepositsThatCanBeProlonged++;
                }
            }

            return DepositsThatCanBeProlonged;
        }

        
    }
}
