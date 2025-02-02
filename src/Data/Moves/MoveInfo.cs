using PokeDojo.src.Data.Type;

namespace PokeDojo.src.Data.Moves
{ 
  public class MoveInfo(string name, string description, PokemonType type, int basePower, int powerPoint, int generation)
  {
    public string Name { get; } = name;
    public string Description { get; } = description;
    public PokemonType Type { get; } = type;
    public string? Category { get; set; }
    public int BasePower { get; } = basePower; 
    public int PowerPoint { get; } = powerPoint;
    public int GenIntroduced { get; } = generation;
    public bool HighCrit { get; set; } = false;

    public void SetHighCrit()
    {
      HighCrit = true;
    }
    
    public void SetCategory()
    {
      //Set two arrays that represent the types that belong to special or physical
      string[] special = ["Normal", "Fighting", "Flying", "Poison", "Ground", "Rock", "Bug", "Ghost", "Steel"];

      if (special.Contains(Name))
        Category = "Special";
      else
        Category = "Physical";
    }
  }
}
