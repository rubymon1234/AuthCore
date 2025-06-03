using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ShoppyWeb.Data.ApplicationConst.ApplicationConst;

namespace ShoppyWeb.Data
{
    public class SeedData
    {
        public static async Task SeedRole(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = new List<IdentityRole>
            {
                new IdentityRole{Name=CustomRole.MasterAdmin,NormalizedName=CustomRole.MasterAdmin},
                new IdentityRole{Name=CustomRole.Admin,NormalizedName=CustomRole.Admin},
                new IdentityRole{Name=CustomRole.Customer,NormalizedName=CustomRole.Customer},
            };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role.Name))
                {
                    await roleManager.CreateAsync(role);
                }
            }
        }
    }
}
