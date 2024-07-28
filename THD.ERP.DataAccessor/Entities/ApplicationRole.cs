using Microsoft.AspNetCore.Identity;

namespace THD.ERP.DataAccessor.Entities;

public class ApplicationRole : IdentityRole<long>
{
    public string Description { get; set; } = null!;
}