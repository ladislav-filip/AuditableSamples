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
            (context as ZetAuditableContext)?.AuditEntries.AddRange(audit.Entries);
    }
    
    public DbSet<Person> Persons { get; set; }
    public DbSet<AuditEntry> AuditEntries { get; set; }

    public DbSet<SecretData> SecretDatas { get; set; }

    public ZetAuditableContext(DbContextOptions<ZetAuditableContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 
    }


    public override int SaveChanges()
    {
        var audit = new Audit();
        // audit.Configuration.Exclude<SecretData>();
        // audit.Configuration.Format<SecretData>(p => p.Text, _ => "*****");
        audit.PreSaveChanges(this);
        var rowAffecteds = base.SaveChanges();
        audit.PostSaveChanges();

        if (audit.Configuration.AutoSavePreAction == null)
        {
            return rowAffecteds;
        }

        audit.Configuration.AutoSavePreAction(this, audit);
        base.SaveChanges();
        return rowAffecteds;
    }

}