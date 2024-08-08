using Felipe.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Felipe.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }

        public SqlContext(DbContextOptions<SqlContext> options)
            : base(options) { }

        public DbSet<Checklist>? Checklists { get; set; }

        public DbSet<ChecklistItem>? ChecklistItems { get; set; }


        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("Registro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("Registro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("Registro").IsModified = false;
            }

            return base.SaveChanges();
        }
    }
}