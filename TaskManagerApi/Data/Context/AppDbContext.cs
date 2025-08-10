using Microsoft.EntityFrameworkCore;
using System.Threading;
using TaskManagerApi.Models;

namespace TaskManagerApi.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskMgmt> TasksToDo => Set<TaskMgmt>();
    }
}
