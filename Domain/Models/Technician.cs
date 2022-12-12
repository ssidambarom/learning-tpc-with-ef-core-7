namespace Domain;

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

    public override string ToString() => $"Technician ({Name}, {SurName}), has expertise on {Expertise}.";
}

