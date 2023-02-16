using System.Text;
using System.Text.Json;
using Models.Dtos;

namespace Models.GameModel;

public class BattleLogger
{
    private readonly BattleResult _log = new();

    public void LogEncounter(string playerName, string monsterName)
    {
        _log.PlayerName = playerName;
        _log.MonsterName = monsterName;
    }

    public void LogPlayerWin(bool playerWon)
    {
        _log.PlayerWon = playerWon;
    }

    public void LogRoundResult(RoundResult roundResult)
    {
        _log.RoundJsons.Add(JsonSerializer.Serialize(roundResult));
    }

    public BattleResult GetLog()
    {
        return _log;
    }

    public void LogRemainingHp(int playerHp)
    {
        _log.PlayerRemainingHP = playerHp;
    }
}