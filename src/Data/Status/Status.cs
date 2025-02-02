using PokeDojo.src.Poke;

namespace PokeDojo.src.Data.Statuses
{
  //modify to account for generation differences
  public class Status(string name, string description, Action<Pokemon> onPokemon)
  {
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public Action<Pokemon> ApplyStatus { get; set; } = onPokemon;

    public void Apply(Pokemon self)
    {
      ApplyStatus?.Invoke(self);
    }
  }
}
