// Represents the blueprint of a pokemon
using PokeDojo.src.Data.Items;
using PokeDojo.src.Data.Type;
using PokeDojo.src.Data.Stats;
using PokeDojo.src.Data.Value;
using PokeDojo.src.Poke.Generation;

namespace PokeDojo.src.Poke
{
    public class Pokemon
    {
        Stat stat;
        BaseStat baseStat;
        StatValue value;
        PokemonType type;
        GenerationInfo generation;
        Item item;
        public Pokemon(Stat stat, BaseStat baseStat, StatValue value, PokemonType type, GenerationInfo generation, Item item)
        {
            this.stat = stat;
            this.baseStat = baseStat;
            this.value = value;
            this.type = type;
            this.generation = generation;
            this.item = item;
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

        public GenerationInfo GetGeneration()
        {
            return generation;
        }

        public Item GetItem()
        {
          return item;
        }
    }
}
