// Represents the blueprint of a pokemon
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
    public Stat Stat { get; }
    public BaseStat BaseStat { get; }
    public StatValue Value { get; }
    public List<PokemonType> Type { get; }
    public GenerationInfo Generation { get; }
    public List<Move> Moves { get; }
    public Status Status { get; }
    public List<int> AllPowerPoints { get; }
    public Pokemon(Stat stat, BaseStat baseStat, StatValue value, List<PokemonType> type, GenerationInfo generation, List<Move> moves, Status status)
    {
      Stat = stat;
      BaseStat = baseStat;
      Value = value;
      Type = type;
      Generation = generation;
      Moves = moves;
      Status = status;
      AllPowerPoints = [];
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
