// Represents the blueprint of a pokemon
using PokeDojo.src.Descriptor;
using PokeDojo.src.Generation;
using PokeDojo.src.Stats;
using PokeDojo.src.Type;
using PokeDojo.src.Value;

namespace PokeDojo.src.Poke
{
    class Pokemon
    {
        Stat stat;
        BaseStat baseStat;
        StatValue value;
        PokemonType type;
        GenerationInfo generation;
        public Pokemon(Stat stat, BaseStat baseStat, StatValue value, PokemonType type, GenerationInfo generation)
        {
            this.stat = stat;
            this.baseStat = baseStat;
            this.value = value;
            this.type = type;
            this.generation = generation;
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
    }
}
