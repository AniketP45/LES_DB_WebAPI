using Microsoft.EntityFrameworkCore;
using LES_DB_WebAPI.Models;

namespace LES_DB_WebAPI.Data
{
    public class AppDbContext : DbContext
    {

            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            public DbSet<SendMailQueue> SendMailQueues { get; set; }
            public DbSet<SMAuditLog> AuditLogs { get; set; }


    }
}
