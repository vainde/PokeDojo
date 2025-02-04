// Represents the blueprint of a pokemon
using PokeDojo.src.Data.Type;
using PokeDojo.src.Data.Stats;
using PokeDojo.src.Data.Value;
using PokeDojo.src.Poke.Generation;
using PokeDojo.src.Data.Moves;
using PokeDojo.src.Data.Statuses;
using PokeDojo.src.Data;
namespace PokeDojo.src.Poke
{
  public class Pokemon
  {
    public Stat Stat { get; } = new Stat();
    public BaseStat BaseStat { get; }
    public StatValue Value { get; } = new StatValue();
    public List<PokemonType> Type { get; } = [];
    public GenerationInfo Generation { get; } = new GenerationInfo();
    public List<Move> Moves { get; } = [];
    public Status Status { get; }
    public List<int> AllPowerPoints { get; } = [];
    public Pokemon(BaseStat baseStat, List<PokemonType> type)
    {
      Dictionary<string, Status> Statuses = Initialize.Status();
      BaseStat = baseStat;
      Type = type;
      Status = Statuses["OK"];
      SetCurrentPowerPoints();
    }

    public void SetCurrentPowerPoints()
    {
      foreach (Move move in Moves)
      {
        int currentPP = move.GetMoveInfo().PowerPoint;
        AllPowerPoints.Add(currentPP);
      }
    }

    public void DecreasePowerPoint(Move move)
    {
      int idx = Moves.IndexOf(move);
      AllPowerPoints[idx] -= 1;
    }
  }
        
}
