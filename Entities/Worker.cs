using SearchSalaryOfMonth.Entities.Enums;
using System.Collections.Generic;

namespace SearchSalaryOfMonth.Entities
{
    public class Worker
    {
        public string Name { get; private set; }
        public WorkerLevel Level { get; private set; }
        public double BaseSalary { get; private set; }
        public Departament Departament { get; private set; }
        public List<HourContract> Contracts { get; private set; } = new List<HourContract>();

        public Worker(string name, WorkerLevel level, double salary, Departament departament) 
        {
            Name = name;
            Level = level;
            BaseSalary = salary;
            Departament = departament;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }
        public double Income(int month, int year) 
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts)
            {
                if(contract.Date.Month == month && contract.Date.Year == year)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }
    }
}
