namespace SearchSalaryOfMonth.Entities
{
    public class Departament
    {
        public string Name { get; private set; }

        public Departament() 
        {
        }
        public Departament(string name)
        {
            Name = name;
        }
    }
}
