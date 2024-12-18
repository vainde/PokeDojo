// Represents the blueprint for all moves
using PokeDojo.src.Data.Type;
using PokeDojo.src.Poke;
using PokeDojo.src.Battle;

namespace PokeDojo.src.Data.Moves
{
  public class Move
  {
    // Only assigned in constructor so I am setting it to readonly as a standard
    readonly double accuracy;
    readonly int priority;
    bool highCrit;
    readonly Action<Pokemon, Pokemon> UseMove;
    readonly MoveInfo moveInfo;
    int damage;

    public Move(MoveInfo moveInfo, Action<Pokemon, Pokemon> useMove, double accuracy = 1, int priority = 0)
    {
      UseMove = useMove;
      this.moveInfo = moveInfo;
      this.priority = priority;
      this.accuracy = accuracy;
      highCrit = false;
      damage = 0;
    }

    public double GetAccuracy()
    {
      return accuracy;
    }

    public void SetHighCrit(bool value)
    {
      highCrit = value;
    }

    public bool GetHighCrit()
    {
      return highCrit;
    }
    public int GetPriority()
    {
      return priority;
    }

    public MoveInfo GetMoveInfo()
    {
      return moveInfo;
    }

    public void PerformUseMove(Pokemon self, Pokemon target)
    {
      if (UseMove != null)
      {
        Random rand = new Random();
        if (rand.Next(0, 1) < accuracy)
        {
          SetDamage(self, target, this);
          UseMove.Invoke(self, target);
        }
        else
        {
          Console.WriteLine("But it missed!");
        }
      }
    }

    // Returns the modifier based on type advantage
    public double GetTypeAdvantage(Pokemon target, int index)
    {
        string targetType = target.GetPokemonType()[index].GetName();
        PokemonType moveType = moveInfo.GetMoveType();

        List<string> strongAgainst = moveType.GetMoveType().GetStrongAgainst();
        List<string> neutralAgainst = moveType.GetMoveType().GetNeutralAgainst();
        List<string> weakAgainst = moveType.GetDefensiveType().GetWeakAgainst();

        if (neutralAgainst.Contains(targetType))
          return 1;

        else if (strongAgainst.Contains(targetType))
          return 2;

        else if (weakAgainst.Contains(targetType))
          return 0.5;

        else
          return 0;
    }

    public void SetDamage(Pokemon self, Pokemon target, Move move)
    {
      damage = Damage.Gen1Damage(self, target, this);
    }
  }
}