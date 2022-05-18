using Microsoft.EntityFrameworkCore;

public static class QueryExtensions
{
    public static IQueryable<Load> WithEverything(this IQueryable<Load> query)
    {
        return query
            .Include(load => load.Site)
            .Include(load => load.LineItems);
    }


    public static Load WithEverythingById(this IQueryable<Load> query, int loadId)
    {
        return query
            .Include(load => load.Site)
            .Include(load => load.LineItems)
            .Where(l => l.Id == 1)
            .Single();
    }
}