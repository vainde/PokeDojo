// List of pokemon that represents the overused category

// List of pokemon that represents the overused category
using PokeDojo.src.Poke;
namespace PokeDojo.src.OU
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
