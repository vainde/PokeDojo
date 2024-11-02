using PokeDojo.src.Poke;

namespace PokeDojo.src.Items
{
  public class Item
  {
    string name;
    string description;
    Action<Pokemon> UseItem;
    public Item(string name, string description, Action<Pokemon> UseItem)
    {
      this.name = name;
      this.description = description;
      this.UseItem = UseItem;
    }

    public void PerformUseItem(Pokemon onPokemon)
    {
      if (UseItem != null)
      {
        UseItem.Invoke(onPokemon);
      }
    }

    public string GetName()
    {
      return name;
    }

    public string GetDescription()
    {
      return description;
    }
  }
}
