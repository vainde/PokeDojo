using PokeDojo.src.Poke;

namespace PokeDojo.src.Data.Items
{
    public class Item
    {
        public string Name { get; set; }
        public string Description {  get; set; }
        public Action<Pokemon> UseItem {  get; set; }

        public Item(string name, string description, Action<Pokemon> useItem)
        {
          Name = name;
          Description = description;
          UseItem = useItem;
        }

        public void PerformUseItem(Pokemon onPokemon)
        {
          UseItem.Invoke(onPokemon);
        }

        // Some items are single use so they are removed after using
        public void RemoveItem()
        {
          Name = "";
          Description = "";
        }
    }
}
