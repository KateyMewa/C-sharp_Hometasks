using Interfaces;
namespace Interfaces
{
    class SpecialDeposit : Deposit, IProlongable
    {
        public SpecialDeposit(decimal depositAmount, int depositPeriod) : base(depositAmount, depositPeriod)
        {

        }

        public override decimal Income()
        {
            decimal inclIncome = Amount;
            for (int i = 1; i <= Period; i++)
            {
                inclIncome += (inclIncome / 100) * i;
            }
            return inclIncome - Amount;
        }

        public bool CanToProlong()
        {
            return Amount > 1000;
        }
    }
}