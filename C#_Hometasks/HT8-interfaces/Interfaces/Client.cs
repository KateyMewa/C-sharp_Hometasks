using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Interfaces
{
    class Client : IEnumerable<Deposit>
    {
        private readonly Deposit[] deposits;

        public Client()
        {
            deposits = new Deposit[10];
        }

        public bool AddDeposit(Deposit deposit)
        {
            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] == null)
                {
                    deposits[i] = deposit;
                    return true;
                }
            }
            return false;
        }

        public decimal TotalIncome()
        {
            decimal total = 0m;
            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] != null)
                {
                    total += deposits[i].Income();
                }
            }
            return total;
        }

        public decimal MaxIncome()
        {
            decimal max = 0;
            foreach (var deposit in deposits.Where(n => n != null))
            {
                if (deposit.Income() > max)
                {
                    max = deposit.Income();
                }
            }
            return max;
        }

        public decimal GetIncomeByNumber(int number)
        {
            if (deposits[number - 1] == null)
            {
                return 0;
            }
            else
            {
                return deposits[number - 1].Income();
            }
        }

        public void SortDeposits()
        {
            Array.Sort(deposits, (a, b) => a == null ? 1 : b == null ? -1 : b.CompareTo(a));
        }

        public int CountPossibleToProlongDeposit()
        {
            return deposits.Count(d => d != null && d is IProlongable ? (d as IProlongable).CanToProlong() : false);
        }

        public IEnumerator<Deposit> GetEnumerator()
        {
            return ((IEnumerable<Deposit>)deposits).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return deposits.GetEnumerator();
        }
    }
}