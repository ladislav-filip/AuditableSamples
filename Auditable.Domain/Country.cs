#region Info

// FileName:    Country.cs
// Author:      Ladislav Filip
// Created:     20.06.2022

#endregion

namespace Auditable.Domain;

public class Country
{
    public int CountryId { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }
}