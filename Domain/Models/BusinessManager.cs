namespace Domain;

public class BusinessManager : Employee
{
    public BusinessManager(string name, string surName)
        : base(name, surName)
    {
    }

    public ICollection<Customer> Portfolio { get; set; } = new List<Customer>();

    public override string ToString()
        => $"Manager ({Name}, {SurName}), manage the following customers: {string.Join(",", Portfolio.Select(p => (p.Name, p.SurName, p.CompanyName)))}";
}

