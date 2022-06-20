#region Info
// FileName:    CustomAuditEntry.cs
// Author:      Ladislav Filip
// Created:     20.06.2022
#endregion

namespace Auditable.Domain;

public class CustomAuditEntry
{
    public long CustomAuditEntryId { get; set; }

    public string? TableName { get; set; }

    public string StateName { get; set; }

    public int State { get; set; }

    public string ColumnName { get; set; }

    public string? RelationName { get; set; }

    public string? NewValue { get; set; }

    public string? OldValue { get; set; }

    public DateTime? DateCreated { get; set; }

    public string CreatedBy { get; set; }
}