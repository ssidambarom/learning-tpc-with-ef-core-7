namespace Domain;

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

    public override string ToString() => $"Contacts ({Name}, {SurName}), has contact with {string.Join(",", Contacts.Select(c => (c.Name, c.SurName)))}";
}
