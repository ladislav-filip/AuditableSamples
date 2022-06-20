#region Info
// FileName:    Person.cs
// Author:      Ladislav Filip
// Created:     20.06.2022
#endregion

namespace Auditable.Domain;

public class Person
{
    public int PersonId { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public int CountryId { get; set; }

    public Country Country { get; set; }
}