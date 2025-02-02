// Represents the blueprint for all moves
using PokeDojo.src.Data.Type;
using PokeDojo.src.Poke;
using PokeDojo.src.Battles;

namespace PokeDojo.src.Data.Moves
{
  public class Move
  {
    // Only assigned in constructor so I am setting it to readonly as a standard
    readonly double accuracy;
    readonly int priority;
    bool critHappened;
    readonly Action<Pokemon, Pokemon> UseMove;
    readonly MoveInfo moveInfo;
    int damage;

    public Move(MoveInfo moveInfo, Action<Pokemon, Pokemon> useMove, double accuracy = 1, int priority = 0)
    {
      UseMove = useMove;
      this.moveInfo = moveInfo;
      this.priority = priority;
      this.accuracy = accuracy;
      critHappened = false;
      damage = 0;
    }

    public void SetCritHappened()
    {
      critHappened = true;
    }

    public void ResetCritHappened()
    {
      critHappened = false;
    }

    public double GetAccuracy()
    {
      return accuracy;
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
        Random rand = new();
        if (rand.Next(0, 1) < accuracy)
        {
          SetDamage(self, target);
          UseMove.Invoke(self, target);
          int targetCurrentHP = target.Stat.CurrentHealth;
          target.Stat.CurrentHealth = targetCurrentHP - damage;
          if(target.Stat.CurrentHealth <= 0)
          {
            target.Stat.CurrentHealth = 0;
          }
          if (critHappened)
          {
            string name = self.Generation.Description.Name;
            Console.WriteLine($"{name} landed a critical hit!");
          }
        }
        else
        {
          Console.WriteLine("But it missed!");
        }
      }
      ResetCritHappened();
    }

    // Returns the modifier based on type advantage
    public double GetTypeAdvantage(Pokemon target, int index)
    {
        string targetType = target.Type[index].Name;
        PokemonType moveType = moveInfo.Type;

        List<string> strongAgainst = moveType.MoveType.StrongAgainst;
        List<string> neutralAgainst = moveType.MoveType.NeutralAgainst;
        List<string> weakAgainst = moveType.DefenseType.WeakAgainst;

        if (neutralAgainst.Contains(targetType))
          return 1;

        else if (strongAgainst.Contains(targetType))
          return 2;

        else if (weakAgainst.Contains(targetType))
          return 0.5;

        else
          return 0;
    }

    public void SetDamage(Pokemon self, Pokemon target)
    {
      damage = Damage.Gen1Damage(self, target, this);
    }
  }
}