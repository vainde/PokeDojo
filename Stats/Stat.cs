// Represents the actual stats of the pokemon
using PokeDojo.Descriptor;
using PokeDojo.Value;

namespace PokeDojo.Stats
{
  class Stat
  {
    int health;
    int attack;
    int spAttack;
    int defense;
    int spDefense;
    int speed;

    public Stat()
    {
      health = 0;
      attack = 0;
      spAttack = 0;
      defense = 0;
      spDefense = 0;
      speed = 0;
    }

    // If the player wants to use Gen 1 and Gen 2 tiers, these stats must be applied
    // LAST THING WORKED ON 12:38 10/22
    public void EarlyGenHealth(Pokemon pokemon)
    {
      int baseHealth = pokemon.GetBaseStat().GetBaseHealth();
      int healthIV = pokemon.GetStatValue().GetIndividualValue().GetHealthIV();
      int healthEV = pokemon.GetStatValue().GetEffortValue().GetHealthEV();
      int level = pokemon.GetDescription().GetLevel();

      int combinedHealth = baseHealth + healthIV;
      int dividedHealthEV = (int)(Math.Sqrt(healthEV) / 4);
      int preModified = ((combinedHealth + dividedHealthEV) * 81) / 100;
      int postModified = preModified + level + 10;
      health = postModified;

    }


    // NEXT THING TO WORK ON 10/22
    public void EarlyGenSpAttack(Pokemon pokemon)
    {

    }

    public void EarlyGenSpDefense(Pokemon pokemon)
    {

    }

    public void EarlyGenAttack(Pokemon pokemon)
    {

    }

    public void EarlyGenDefense(Pokemon pokemon)
    {

    }

    public void EarlyGenSpeed(Pokemon pokemon)
    {

    }
  }
}
