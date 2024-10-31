// Represents the blueprint of a pokemon
using PokeDojo.Stats;
using PokeDojo.Descriptor;
using PokeDojo.Value;
using PokeDojo.Types;

namespace PokeDojo.Poke
{
    class Pokemon
    {
        Description description;
        Stat stat;
        BaseStat baseStat;
        StatValue value;
        PokemonType type;
        public Pokemon(Description description, Stat stat, BaseStat baseStat, StatValue value, PokemonType type)
        {
          this.description = description;
          this.stat = stat;
          this.baseStat = baseStat;
          this.value = value;
          this.type = type;  
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

        public PokemonType GetPokemonType()
        {
          return type;
        }
    }
}
