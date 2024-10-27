// Represents the blueprint of a pokemon
using PokeDojo.Stats;
using PokeDojo.Descriptor;
using PokeDojo.Value;

namespace PokeDojo
{
    class Pokemon
    {
        Description description;
        Stat stat;
        BaseStat baseStat;
        StatValue value;
        Gender gender;
        Nature nature;
        public Pokemon(Description description, Stat stat, BaseStat baseStat, StatValue value, Gender gender, Nature nature)
        {
            this.description = description;
            this.stat = stat;
            this.baseStat = baseStat;
            this.value = value;
            this.gender = gender;
            this.nature = nature;
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
    }
}
