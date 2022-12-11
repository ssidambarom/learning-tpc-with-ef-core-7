using Microsoft.EntityFrameworkCore;

namespace Domain;

public static class DbContextExentions
{
    public static async Task Seed<TContext>()
        where TContext : PersonContext, new()
    {
        using var context = new TContext();

        await context.Database.EnsureDeletedAsync();

        Console.WriteLine(context.Model.ToDebugString());
        Console.WriteLine();

        await context.Database.EnsureCreatedAsync();
        var entitiesToSave = new List<object>();

        var index = 0;

        var client1 = new Customer($"CustomerName{index}", $"CustomerSurname{index}", $"Company{index++}");
        var client2 = new Customer($"CustomerName{index}", $"CustomerSurname{index}", $"Company{index++}");
        var client3 = new Customer($"CustomerName{index}", $"CustomerSurname{index}", $"Company{index++}");

        var manager1 = new BusinessManager($"ManagerName{index}", $"ManagerSurname{index++}");
        manager1.Portfolio.Add(client1);
        manager1.Portfolio.Add(client2);

        var manager2 = new BusinessManager($"ManagerName{index}", $"ManagerSurname{index++}");
        manager2.Portfolio.Add(client3);

        entitiesToSave.Add(new Technician($"TechnicianName{index}", $"TechnicianSurname{index++}", "Logistic"));
        entitiesToSave.Add(new Technician($"TechnicianName{index}", $"TechnicianSurname{index++}", "Cloud"));
        entitiesToSave.Add(new Technician($"TechnicianName{index}", $"TechnicianSurname{index++}", "Support"));

        entitiesToSave.Add(new BusinessManager($"ManagerName{index}", $"ManagerSurname{index++}"));
        entitiesToSave.Add(new BusinessManager($"ManagerName{index}", $"ManagerSurname{index++}"));

        await context.AddRangeAsync(entitiesToSave);
        await context.SaveChangesAsync();
    }

    public static async Task ReadAllDb<TContext>()
        where TContext : PersonContext, new()
    {
        using var context = new TContext();

        Console.WriteLine("All employees:");
        foreach (var employee in await context.Employees.ToListAsync())
        {
            Console.WriteLine($"   >> {employee}");
        }

        Console.WriteLine("All customers:");
        foreach (var customer in await context.Customers.ToListAsync())
        {
            Console.WriteLine($"   >> {customer}");
        }

        Console.WriteLine("All manager:");
        foreach (var manager in await context.Managers.ToListAsync())
        {
            Console.WriteLine($"   >> {manager}");
        }

        Console.WriteLine("All technician:");
        foreach (var technician in await context.Technicians.ToListAsync())
        {
            Console.WriteLine($"   >> {technician}");
        }
    }
}