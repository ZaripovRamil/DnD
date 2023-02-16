using Models.GameModel;

namespace Models.Dtos;

public class BattleSetup
{
    public string PlayerName { get; set; }
    public int PlayerHP { get; set; }
    public int PlayerArmorClass { get; set; }
    public int PlayerAttacksPerRound { get; set; }
    public int PlayerAttackModifier { get; set; }
    public int PlayerDamageDiceType { get; set; }
    public int PlayerDamageDiceThrowsNumber { get; set; }
    public int PlayerDamageModifier { get; set; }
    public string MonsterName { get; set; }
    public int MonsterHP { get; set; }
    public int MonsterArmorClass { get; set; }
    public int MonsterAttacksPerRound { get; set; }
    public int MonsterAttackModifier { get; set; }
    public int MonsterDamageDiceType { get; set; }
    public int MonsterDamageDiceThrowsNumber { get; set; }
    public int MonsterDamageModifier { get; set; }

    public BattleSetup()
    {
    }

    public BattleSetup(Entity Player, Entity Monster)
    {
        PlayerName = Player.Name;
        PlayerHP = Player.HP;
        PlayerArmorClass = Player.ArmorClass;
        PlayerAttacksPerRound = Player.AttacksPerRound;
        PlayerAttackModifier = Player.AttackModifier;
        PlayerDamageDiceType = Player.DamageDiceType;
        PlayerDamageDiceThrowsNumber = Player.DamageDiceThrowsNumber;
        PlayerDamageModifier = Player.DamageModifier;
        MonsterName = Monster.Name;
        MonsterHP = Monster.HP;
        MonsterArmorClass = Monster.ArmorClass;
        MonsterAttacksPerRound = Monster.AttacksPerRound;
        MonsterAttackModifier = Monster.AttackModifier;
        MonsterDamageDiceType = Monster.DamageDiceType;
        MonsterDamageDiceThrowsNumber = Monster.DamageDiceThrowsNumber;
        MonsterDamageModifier = Monster.DamageModifier;
    }

    public (Entity, Entity) ConvertToEntities()
    {
        return (new Entity(
                PlayerName,
                PlayerHP,
                PlayerArmorClass,
                PlayerAttacksPerRound,
                PlayerAttackModifier,
                PlayerDamageDiceType,
                PlayerDamageDiceThrowsNumber,
                PlayerDamageModifier),
            new Entity(MonsterName,
                MonsterHP,
                MonsterArmorClass,
                MonsterAttacksPerRound,
                MonsterAttackModifier,
                MonsterDamageDiceType,
                MonsterDamageDiceThrowsNumber,
                MonsterDamageModifier));
    }
}