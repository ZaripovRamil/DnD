using System.Text.Json;

namespace Models.Dtos;

public class AttackResult
{
    public string AttackerName { get; set; }
    public AttackType AttackType{ get; set; }
    public int AttackDice { get; set; }
    public int AttackModifier { get; set; }
    public int ArmorClass { get; set; }
    public string DamageResultJson { get; set; }

    public override string ToString()
    {
        var damageResult = JsonSerializer.Deserialize<DamageResult>(DamageResultJson);
        return AttackerNameLog()+AttackType switch
        {
            AttackType.CriticalMiss => $"{AttackDice}(+{AttackModifier}) is a critical miss. \n",
            AttackType.Miss => $"{AttackDice}(+{AttackModifier}) is less or equal than {ArmorClass}, it's a miss.\n",
            AttackType.Hit => $"{AttackDice}(+{AttackModifier}) is more than {ArmorClass}, it's a hit! {damageResult}",
            AttackType.CriticalHit => $"{AttackDice}(+{AttackModifier}) is a critical hit! {damageResult}",
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private string AttackerNameLog() => $"{AttackerName} attacks! \n";

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}