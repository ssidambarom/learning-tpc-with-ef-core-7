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
