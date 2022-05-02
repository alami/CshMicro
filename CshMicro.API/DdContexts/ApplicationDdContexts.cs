using Microsoft.EntityFrameworkCore;

namespace CshMicro.API.DdContexts
{
    public class ApplicationDdContexts : DbContext
    {
        public ApplicationDdContexts(DbContextOptions<ApplicationDdContexts> options) : base(options)
        {

        }
    }
}
