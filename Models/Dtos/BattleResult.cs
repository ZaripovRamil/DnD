using System.Text.Json;

namespace Models.Dtos;

public class BattleResult
{
    public string PlayerName { get; set; }
    public string MonsterName { get; set; }
    public int PlayerRemainingHP { get; set; }
    public bool PlayerWon { get; set; }
    public List<string> RoundJsons { get; set; } = new();
    public override string ToString()
    {
        var roundLogs = RoundJsons
            .Select(rj =>JsonSerializer.Deserialize<RoundResult>(rj)?.ToString());
        return EncounterLog() + string.Concat(roundLogs) + WinnerLog();
    }

    private object WinnerLog()
    {
        return (PlayerWon ? PlayerName : MonsterName)+" wins!";
    }

    private string EncounterLog()
    {
        return $"A wild {MonsterName} appears in front of {PlayerName}!\n";
    }
}