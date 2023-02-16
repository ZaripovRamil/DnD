using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Models.GameModel;

namespace MainServer.Controllers;

public class GameController:Controller
{
    private readonly HttpClient _client = new();
    
    [HttpGet]
    public IActionResult Game() => View(new ViewSetup());

    [HttpPost]
    public async Task<IActionResult> Game(string name, int hp, int ac, int apr, int am, int ddt, int ddtn, int dm)
    {
        var player = new Entity(name, hp, ac, apr,
            am, ddt, ddtn, dm);
        var monster = await RequestMonsterAsync();
        var battleResult = await RunBattleAsync(player, monster);
        player.HP = battleResult.PlayerRemainingHP;
        return GameResult(battleResult, player);
    }

    private IActionResult GameResult(BattleResult battleResult, Entity player)
    {
        var viewSetup = new ViewSetup(battleResult, player);
        return View(viewSetup);
    }

    private async Task<BattleResult> RunBattleAsync(Entity player, Entity monster)
    {
        var setup = new BattleSetup(player, monster);
        var setupJson = JsonSerializer.Serialize(setup);
        var message = new HttpRequestMessage();
        message.Method = HttpMethod.Post;
        message.RequestUri = new Uri($"http://localhost:5116/Game?jsonData={setupJson}");
        var result =await _client.SendAsync(message);
        var content = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<BattleResult>(content);
    }

    private async Task<Entity> RequestMonsterAsync()
    {
        var message = new HttpRequestMessage();
        message.Method = HttpMethod.Get;
        message.RequestUri = new Uri($"http://localhost:5119/Bestiary");
        var result = await _client.SendAsync(message);
        var content = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Entity>(content);
    }
}