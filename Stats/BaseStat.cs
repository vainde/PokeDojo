// Describes the initial stats of a pokemon before IV and EV
namespace PokeDojo.Stats
{
  class BaseStat
  {
    int baseHealth;
    int baseAttack;
    int baseSpAttack;
    int baseDefense;
    int baseSpDefense;
    int baseSpeed;

    public BaseStat()
    {
      baseHealth = 0;
      baseAttack = 0;
      baseSpAttack = 0;
      baseDefense = 0;
      baseSpDefense = 0;
      baseSpeed = 0;
    }

    public void SetBaseStat(int health, int attack, int defense, int spAttack, int spDefense, int speed)
    {
      baseHealth = health;
      baseAttack = attack;
      baseSpAttack = spAttack;
      baseDefense = defense;
      baseSpDefense = spDefense;
      baseSpeed = speed;
    }

    public int GetBaseHealth()
    {
      return baseHealth;
    }

    public int GetBaseAttack()
    {
      return baseAttack;
    }
    public int GetBaseSpAttack()
    {
      return baseSpAttack;
    }

    public int GetBaseDefense()
    {
      return baseDefense;
    }

    public int GetBaseSpDefense()
    {
      return baseSpDefense;
    }

    public int GetBaseSpeed()
    {
      return baseSpeed;
    }
  }
}
