using System.Security.Claims;
using System.Text.Json;

public static class PrincipalDemo
{
    public static void Run()
    {
        var user = new ClaimsPrincipal(new ClaimsIdentity(new []
        {
            new Claim(ClaimTypes.Name, "William Taft"),
            new Claim(PrincipalExtensions.SITE_CLAIM_TYPE, "123"),
            new Claim(PrincipalExtensions.SITE_CLAIM_TYPE, "456"),
            new Claim(ClaimTypes.Role, "siteuser"),
            new Claim(ClaimTypes.Role, "sitemanager")
        }));

        Console.WriteLine($"Information on user {user.Identity?.Name}");

        var allSites = user.GetSites();
        Console.WriteLine($"Available Sites: {JsonSerializer.Serialize(allSites)}");

        Console.WriteLine($"Has Site 123: {user.HasSite("123")}");
        Console.WriteLine($"Has Site 789: {user.HasSite("789")}");
    }
}