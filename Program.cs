using SearchSalaryOfMonth.Entities.Enums;
using SearchSalaryOfMonth.Entities;
using System;
using System.Globalization;

namespace SearchSalaryOfMonth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter Departament's name: ");
            string departName = Console.ReadLine();
            Console.WriteLine("\nEnter Worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine()); 
            Console.Write("Base Salary: ");
            double sal = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Departament dep = new Departament(departName);
            Worker worker = new Worker(name, level, sal, dep);

            Console.Write("\nHow many contracts to this worker? ");
            int howManyContracts = int.Parse(Console.ReadLine());
            for(int i = 1; i <= howManyContracts; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Enter ({i}) contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new(date,value,hours);
                worker.AddContract(contract);
            }

            Console.Write("\nEnter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Departament: " + worker.Departament.Name);
            Console.WriteLine("Income for " + monthAndYear + ": $ " + worker.Income(month,year).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
