// Represents the actual stats of the pokemon
using PokeDojo.Descriptor;
using PokeDojo.Value;
using PokeDojo.Poke;

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

    /*
     * Most natures will boost a stat by 10% and decrease one by 10% assuming it's not
     * neutral. We can apply the modifier here since the stats should control itself.
     */
    public void SetHealth(int health)
    {
      this.health = health;
    }

    public void SetAttack(int attack)
    {
      this.attack = attack;
    }

    public void SetSpecialAttack(int spAttack)
    {
      this.spAttack = spAttack;
    }

    public void SetDefense(int defense)
    {
      this.defense = defense;
    }

    public void SetSpDefense(int spDefense)
    {
      this.spDefense = spDefense;
    }

    public void SetSpeed(int speed)
    {
      this.speed = speed;
    }
    public int GetHealth()
    {
      return health;
    }

    public int GetAttack()
    {
      return attack;
    }

    public int GetSpecialAttack()
    {
      return spAttack;
    }

    public int GetDefense()
    {
      return defense;
    }

    public int GetSpecialDefense()
    {
      return spDefense;
    }

    public int GetSpeed()
    {
      return speed;
    }

    public int IncreaseByNature(int increase)
    {
      increase *= (int)1.10;
      return increase;
    }

    public int DecreaseByNature(int decrease) {
      decrease -= decrease * (int)0.1;
      return decrease;
    }

    /*
    public void ApplyNature(Pokemon pokemon)
    {
      Nature nature = pokemon.GetNature();
      int attack = pokemon.GetStat().GetAttack();
      int defense = pokemon.GetStat().GetDefense();
      int spAttack = pokemon.GetStat().GetSpecialAttack();
      int spDefense = pokemon.GetStat().GetSpecialDefense();
      int speed = pokemon.GetStat().GetSpeed();

      switch (nature.GetName())
      {
        // Applying stat changes to natures that increase attack
        case "Lonely":
          pokemon.GetStat().SetAttack(IncreaseByNature(attack));
          pokemon.GetStat().SetDefense(DecreaseByNature(defense));
          break;
        case "Adamant":
          pokemon.GetStat().SetAttack(IncreaseByNature(attack));
          pokemon.GetStat().SetSpecialAttack(DecreaseByNature(spDefense));
          break;
        case "Naughty":
          pokemon.GetStat().SetAttack(IncreaseByNature(attack));
          pokemon.GetStat().SetSpDefense(DecreaseByNature(spDefense));
          break;
        case "Brave":
          pokemon.GetStat().SetAttack(IncreaseByNature(attack));
          pokemon.GetStat().SetSpeed(DecreaseByNature(speed));
          break;
      }
    }*/

    /* If the player wants to use Gen 1 and Gen 2 for any tier, these stats must be applied.
     * Health is calculated differently from the other stats, hence it's seperation
     */

    public void EarlyGenHealth(Pokemon pokemon)
    {
      int baseHealth = pokemon.GetBaseStat().GetBaseHealth();
      int healthIV = pokemon.GetStatValue().GetIndividualValue().GetHealthIV();
      int healthEV = pokemon.GetStatValue().GetEffortValue().GetHealthEV();
      int level = pokemon.GetGeneration().GetDescription().GetLevel();

      int combinedHealth = (baseHealth + healthIV) * 2;
      int dividedHealthEV = (int)(Math.Sqrt(healthEV) / 4);
      int preModified = ((combinedHealth + dividedHealthEV) * level) / 100;
      int postModified = preModified + level + 10;
      pokemon.GetStat().SetHealth(postModified);
    }

    // Template for calculating non-health stats
    public int CalculateEarlyGenStat(int baseStat, int IV, int EV, int level)
    {
      int handleBase = (baseStat + IV) * 2;
      int handleStatEXP = (int)Math.Sqrt(EV) / 4;
      int preModified = ((handleBase + handleStatEXP) * level) / 100;
      int postModified = preModified + 5;
      return postModified; 
    }

    // Implements the template above based on specific stat
    public void EarlyGenAttack(Pokemon pokemon)
    {
      int baseAttack = pokemon.GetBaseStat().GetBaseAttack();
      int attackIV = pokemon.GetStatValue().GetIndividualValue().GetAttackIV();
      int attackEV = pokemon.GetStatValue().GetEffortValue().GetAttackEV();
      int level = pokemon.GetGeneration().GetDescription().GetLevel();
      int attack = CalculateEarlyGenStat(baseAttack, attackIV, attackEV, level);
      pokemon.GetStat().SetAttack(attack);
    }

    public void EarlyGenDefense(Pokemon pokemon)
    {
      int baseDefense = pokemon.GetBaseStat().GetBaseDefense();
      int defenseIV = pokemon.GetStatValue().GetIndividualValue().GetDefenseIV();
      int defenseEV = pokemon.GetStatValue().GetEffortValue().GetDefenseEV();
      int level = pokemon.GetGeneration().GetDescription().GetLevel();
      int defense = CalculateEarlyGenStat(baseDefense, defenseIV, defenseEV, level);
      pokemon.GetStat().SetDefense(defense);
    }

    public void EarlyGenSpAttack(Pokemon pokemon)
    {
      int baseSpAttack = pokemon.GetBaseStat().GetBaseSpAttack();
      int spAttackIV = pokemon.GetStatValue().GetIndividualValue().GetSpAttackIV();
      int spAttackEV = pokemon.GetStatValue().GetEffortValue().GetSpAttackEV();
      int level = pokemon.GetGeneration().GetDescription().GetLevel();
      int spAttack = CalculateEarlyGenStat(baseSpAttack, spAttackIV, spAttackEV, level);
      pokemon.GetStat().SetSpecialAttack(spAttack);
    }

    public void EarlyGenSpDefense(Pokemon pokemon)
    {
      int baseSpDefense = pokemon.GetBaseStat().GetBaseSpDefense();
      int spDefenseIV = pokemon.GetStatValue().GetIndividualValue().GetSpDefenseIV();
      int spDefenseEV = pokemon.GetStatValue().GetEffortValue().GetSpDefenseEV();
      int level = pokemon.GetGeneration().GetDescription().GetLevel();
      int spDefense = CalculateEarlyGenStat(baseSpDefense, spDefenseIV, spDefenseEV, level);
      pokemon.GetStat().SetSpDefense(spDefense);
    }

    public void EarlyGenSpeed(Pokemon pokemon)
    {
      int baseSpeed = pokemon.GetBaseStat().GetBaseSpeed();
      int speedIV = pokemon.GetStatValue().GetIndividualValue().GetSpeedIV();
      int speedEV = pokemon.GetStatValue().GetEffortValue().GetSpeedEV();
      int level = pokemon.GetGeneration().GetDescription().GetLevel();
      int speed = CalculateEarlyGenStat(baseSpeed, speedIV, speedEV, level);
      pokemon.GetStat().SetSpeed(speed);
    }
  }
}
