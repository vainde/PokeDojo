// Represents the actual stats of the pokemon
using PokeDojo.src.Poke;

namespace PokeDojo.src.Data.Stats
{
    public class Stat
    {
        public int Health { get; set; } = 0;
        public int CurrentHealth { get; set; } = 0;
        public int Attack { get; set; } = 0;
        public int SpAttack { get; set; } = 0;
        public int Defense { get; set; } = 0;
        public int SpDefense { get; set; } = 0;
        public int Speed { get; set; } = 0;
        /*
         * Most natures will boost a stat by 10% and decrease one by 10% assuming it's not
         * neutral. We can apply the modifier here since the stats should control itself.
         */
        public static int IncreaseByNature(int increase)
        {
            increase *= (int)1.10;
            return increase;
        }

        public static int DecreaseByNature(int decrease)
        {
            decrease -= decrease * (int)0.1;
            return decrease;
        }

        public static void EarlyGenHealth(Pokemon pokemon)
        {
            int baseHealth = pokemon.BaseStat.Health;
            int healthIV = pokemon.Value.GetIndividualValue().GetHealthIV();
            int healthEV = pokemon.Value.GetEffortValue().GetHealthEV();
            int level = pokemon.Level;

            int combinedHealth = (baseHealth + healthIV) * 2;
            int dividedHealthEV = (int)(Math.Sqrt(healthEV) / 4);
            int preModified = (combinedHealth + dividedHealthEV) * level / 100;
            int postModified = preModified + level + 10;
            pokemon.Stat.Health = postModified;
            pokemon.Stat.CurrentHealth = postModified;
        }

        // Template for calculating non-health stats
        public static int CalculateEarlyGenStat(int baseStat, int IV, int EV, int level)
        {
            int handleBase = (baseStat + IV) * 2;
            int handleStatEXP = (int)Math.Sqrt(EV) / 4;
            int preModified = (handleBase + handleStatEXP) * level / 100;
            int postModified = preModified + 5;
            return postModified;
        }

        // Implements the template above based on specific stat
        public static void EarlyGenAttack(Pokemon pokemon)
        {
            int baseAttack = pokemon.BaseStat.Attack;
            int attackIV = pokemon.Value.GetIndividualValue().GetAttackIV();
            int attackEV = pokemon.Value.GetEffortValue().GetAttackEV();
            int level = pokemon.Level;
            int attack = CalculateEarlyGenStat(baseAttack, attackIV, attackEV, level);
            pokemon.Stat.Attack = attack;
        }

        public static void EarlyGenDefense(Pokemon pokemon)
        {
            int baseDefense = pokemon.BaseStat.Defense;
            int defenseIV = pokemon.Value.GetIndividualValue().GetDefenseIV();
            int defenseEV = pokemon.Value.GetEffortValue().GetDefenseEV();
            int level = pokemon.Level;
            int defense = CalculateEarlyGenStat(baseDefense, defenseIV, defenseEV, level);
            pokemon.Stat.Defense = defense;
        }

        public static void EarlyGenSpAttack(Pokemon pokemon)
        {
            int baseSpAttack = pokemon.BaseStat.SpAttack;
            int spAttackIV = pokemon.Value.GetIndividualValue().GetSpAttackIV();
            int spAttackEV = pokemon.Value.GetEffortValue().GetSpAttackEV();
            int level = pokemon.Level;
            int spAttack = CalculateEarlyGenStat(baseSpAttack, spAttackIV, spAttackEV, level);
            pokemon.Stat.SpAttack = spAttack;
        }

        public static void EarlyGenSpDefense(Pokemon pokemon)
        {
            int baseSpDefense = pokemon.BaseStat.SpDefense;
            int spDefenseIV = pokemon.Value.GetIndividualValue().GetSpDefenseIV();
            int spDefenseEV = pokemon.Value.GetEffortValue().GetSpDefenseEV();
            int level = pokemon.Level;
            int spDefense = CalculateEarlyGenStat(baseSpDefense, spDefenseIV, spDefenseEV, level);
            pokemon.Stat.SpDefense = spDefense;
        }

        public static void EarlyGenSpeed(Pokemon pokemon)
        {
            int baseSpeed = pokemon.BaseStat.Speed;
            int speedIV = pokemon.Value.GetIndividualValue().GetSpeedIV();
            int speedEV = pokemon.Level;
            int speed = CalculateEarlyGenStat(baseSpeed, speedIV, speedEV, pokemon.Level);
            pokemon.Stat.Speed = speed;
        }
    }
}
