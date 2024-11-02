// Represents the blueprint of a pokemon
using PokeDojo.src.Generation;
using PokeDojo.src.Stats;
using PokeDojo.src.Type;
using PokeDojo.src.Value;
using PokeDojo.src.Items;

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
