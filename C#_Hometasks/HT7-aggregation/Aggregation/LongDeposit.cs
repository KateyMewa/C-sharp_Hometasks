using System;
namespace Aggregation
{
    class LongDeposit : Deposit
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
            //decimal diff;
            //decimal inclIncome = Amount;
            //if (Period > 6)
            //{
            //    for (int i = 1; i <= Period - 6; i++)
            //    {
            //        inclIncome += (inclIncome / 100) * 15;
            //    }
            //    diff = inclIncome - Amount;
            //}
            //else
            //{
            //    diff = 0;
            //}
            //return diff;
        }
    }
}