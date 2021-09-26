using System;
using Interfaces;
namespace Interfaces
{
    class LongDeposit : Deposit, IProlongable
    {
        public LongDeposit(decimal depositAmount, int depositPeriod) : base(depositAmount, depositPeriod)
        {

        }

        public override decimal Income()
        {
            if (Period > 6)
            {
                return Amount * (decimal)(Math.Pow((1.15), (Period - 6))) - Amount;
            }
            return 0;
        }

        public bool CanToProlong()
        {
            return Period <= 36;
        }
    }
}