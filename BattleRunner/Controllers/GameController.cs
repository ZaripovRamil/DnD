using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Models.GameModel;

namespace BattleRunner.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    [HttpPost]
    public Task<string> RunBattle(string jsonData)
    {
        var entities = JsonSerializer.Deserialize<BattleSetup>(jsonData).ConvertToEntities();
        var battle = new Battle(entities.Item1, entities.Item2);
        var result = battle.RunBattle();
        return Task.FromResult(JsonSerializer.Serialize(result));
    }
}