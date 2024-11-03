using PokeDojo.src.Poke;

namespace PokeDojo.src.Data.Items
{
    public class Item
    {
        string name;
        string description;
        readonly Action<Pokemon> UseItem;
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

        // Some items are single use so they are removed after using
        public void RemoveItem()
        {
          name = "";
          description = "";
        }
    }
}
