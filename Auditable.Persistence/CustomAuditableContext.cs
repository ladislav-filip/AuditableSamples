#region Info

// FileName:    CustomAuditableContext.cs
// Author:      Ladislav Filip
// Created:     26.06.2022

#endregion

using Auditable.Domain;
using Microsoft.EntityFrameworkCore;

namespace Auditable.Persistence;

public class CustomAuditableContext : DbContext, IAuditableContext
{
    public CustomAuditableContext(DbContextOptions<CustomAuditableContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<AuditLog>()
            .ToTable("AuditLogs")
            .Property(p => p.Id)
            .HasMaxLength(50)
            .IsUnicode(false);

        modelBuilder.Entity<AuditLog>()
            .HasIndex(p => p.Id);
    }

    public DbSet<Person> Persons { get; set; }
    public override int SaveChanges()
    {
        SaveAudit();
        return base.SaveChanges();
    }

    private void SaveAudit()
    {
        ChangeTracker.DetectChanges();
        
        var entries = ChangeTracker.Entries()
            .Where(p => p.State != EntityState.Detached && p.State != EntityState.Unchanged)
            .ToList();

        var dateChanged = DateTime.Now;

        var auditData = new List<AuditLog>();
        
        entries.ForEach(entry =>
        {
            var partId = Guid.NewGuid().ToString("N");
            var tableName = entry.Entity.GetType().Name;
            foreach (var prop in entry.Properties)
            {
                var propName = prop.Metadata.Name;

                var audit = new AuditLog
                {
                    Id = Guid.NewGuid().ToString("N"),
                    PartialId = partId,
                    TableName = tableName,
                    ColumnName = propName,
                    DateChanged = dateChanged,
                    UserChanged = "Franta",
                    EventName = entry.State.ToString()
                };

                switch (entry.State)
                {
                    case EntityState.Added:
                        audit.NewValue = prop.CurrentValue?.ToString();
                        break;
                    case EntityState.Modified:
                        audit.NewValue = prop.CurrentValue?.ToString();
                        audit.OldValue = prop.OriginalValue?.ToString();
                        break;
                    case EntityState.Deleted:
                        audit.OldValue = prop.OriginalValue?.ToString();
                        break;
                }
                
                auditData.Add(audit);
            }
        });
        
        Set<AuditLog>().AddRange(auditData);
    }
}