using System.Text.Json;

namespace Models.Dtos;

public class DamageResult
{
    public bool isCritical { get; set; }
    public int baseDamage { get; set; }
    public int damageModifier { get; set; }
    public string TargetName { get; set; }
    public int leftHp { get; set; }

    public override string ToString()
    {
        return isCritical 
            ? CriticalDamageLog(baseDamage, damageModifier, TargetName, leftHp) 
            : DamageLog(baseDamage, damageModifier, TargetName, leftHp);
    }

    private static string DamageLog(int dice, int dm, string targetName, int leftHP)
    {
        return $"{dice}(+{dm}) deals {dice + dm} damage to {targetName}({leftHP} HP left)\n";
    }

    private static string CriticalDamageLog(int dice, int dm, string targetName, int leftHP)
    {
        return $"{dice}(+{dm})*2 deals {(dice + dm) * 2} damage to {targetName}({leftHP} HP left)\n";
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}