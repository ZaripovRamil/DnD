using System.ComponentModel.DataAnnotations;

namespace Models.GameModel;

public class Entity
{
    public Entity(string name, int hp, int armorClass, int attacksPerRound, int attackModifier, int damageDiceType, int damageDiceThrowsNumber, int damageModifier)
    {
        Name = name;
        HP = hp;
        ArmorClass = armorClass;
        AttacksPerRound = attacksPerRound;
        AttackModifier = attackModifier;
        DamageDiceType = damageDiceType;
        DamageDiceThrowsNumber = damageDiceThrowsNumber;
        DamageModifier = damageModifier;
    }

    public Entity(int id, string name, int hp, int armorClass, int attacksPerRound, int attackModifier,
        int damageDiceType, int damageDiceThrowsNumber, int damageModifier)
        :this(name, hp, armorClass, attacksPerRound, attackModifier, damageDiceType, damageDiceThrowsNumber, damageModifier)
    {
        Id = id;
    }

    public Entity()
    {
    }
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int HP { get; set; }
    public int ArmorClass { get; set; }
    public int AttacksPerRound { get; set; }
    public int AttackModifier { get; set; }
    public int DamageDiceType { get; set; }
    public int DamageDiceThrowsNumber { get; set; }
    public int DamageModifier { get; set; }

    public bool IsAlive => HP > 0;
}