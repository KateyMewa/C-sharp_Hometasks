using System;
namespace Interfaces
{
    class BaseDeposit : Deposit
    {

        public BaseDeposit(decimal depositAmount, int depositPeriod) : base(depositAmount, depositPeriod)
        {

        }
        public override decimal Income()
        {
            return Amount * (decimal)Math.Pow(1.05, Period) - Amount;
        }
    }
}