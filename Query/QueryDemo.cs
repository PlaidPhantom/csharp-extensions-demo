using Microsoft.EntityFrameworkCore;
using System.Text.Json;

public static class QueryDemo
{
    public static void Run()
    {
        using var context = QueryContext.GetContext();

        var load = context.Loads
            .AsNoTracking()
            .Where(l => l.Id == 1)
            .Single();

        Console.WriteLine("Found Bare Load:");
        Console.WriteLine(JsonSerializer.Serialize(load, new JsonSerializerOptions { WriteIndented = true }));
        
        Console.WriteLine("Press Enter to Continue...");
        Console.ReadLine();

        var load2 = context.Loads
            .AsNoTracking()
            .Include(load => load.Site)
            .Include(load => load.LineItems)
            .Where(l => l.Id == 1)
            .Single();

        Console.WriteLine("Found Load with explicit Includes:");
        Console.WriteLine(JsonSerializer.Serialize(load2, new JsonSerializerOptions { WriteIndented = true }));

        Console.WriteLine("Press Enter to Continue...");
        Console.ReadLine();

        var load3 = context.Loads
            .AsNoTracking()
            .WithEverything()
            .Where(l => l.Id == 1)
            .Single();

        Console.WriteLine("Found Load with extension method \"WithEverything\":");
        Console.WriteLine(JsonSerializer.Serialize(load3, new JsonSerializerOptions { WriteIndented = true }));
 
        Console.WriteLine("Press Enter to Continue...");
        Console.ReadLine();

        var load4 = context.Loads.AsNoTracking().WithEverythingById(1);

        Console.WriteLine("Found Load with extension method \"WithEverythingById\":");
        Console.WriteLine(JsonSerializer.Serialize(load4, new JsonSerializerOptions { WriteIndented = true }));
   }
}