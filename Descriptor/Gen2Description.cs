// Responsible for extending the original gen 1 description based on new gen 2 content
using PokeDojo.Types;

namespace PokeDojo.Descriptor
{
  class Gen2Description : Description
  {

    int happiness;
    PokemonType hiddenPower;

    public Gen2Description() : base ()
    {
      this.hiddenPower = new PokemonType("Normal");
      this.happiness = 0;
    }

    public void SetHappiness(int happiness)
    {
      if(happiness <= 255)
      {
        this.happiness = happiness;
      }
    }

    public void SetHiddenPower(PokemonType type)
    {
      hiddenPower = type;
    }
    public int GetHappiness()
    {
      return happiness;
    }

    public PokemonType GetHiddenPower()
    {
      return hiddenPower;
    }
  }
}
