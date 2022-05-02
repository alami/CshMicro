using CshMicro.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CshMicro.API.DdContexts
{
    public class ApplicationDdContexts : DbContext
    {
        public ApplicationDdContexts(DbContextOptions<ApplicationDdContexts> options) : base(options)
        {
        }
        public DbSet<Resolution> Resolutions { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<VideoTariff> VideoTariffs { get; set; }

    }
}
