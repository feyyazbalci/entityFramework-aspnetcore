using System;

namespace _02.OpenClosed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SalaryCalculater hesapla = new SalaryCalculater( new SupportEmployee());
            hesapla.CalculateAllSalary();
        }
    }
    interface IEmployee
    {
        void Calculater();
    }
    class FullTimeEmployee : IEmployee
    {
        public void Calculater()
        {
            Console.WriteLine("Full Time Employee");
        }
    }
    class PartTimeEmployee : IEmployee
    {
        public void Calculater()
        {
            Console.WriteLine("Part Time Employee");
        }

    }
    class SupportEmployee : IEmployee
    {
        public void Calculater()
        {
            Console.WriteLine("Support Employee");
        }
    }
    class SalaryCalculater
    {
        private readonly IEmployee _employee;

        public SalaryCalculater(IEmployee employee)
        {

            _employee = employee;

        }
        public void CalculateAllSalary()
        {
            _employee.Calculater();
            
        }
    }
}
