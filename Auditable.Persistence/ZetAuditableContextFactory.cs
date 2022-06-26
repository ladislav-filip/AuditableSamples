﻿#region Info

// FileName:    ZetAuditableContextFactory.cs
// Author:      Ladislav Filip
// Created:     20.06.2022

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Auditable.Persistence;

public class AuditableContextFactory : IDesignTimeDbContextFactory<CustomAuditableContext>
{
    public CustomAuditableContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CustomAuditableContext>();
        optionsBuilder.UseMySql(
            connectionString: "server=dockerhost;port=33060;database=ZetAuditable;uid=root;password=lok",
            serverVersion: ServerVersion.Create(new Version(8, 0, 21), ServerType.MySql));

        return new CustomAuditableContext(optionsBuilder.Options);
    }
}