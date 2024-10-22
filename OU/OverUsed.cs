// List of pokemon that represents the overused category
using PokeDojo;

namespace PokeDojo.OU
{
  class OverUsed
  {
    List<Pokemon> overused;

    public OverUsed()
    {
     overused = new List<Pokemon>();
    }

    public void AddPokemon(Pokemon pokemon)
    {
      overused.Add(pokemon);
    }
  }
}
