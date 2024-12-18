// Responsible for defining the type system in pokemon used for their type and moves
using PokeDojo.src.Poke;
namespace PokeDojo.src.Data.Type
{
  public class PokemonType
  {
    readonly string name;
    readonly MoveType moveType;
    readonly DefensiveType defenseType;

    public PokemonType(string name, MoveType moveType, DefensiveType defenseType)
    {
      this.name = name;
      this.moveType = moveType;
      this.defenseType = defenseType;
    }

    public string GetName()
    {
      return name;
    }

    public MoveType GetMoveType()
    {
      return moveType;
    }

    public DefensiveType GetDefensiveType()
    {
      return defenseType;
    }
  }
}
