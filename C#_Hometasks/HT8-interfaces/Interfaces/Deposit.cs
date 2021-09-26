using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Interfaces
{
    public abstract class Deposit : IComparable<Deposit>
    {
        public decimal Amount { get; }
        public int Period { get; }

        public Deposit(decimal depositAmount, int depositPeriod)
        {
            this.Amount = depositAmount;
            this.Period = depositPeriod;
        }

        public abstract decimal Income();

        public int CompareTo(Deposit other)
        {
            return (Income()+Amount).CompareTo(other.Income() + other.Amount);
        }
    }
}