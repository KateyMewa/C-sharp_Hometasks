namespace Aggregation
{
    class SpecialDeposit : Deposit
    {
        public SpecialDeposit(decimal depositAmount, int depositPeriod) : base(depositAmount, depositPeriod)
        {

        }
        public override decimal Income()
        {
            decimal inclIncome = Amount;
            for (int i = 1; i <= Period; i++)
            {
                inclIncome += (inclIncome / 100) * (Period - (Period - i));
            }
            return inclIncome - Amount;
        }
    }
}