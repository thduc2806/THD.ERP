using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using THD.ERP.DataAccessor.Entities;

namespace THD.ERP.DataAccessor.Data.Seeds;

public static class DefaultEmployees
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var emloyeeManager = serviceProvider.GetRequiredService<UserManager<Employee>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

        string[] roleNames = { "Admin", "Manager", "Emloyee" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                roleResult = await roleManager.CreateAsync(new ApplicationRole { Name = roleName, Description = roleName});
            }
        }

        Employee user = await emloyeeManager.FindByEmailAsync("admin@example.com");
        if (user == null)
        {
            user = new Employee()
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                PhoneNumber = "0123456789",
                DateOfBirth = DateTime.Now.AddYears(-25),
                FirstName = "A",
                LastName = "Nguyen",
                Position = "Dev"
            };
            await emloyeeManager.CreateAsync(user, "Admin@123");
        }

        await emloyeeManager.AddToRoleAsync(user, "Admin");
    }
}