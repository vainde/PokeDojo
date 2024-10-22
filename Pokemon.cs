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
        public Pokemon(Description description, Stat stat, BaseStat baseStat, StatValue statValue, Gender gender)
        {
            this.description = description;
            this.stat = stat;
            this.baseStat = baseStat;
            this.value = statValue;
            this.gender = gender;
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
    }
}
