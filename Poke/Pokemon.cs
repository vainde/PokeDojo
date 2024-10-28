// Represents the blueprint of a pokemon
using PokeDojo.Stats;
using PokeDojo.Descriptor;
using PokeDojo.Value;

namespace PokeDojo.Poke
{
    class Pokemon
    {
        Description description;
        Stat stat;
        BaseStat baseStat;
        StatValue value;
        Gender gender;
        Nature nature;
        int generation;
        public Pokemon(Description description, Stat stat, BaseStat baseStat, StatValue value, Gender gender, Nature nature, int generation)
        {
          this.description = description;
          this.stat = stat;
          this.baseStat = baseStat;
          this.value = value;
          this.gender = gender;
          this.nature = nature;
          this.generation = generation;
        }
        public Description GetDescription()
        {
            return description;
        }
        public Stat GetStat()
        {
            return stat;
        }
        public BaseStat GetBaseStat()
        {
            return baseStat;
        }

        public StatValue GetStatValue()
        {
            return value;
        }

        public Gender GetGender()
        {
            return gender;
        }

        public Nature GetNature()
        {
            return nature;
        }

        public int GetGeneration()
        {
          return generation;
        }
    }
}
