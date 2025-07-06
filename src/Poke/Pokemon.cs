// Represents the blueprint of a pokemon
using PokeDojo.src.Data.Type;
using PokeDojo.src.Data.Stats;
using PokeDojo.src.Data.Value;
using PokeDojo.src.Data.Moves;
using PokeDojo.src.Data.Statuses;
using PokeDojo.src.Data;
namespace PokeDojo.src.Poke
{
  public class Pokemon
  {
    public string? Name;
    public int Level;
    public Stat Stat { get; } = new Stat();
    public BaseStat BaseStat { get; }
    public StatValue Value { get; } = new StatValue();
    public List<PokemonType> Type { get; } = [];
    public List<Move> Moves { get; } = [];
    public Status Status { get; }
    public Pokemon(BaseStat baseStat, List<PokemonType> type, string name)
    {
      Dictionary<string, Status> Statuses = Initialize.Status();
      BaseStat = baseStat;
      Type = type;
      Status = Statuses["OK"];
      Level = 1;
    }
  }
        
}
