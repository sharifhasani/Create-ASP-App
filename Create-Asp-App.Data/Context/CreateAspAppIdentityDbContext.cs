using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Create_Asp_App.Data.Context
{
    public class CreateAspAppIdentityDbContext:IdentityDbContext
    {
        public CreateAspAppIdentityDbContext(DbContextOptions<CreateAspAppIdentityDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // call the base if you are using Identity service.
            // Important
            base.OnModelCreating(builder);

            // Code here ...
        }

    }
}
