// Describes the initial stats of a pokemon before IV and EV
namespace PokeDojo.src.Data.Stats
{
  public class BaseStat(int health, int attack, int spAttack, int defense, int spDefense, int speed)
  {
    public int Health { get; set; } = health;
    public int Attack { get; set; } = attack;
    public int SpAttack { get; set; } = spAttack;
    public int Defense { get; set; } = defense;
    public int SpDefense { get; set; } = spDefense;
    public int Speed { get; set; } = speed;
  }
}