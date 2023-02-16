using Models.GameModel;

namespace Models.Dtos;

public class ViewSetup
{
    public ViewSetup()
    {
        LastBattle = new BattleResult();
        Player = new Entity("Adventurer", 100,
            15, 1, 3, 12, 3, 3);
    }
    public ViewSetup(BattleResult lastBattle, Entity player)
    {
        UseLastBattle = true;
        LastBattle = lastBattle;
        Player = player;
    }
    public bool UseLastBattle { get; set; }
    public BattleResult LastBattle { get; set; }
    public Entity Player { get; set; }
}