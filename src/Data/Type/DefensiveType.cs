using System;

namespace PokeDojo.src.Data.Type
{
  public class DefensiveType(string name, List<string> weakAgainst, List<string> neutralAgainst, List<string> resistantAgainst, List<string> nullAgainst)
  {
    public string Name { get; set; } = name;
    public List<string> WeakAgainst { get; } = weakAgainst;
    public List<string> NeutralAgainst { get; } = neutralAgainst;
    public List<string> ResistantAgainst { get; } = resistantAgainst;
    public List<string> NullAgainst { get; } = nullAgainst;
  }
}

