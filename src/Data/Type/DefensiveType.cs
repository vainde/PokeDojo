using System;

namespace PokeDojo.src.Data.Type
{
  public class DefensiveType
  {
    readonly string name;
    readonly List<string> weakAgainst;
    readonly List<string> neutralAgainst;
    readonly List<string> resistantAgainst;
    readonly List<string> nullAgainst;

    public DefensiveType(string name, List<string> weakAgainst, List<string> neutralAgainst, List<string> resistantAgainst, List<string> nullAgainst)
    {
      this.name = name;
      this.weakAgainst = weakAgainst;
      this.neutralAgainst = neutralAgainst;
      this.resistantAgainst = resistantAgainst;
      this.nullAgainst = nullAgainst;
    }

    public List<string> GetWeakAgainst()
    {
      return weakAgainst;
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

