using System.Text.Json;
using BestiaryDB.DbContext;
using Microsoft.AspNetCore.Mvc;

namespace BestiaryDB.Controllers;

[ApiController]
[Route("[controller]")]
public class BestiaryController : ControllerBase
{
    private readonly AppDbContext _bestiary;
    public BestiaryController(AppDbContext db) => _bestiary = db;
    private readonly Random _rnd = new();
    [HttpGet]
    public string GetMonster()
    {
        var max = _bestiary.Entities.Count();
        return JsonSerializer.Serialize(_bestiary.Entities.Find(_rnd.Next(1, max+1)));
    }
}