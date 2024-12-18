// Represents the blueprint of a pokemon
using PokeDojo.src.Data.Items;
using PokeDojo.src.Data.Type;
using PokeDojo.src.Data.Stats;
using PokeDojo.src.Data.Value;
using PokeDojo.src.Poke.Generation;
using PokeDojo.src.Data.Moves;
using PokeDojo.src.Data.Statuses;

namespace PokeDojo.src.Poke
{
    public class Pokemon
    {
        readonly Stat stat;
        readonly BaseStat baseStat;
        readonly StatValue value;
        readonly List <PokemonType> type;
        readonly GenerationInfo generation;
        readonly Item item;
        readonly List<Move> moves;
        readonly Status status;
        public Pokemon(Stat stat, BaseStat baseStat, StatValue value, List<PokemonType> type, GenerationInfo generation, Item item, List<Move> moves, Status status)
    {
        this.stat = stat;
        this.baseStat = baseStat;
        this.value = value;
        this.type = type;
        this.generation = generation;
        this.item = item;
        this.moves = moves;
        this.status = status;
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

        public List<PokemonType> GetPokemonType()
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

       public List<Move> GetMoves()
       {
          return moves;
       }

      public Status GetStatus()
      {
        return status;
      }
    }
}
