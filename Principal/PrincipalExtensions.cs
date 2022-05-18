using System.Security.Claims;
using System.Security.Principal;

public static class PrincipalExtensions
{
    public const string SITE_CLAIM_TYPE = "site_claim";

    public static bool HasSite(this IPrincipal principal, string siteId)
    {
        var cp = (ClaimsPrincipal)principal;
        return cp.FindAll(SITE_CLAIM_TYPE).Any(c => c.Value == siteId);
    }

    public static IEnumerable<string> GetSites(this IPrincipal principal)
    {
        var cp = (ClaimsPrincipal)principal;
        return cp.FindAll(SITE_CLAIM_TYPE).Select(c => c.Value);
    }
}
