#region Info
// FileName:    IAuditableContext.cs
// Author:      Ladislav Filip
// Created:     20.06.2022
#endregion

using Auditable.Domain;
using Microsoft.EntityFrameworkCore;

namespace Auditable.Persistence;

public interface IAuditableContext
{
    public DbSet<Person> Persons { get; set; }
    
    public DbSet<SecretData> SecretDatas { get; set; }

    int SaveChanges();
}