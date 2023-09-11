using Microsoft.EntityFrameworkCore;
using Tamrin13shahrivar.Model;

namespace Tamrin13shahrivar.Date
{
    public class WinnerDbContext : DbContext
    {
        public WinnerDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<InstallMents> InstallMents { get; set; }

        public DbSet<Lottery> Lottery { get; set;}

        public DbSet<LotteryMember> LotteryMembers { get; set; }

        public DbSet<Winner> Winners { get; set; }


    }
}
