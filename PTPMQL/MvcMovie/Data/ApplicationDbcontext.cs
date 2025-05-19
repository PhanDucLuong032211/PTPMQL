using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using MvcMovie.Models.Entities;
namespace MvcMovie.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<MvcMovie.Models.Employee> Employee { get; set; } = default!;
        public DbSet<MvcMovie.Models.HeThongPhanPhoi> HeThongPhanPhoi { get; set; } = default!;
        public DbSet<MvcMovie.Models.DaiLy> DaiLy { get; set; } = default!;
        public DbSet<MvcMovie.Models.Entities.Employeee> Employeee { get; set; } = default!;
        public DbSet<MvcMovie.Models.Entities.MemberUnit> MemberUnits { get; set; } = default!;
    }
}

