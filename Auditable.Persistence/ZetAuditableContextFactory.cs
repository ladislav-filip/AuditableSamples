#region Info

// FileName:    ZetAuditableContextFactory.cs
// Author:      Ladislav Filip
// Created:     20.06.2022

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Auditable.Persistence;

public class ZetAuditableContextFactory : IDesignTimeDbContextFactory<ZetAuditableContext>
{
    public ZetAuditableContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ZetAuditableContext>();
        optionsBuilder.UseMySql(
            connectionString: "server=dockerhost;port=33060;database=auditable;uid=root;password=lok",
            serverVersion: ServerVersion.Create(new Version(8, 0, 21), ServerType.MySql));

        return new ZetAuditableContext(optionsBuilder.Options);
    }
}