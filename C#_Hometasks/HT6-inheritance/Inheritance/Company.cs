using System;
using System.Collections.Generic;
using System.Text;


namespace InheritanceTask
{
    class Company
    {
        private readonly Employee[] employees;

        public Company(Employee[] employees)
        {
            this.employees = employees;
        }
        public void GiveEverybodyBonus(decimal companyBonus)
        {
            foreach (var employee in employees)
            {
                employee.SetBonus(companyBonus);
            }
        }
        public decimal TotalToPay()
        {
            decimal sum = 0;
            foreach (var employee in employees)
            {
                decimal prev = employee.ToPay();
                sum += prev;
            }
            return sum;
        }
        public string NameMaxSalary()
        {
            decimal maxSalary = 0;
            string name = null;
            foreach (var employee in employees)
            {
                if (employee.ToPay() > maxSalary)
                {
                    maxSalary = employee.ToPay();
                    name = employee.Name;
                }
            }
            return name;
        }
    }
}
