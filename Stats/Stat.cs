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
      int preModified = ((combinedHealth + dividedHealthEV) * level) / 100;
      int postModified = preModified + level + 10;
      health = postModified;

    }

    public void EarlyGenStat(Pokemon pokemon, string stat)
    {
      // calculates the attack according to the general stat calculation
      int baseAttack = pokemon.GetBaseStat().GetBaseAttack();
      int attackIV = pokemon.GetStatValue().GetIndividualValue().GetAttackIV();
      int attackEV = pokemon.GetStatValue().GetEffortValue().GetAttackEV();
      int level = pokemon.GetDescription().GetLevel();

      switch (stat)
      {
        case "attack":
          CalculateEarlyGenStat(baseAttack, attackIV, attackEV, level);
          break;
      }
    }

    public void CalculateEarlyGenStat(int baseStat, int IV, int EV, int level)
    {
      int desiredStat;
      desiredStat = (int)((baseStat + IV) * 2 + (Math.Sqrt(EV) / 4) * level) / 100;
    }
  }
}
