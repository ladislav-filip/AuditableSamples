#region Info

// FileName:    AuditLog.cs
// Author:      Ladislav Filip
// Created:     26.06.2022

#endregion

namespace Auditable.Domain;

public class AuditLog
{
    public string Id { get; set; }

    public string PartialId { get; set; }

    public string? EventName { get; set; }

    public string? TableName { get; set; }

    public string? ColumnName { get; set; }

    public string? NewValue { get; set; }

    public string? OldValue { get; set; }

    public DateTime DateChanged { get; set; }

    public string UserChanged { get; set; }
}