// Describes the initial stats of a pokemon before IV and EV
namespace PokeDojo.src.Data.Stats
{
  public class BaseStat
  {
    public int Health { get; set; } = 0;
    public int Attack { get; set; } = 0;
    public int SpAttack { get; set; } = 0;
    public int Defense { get; set; } = 0;
    public int SpDefense { get; set; } = 0;
    public int Speed { get; set; } = 0;

    public void SetBaseStat(int hp, int atk, int spatk, int def, int spdef, int spd)
    {
      Health = hp;
      Attack = atk;
      SpAttack = spatk;
      Defense = def;
      SpDefense = spdef;
      Speed = spd;
    }
  }
}