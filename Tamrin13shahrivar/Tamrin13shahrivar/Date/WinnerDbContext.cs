using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tamrin13shahrivar.Model;

namespace Tamrin13shahrivar.Date
{
    public class WinnerDbContext : IdentityDbContext
    {
        public WinnerDbContext(DbContextOptions<WinnerDbContext> options) : base(options)
        {
        }
        public DbSet<InstallMents> InstallMents { get; set; }

        public DbSet<Lottery> Lottery { get; set;}

        public DbSet<LotteryMember> LotteryMembers { get; set; }

        public DbSet<Winner> Winners { get; set; }
        public DbSet<IdentityUser> identityUsers { get; set; }

    }
}
