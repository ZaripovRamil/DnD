using System.Text.Json;
using static System.String;

namespace Models.Dtos;

public class RoundResult
{
    public int RoundNumber { get; set; }
    public List<string> AttackResultJsons { get; set; } = new(); 
    public override string ToString()
    {
        var attackResults = AttackResultJsons
            .Select(arj =>JsonSerializer.Deserialize<AttackResult>(arj)?.ToString());
        return RoundStart()+Concat(attackResults);
    }

    private string RoundStart()
    {
        return $"Round {RoundNumber}:\n";
    }
}