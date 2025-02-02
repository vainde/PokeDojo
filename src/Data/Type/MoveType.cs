namespace PokeDojo.src.Data.Type
{
  public class MoveType(string name, List<string> strongAgainst, List<string> neutralAgainst, List<string> resistantAgainst, List<string> nullAgainst)
  {
    public string Name { get; } = name;
    public List<string> StrongAgainst { get; } = strongAgainst;
    public List<string> NeutralAgainst { get; } = neutralAgainst;
    public List<string> ResistantAgainst { get; } = resistantAgainst;
    public List<string> NullAgainst { get; } = nullAgainst;
  }
}

