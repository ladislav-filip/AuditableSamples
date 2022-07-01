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
        // Update();
        AddSecret();

        _context.SaveChanges();
        _logger.LogInformation("Finnish. Press any key");
        Console.ReadKey();
    }

    private void AddSecret()
    {
        _context.SecretDatas.Add(new SecretData
        {
            Id = Guid.NewGuid().ToString(),
            Text = GenerateName(20),
            Created = DateTime.Now
        });
    }
    private void Update()
    {
        var person = _context.Persons.Include(i => i.Country).First();
        person.Name = GenerateName(5);
        person.Country.Name = "Cesko";
    }

    private void AddNew()
    {
        var person = new Person
        {
            Name = GenerateName(4), Surname = GenerateName(8),
            Country = new Country { Code = "cz", Name = "Czech" }
        };
        _context.Persons.Add(person);
    }
    
    public static string GenerateName(int len)
    { 
        var r = new Random();
        string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
        string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
        var name = "";
        name += consonants[r.Next(consonants.Length)].ToUpper();
        name += vowels[r.Next(vowels.Length)];
        var b = 2; 
        while (b < len)
        {
            name += consonants[r.Next(consonants.Length)];
            b++;
            name += vowels[r.Next(vowels.Length)];
            b++;
        }

        return name;
    }
}