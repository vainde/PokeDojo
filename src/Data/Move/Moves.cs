// Represents the blueprint for all moves
using PokeDojo.src.Data.Type;
using PokeDojo.src.Poke;

namespace PokeDojo.src.Data.Moves
{
  public class Move
  {
    // Only assigned in constructor so I am setting it to readonly as a standard
    readonly string name;
    readonly PokemonType type;
    string category;
    readonly int basePower;
    readonly double accuracy;
    readonly int powerPoint;
    readonly int priority;
    bool highCrit;
    readonly Action<Pokemon, Pokemon> UseMove;

    public Move(string name, PokemonType type, int basePower, double accuracy, int powerPoint, int priority, Action<Pokemon, Pokemon> useMove)
    {
      this.name = name;
      this.type = type;
      this.basePower = basePower;
      this.accuracy = accuracy;
      this.powerPoint = powerPoint;
      this.priority = priority;
      highCrit = false;
      UseMove = useMove;
      category = "";
    }

    public string GetName()
    {
      return name;
    }

    public PokemonType GetMoveType()
    {
      return type;
    }

    public string GetCategory()
    {
      return category;
    }

    public int GetBasePower()
    {
      return basePower;
    }

    public double GetAccuracy()
    {
      return accuracy;
    }

    public int GetPowerPoint()
    {
      return powerPoint;
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

    public void PerformUseMove(Pokemon self, Pokemon target)
    {
      if (UseMove != null)
      {
        UseMove.Invoke(self, target);
      }
    }

    public void SetCategory(Pokemon self)
    {
      //Set two arrays that represent the types that belong to special or physical
      string[] special = ["Normal", "Fighting", "Flying", "Poison", "Ground", "Rock", "Bug", "Ghost", "Steel"];

      if (special.Contains(GetName()))
        category = "Special";
      else
        category = "Physical";
    }

    // Returns the modifier based on type advantage
    public double GetTypeAdvantage(Pokemon target, int index)
    {
        string targetType = target.GetPokemonType()[index].GetName();
        PokemonType moveType = GetMoveType();

        List<string> strongAgainst = moveType.GetStrongAgainst();
        List<string> neutralAgainst = moveType.GetNeutralAgainst();
        List<string> weakAgainst = moveType.GetWeakAgainst();

        if (neutralAgainst.Contains(targetType))
          return 1;

        else if (strongAgainst.Contains(targetType))
          return 2;

        else if (weakAgainst.Contains(targetType))
          return 0.5;

        else
          return 0;
    }
  }
}