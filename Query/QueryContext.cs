using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Site")]
public class Site
{
    [Key]
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
}

[Table("Load")]
public class Load
{
    [Key]
    public int Id { get; set; }

    public string LoadNumber { get; set; } = "";
    public string SiteId { get; set; } = "";

    [ForeignKey(nameof(SiteId))]
    public Site? Site { get; set; }

    public IList<LineItem> LineItems { get; set; } = new List<LineItem>();
}

[Table("LineItem")]
public class LineItem
{
    [Key]
    public int Id { get; set; }
    public int LoadId { get; set;}
    public string Product { get; set; } = null!;
    public int Quantity { get; set; }
}

public class QueryContext : DbContext
{
    public DbSet<Site> Sites => Set<Site>();
    public DbSet<Load> Loads => Set<Load>();

    public QueryContext(DbContextOptions<QueryContext> options)
        :base(options)
    {

    }

    private static SqliteConnection _connection = new SqliteConnection("Filename=:memory:");

    public static QueryContext GetContext()
    {
        _connection.Open();

        var contextOptions = new DbContextOptionsBuilder<QueryContext>()
            .UseSqlite(_connection)
            .Options;

        // Create the schema and seed some data
        var context = new QueryContext(contextOptions);

        if (!context.Database.EnsureCreated())
            throw new Exception("DB Not Created!");

        context.Sites.Add(new Site { Id = "123", Name = "Test Site"});
        context.Loads.Add(new Load
        {
            Id = 1,
            LoadNumber = "12345",
            SiteId = "123",
            LineItems = new List<LineItem>
            {
                new LineItem { Id = 1, LoadId = 1, Product = "Something", Quantity = 100 },
                new LineItem { Id = 2, LoadId = 1, Product = "Other Thing", Quantity = 200 },
            }
        });

        context.SaveChanges();

        return context;
    }
}