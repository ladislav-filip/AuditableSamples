#region Info
// FileName:    Start.cs
// Author:      Ladislav Filip
// Created:     20.06.2022
#endregion

using Auditable.Domain;
using Microsoft.EntityFrameworkCore;

namespace ConsoleClient;

public class Start
{
    private readonly ILogger<Start> _logger;
    private readonly IAuditableContext _context;

    public Start(ILogger<Start> logger, IAuditableContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    public void Run()
    {
        _logger.LogInformation("Run...");

        AddNew();

        Update();

        _context.SaveChanges();

        _logger.LogInformation("Finnish");
        Console.ReadKey();
    }

    private void Update()
    {
        var person = _context.Persons.Include(i => i.Country).First();
        person.Name = "Pepa z depa 3i oprava";
        person.Country.Name = "Cesko";
    }

    private void AddNew()
    {
        var person = new Person
        {
            Name = "Petr", Surname = "Brznak",
            Country = new Country { Code = "pl", Name = "Poland" }
        };
        _context.Persons.Add(person);
    }
}