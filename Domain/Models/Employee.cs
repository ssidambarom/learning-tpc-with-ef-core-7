namespace Domain;

public abstract class Employee : Person
{
    protected Employee(string name, string surName)
        : base(name, surName)
    {
    }

    public int EmployeeId { get; set; }
}

