namespace Domain;
public abstract class Person
{
    protected Person(string name, string surName)
    {
        Name = name;
        SurName = surName;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
}


public abstract class Employee : Person
{
    protected Employee(string name, string surName)
        : base(name, surName)
    {
    }

    public int EmployeeId { get; set; }
}

public class BusinessManager : Employee
{
    public BusinessManager(string name, string surName)
        : base(name, surName)
    {
    }

    public ICollection<Customer> Portfolio { get; set; } = new List<Customer>();

    public override string ToString() => $"Manager ";
}

public class Technician : Employee
{
    public Technician(string name,
                      string surName,
                      string expertise)
        : base(name, surName)
    {
        Expertise = expertise;
    }

    public string Expertise { get; set; }
}

public class Customer : Person
{
    public Customer(string name,
                    string surName,
                    string companyName)
        : base(name, surName)
    {
        this.CompanyName = companyName;
    }

    public string CompanyName { get; set; }
    public ICollection<BusinessManager> Contacts { get; set; } = new List<BusinessManager>();
}

