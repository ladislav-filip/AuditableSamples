#region Info

// FileName:    ZetAuditableContext.cs
// Author:      Ladislav Filip
// Created:     20.06.2022

#endregion

using Auditable.Domain;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace Auditable.Persistence;

public class ZetAuditableContext : DbContext, IAuditableContext
{
    static ZetAuditableContext()
    {
        AuditManager.DefaultConfiguration.AutoSavePreAction = (context, audit) =>
            (context as ZetAuditableContext)?.AuditEntries.AddRange(ReadEntries(audit.Entries));
    }

    private static IEnumerable<CustomAuditEntry> ReadEntries(IEnumerable<AuditEntry> auditEntries)
    {
        return auditEntries.SelectMany(entry => entry.Properties.Select(property => new CustomAuditEntry
        {
            TableName = entry.EntitySetName,
            State = (int)entry.State,
            StateName = entry.StateName,
            ColumnName = property.PropertyName,
            RelationName = property.RelationName,
            NewValue = property.NewValue?.ToString(),
            OldValue = property.OldValue?.ToString(),
            DateCreated = DateTime.Now,
            CreatedBy = entry.CreatedBy
        }));
    }

    public ZetAuditableContext(DbContextOptions<ZetAuditableContext> options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
    
    public DbSet<CustomAuditEntry> AuditEntries { get; set; }
    
    public override int SaveChanges()
    {
        var audit = new Audit();
        audit.Configuration.AuditEntryFactory = args => new AuditEntry
        {
            CreatedBy = "ja"
        };
        
        audit.PreSaveChanges(this);
        var rowAffecteds = base.SaveChanges();
        audit.PostSaveChanges();

        if (audit.Configuration.AutoSavePreAction != null)
        {
            audit.Configuration.AutoSavePreAction(this, audit);
            base.SaveChanges();
        }

        return rowAffecteds;
    }
}