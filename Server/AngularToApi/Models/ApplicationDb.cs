using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AngularToApi.Models
{
    public class ApplicationDb:IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public ApplicationDb(DbContextOptions<ApplicationDb> options):base(options)
        {
                
        }
    }
}
