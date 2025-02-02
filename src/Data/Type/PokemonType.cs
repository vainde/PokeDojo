// Responsible for defining the type system in pokemon used for their type and moves
namespace PokeDojo.src.Data.Type
{
  public class PokemonType(string name, MoveType moveType, DefensiveType defenseType)
  {
    public string Name { get; } = name;
    public MoveType MoveType { get; } = moveType;
    public DefensiveType DefenseType { get; } = defenseType;
  }
}
