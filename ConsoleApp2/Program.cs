using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Deposit deposit_1 = new BaseDeposit(5000, 12);
            Deposit deposit_2 = new LongDeposit(5000, 12);
            Deposit deposit_3 = new SpecialDeposit(5000, 12);

            Client client = new Client(deposit_1);

            client.AddDeposit(deposit_2);
            client.AddDeposit(deposit_3);


            foreach (var deposit in client)
            {
                if (deposit != null)
                    Console.WriteLine("{0:#.##}", deposit.Income());
            }
            Console.WriteLine();

            //Console.WriteLine("Max Income is {0:#.##}", client.MaxIncome());
            //Console.WriteLine("Income of first deposit is {0:#.##}", client.GetIncomeByNumber(1));

            //client.SortDeposits();

            //foreach (var deposit in client)
            //{
            //    if (deposit != null)
            //        Console.WriteLine("{0:#.##}", deposit.Income());
            //}
        }
    }
}