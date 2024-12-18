using System;

namespace PokeDojo.src.Data.Type
{
  public class MoveType
  {
    readonly string name;
    readonly List<string> strongAgainst;
    readonly List<string> neutralAgainst;
    readonly List<string> resistantAgainst;
    readonly List<string> nullAgainst;

    public MoveType(string name, List<string> strongAgainst, List<string> neutralAgainst, List<string> resistantAgainst, List<string> nullAgainst)
    {
      this.name = name;
      this.strongAgainst = strongAgainst;
      this.neutralAgainst = neutralAgainst;
      this.resistantAgainst = resistantAgainst;
      this.nullAgainst = nullAgainst;
    }

    public List<string> GetStrongAgainst()
    {
      return strongAgainst;
    }

    public List<string> GetNeutralAgainst()
    {
      return neutralAgainst;
    }

    public List<string> GetResistantAgainst()
    {
      return resistantAgainst;
    }

    public List<string> GetNullAgainst()
    {
      return nullAgainst;
    }

    public string GetName()
    {
      return name;
    }
  }
}

