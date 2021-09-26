using System;
namespace Aggregation
{
    class BaseDeposit : Deposit
    {

        public BaseDeposit(decimal depositAmount, int depositPeriod) : base(depositAmount, depositPeriod)
        {

        }
        public override decimal Income()
        {
            return Amount * (decimal)Math.Pow(1.05, Period) - Amount;
            //decimal diff;
            //decimal inclIncome = Amount;
            //for (int i = 1; i <= Period; i++)
            //{
            //    inclIncome += (inclIncome / 100) * 5;
            //}
            //diff = inclIncome - Amount;
            //return diff;
        }
    }
}