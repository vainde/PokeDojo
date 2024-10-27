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

    /* If the player wants to use Gen 1 and Gen 2 for any tier, these stats must be applied.
     * Health is calculated differently from the other stats, hence it's seperation
     */

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

    // Template for calculating non-health stats
    public int CalculateEarlyGenStat(int baseStat, int IV, int EV, int level)
    {
      int desiredStat;
      desiredStat = (int)((baseStat + IV) * 2 + (Math.Sqrt(EV) / 4) * level) / 100;
      return desiredStat; 
    }

    // Implements the template above based on specific stat
    public void EarlyGenAttack(Pokemon pokemon)
    {
      int baseAttack = pokemon.GetBaseStat().GetBaseAttack();
      int attackIV = pokemon.GetStatValue().GetIndividualValue().GetAttackIV();
      int attackEV = pokemon.GetStatValue().GetEffortValue().GetAttackEV();
      int level = pokemon.GetDescription().GetLevel();
      attack = CalculateEarlyGenStat(baseAttack, attackIV, attackEV, level);
    }

    public void EarlyGenDefense(Pokemon pokemon)
    {
      int baseDefense = pokemon.GetBaseStat().GetBaseDefense();
      int defenseIV = pokemon.GetStatValue().GetIndividualValue().GetDefenseIV();
      int defenseEV = pokemon.GetStatValue().GetEffortValue().GetDefenseEV();
      int level = pokemon.GetDescription().GetLevel();

      defense = CalculateEarlyGenStat(baseDefense, defenseIV, defenseEV, level);
    }

    public void EarlyGenSpAttack(Pokemon pokemon)
    {
      int baseSpAttack = pokemon.GetBaseStat().GetBaseSpAttack();
      int spAttackIV = pokemon.GetStatValue().GetIndividualValue().GetSpAttackIV();
      int spAttackEV = pokemon.GetStatValue().GetEffortValue().GetSpAttackEV();
      int level = pokemon.GetDescription().GetLevel();

     spAttack = CalculateEarlyGenStat(baseSpAttack, spAttackIV, spAttackEV, level);
    }

    public void EarlyGenSpDefense(Pokemon pokemon)
    {
      int baseSpDefense = pokemon.GetBaseStat().GetBaseSpDefense();
      int spDefenseIV = pokemon.GetStatValue().GetIndividualValue().GetSpDefenseIV();
      int spDefenseEV = pokemon.GetStatValue().GetEffortValue().GetSpDefenseEV();
      int level = pokemon.GetDescription().GetLevel();

      spDefense = CalculateEarlyGenStat(baseSpDefense, spDefenseIV, spDefenseEV, level);
    }

    public void EarlyGenSpeed(Pokemon pokemon)
    {
      int baseSpeed = pokemon.GetBaseStat().GetBaseSpeed();
      int speedIV = pokemon.GetStatValue().GetIndividualValue().GetSpeedIV();
      int speedEV = pokemon.GetStatValue().GetEffortValue().GetSpeedEV();
      int level = pokemon.GetDescription().GetLevel();

      speed = CalculateEarlyGenStat(baseSpeed, speedIV, speedEV, level);
    }
  }
}
