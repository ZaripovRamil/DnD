namespace Models.GameModel;

public static class Dice
{
    private static readonly Random Rnd = new();
    public static int Throw(int max) => Rnd.Next(1,max + 1);
}