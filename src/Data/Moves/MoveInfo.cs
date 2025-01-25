using PokeDojo.src.Data.Type;

namespace PokeDojo.src.Data.Moves
{ 
  public class MoveInfo
  {
    readonly string name;
    readonly string description;
    readonly PokemonType type;
    string category;
    readonly int basePower;
    readonly int powerPoint;
    readonly int generationIntroduced;
    bool highCrit;
    public MoveInfo(string name, string description, PokemonType type, int basePower, int powerPoint, int generationIntroduced)
    {
      this.name = name;
      this.description = description;
      this.type = type;
      this.basePower = basePower;
      this.powerPoint = powerPoint;
      this.generationIntroduced = generationIntroduced;
      highCrit = false;
      SetCategory();
    }

    public void SetHighCrit()
    {
      highCrit = true;
    }
    public bool GetHighCrit()
    {
      return highCrit;
    }

    public string GetName()
    {
      return name;
    }
    
    public string GetDescription() { 
      return description;
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

    public int GetPowerPoint()
    {
      return powerPoint;
    }

    public int GetGenerationIntroduced()
    {
      return generationIntroduced;
    }
    public void SetCategory()
    {
      //Set two arrays that represent the types that belong to special or physical
      string[] special = ["Normal", "Fighting", "Flying", "Poison", "Ground", "Rock", "Bug", "Ghost", "Steel"];

      if (special.Contains(GetName()))
        category = "Special";
      else
        category = "Physical";
    }
  }
}
