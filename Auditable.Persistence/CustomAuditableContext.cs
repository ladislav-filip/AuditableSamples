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
    
    public DbSet<Person> Persons { get; set; }
    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}