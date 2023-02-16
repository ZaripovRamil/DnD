using Models.Dtos;

namespace Models.GameModel;

public class Battle
{
    private readonly BattleLogger _logger = new();

    public Battle(Entity player, Entity monster)
    {
        Player = player;
        Monster = monster;
        Attacker = Player;
        Target = Monster;
    }

    private Entity Player { get; set; }
    private Entity Monster { get; set; }

    private Entity? Winner
    {
        get
        {
            if (!Player.IsAlive) return Monster;
            if(!Monster.IsAlive) return Player;
            return null;
        }
    }


    private Entity Attacker { get; set; }
    private Entity Target { get; set; }
    private void SwapMove() => (Attacker, Target) = (Target, Attacker);

    public BattleResult RunBattle()
    {
        _logger.LogEncounter(Player.Name, Monster.Name);
        var roundNumber = 1;
        while (Winner == null)
           _logger.LogRoundResult(RunRound(roundNumber++));
        _logger.LogPlayerWin(Winner == Player);
        _logger.LogRemainingHp(Player.HP);
        return _logger.GetLog();
    }

    private RoundResult RunRound(int roundNumber)
    {
        var result = new RoundResult {RoundNumber = roundNumber};
        var attacksLeft = new Dictionary<Entity, int>
        {
            {Player, Player.AttacksPerRound},
            {Monster, Monster.AttacksPerRound}
        };
        Attacker = Player;
        Target = Monster;
        while (Winner == null && attacksLeft.Values.Sum()>0)
        {
            if (attacksLeft[Attacker] > 0)
            {
                result.AttackResultJsons.Add(RunAttack().ToJson()); 
                attacksLeft[Attacker] -= 1;
            }
            SwapMove();
        }

        return result;
    }

    private AttackResult RunAttack()
    {
        var result = new AttackResult {AttackerName = Attacker.Name, AttackModifier = Attacker.AttackModifier,
            ArmorClass = Target.ArmorClass, DamageResultJson = new DamageResult().ToJson()};
        var attackDice = Dice.Throw(20);
        result.AttackDice = attackDice;
        switch (attackDice)
        {
            case 1:
                result.AttackType = AttackType.CriticalMiss;
                break;
            case 20:
                result.AttackType = AttackType.CriticalHit;
                result.DamageResultJson = CalculateDamage(true).ToJson();
                break;
            default:
            {
                if (attackDice + Attacker.AttackModifier > Target.ArmorClass)
                {
                    result.AttackType = AttackType.Hit;
                    result.DamageResultJson = CalculateDamage(false).ToJson();
                }
                else result.AttackType = AttackType.Miss;
                break;
            }
        }

        return result;
    }


    private DamageResult CalculateDamage(bool isCritical)
    {
        var result = new DamageResult{isCritical = isCritical, 
            damageModifier = Attacker.DamageModifier, TargetName = Target.Name};
        var diceDamage = 0;
        for (var i = 0; i < Attacker.DamageDiceThrowsNumber; i++)
            diceDamage += Dice.Throw(Attacker.DamageDiceType);
        result.baseDamage = diceDamage;
        var totalDamage = (diceDamage + Attacker.DamageModifier + 1) * (isCritical ? 2 : 1);
        Target.HP -= totalDamage;
        result.leftHp = Target.HP;
        return result;
    }
}