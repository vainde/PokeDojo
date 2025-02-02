using PokeDojo.src.Data;
using PokeDojo.src.Data.Items;
using PokeDojo.src.Data.Type;
using PokeDojo.src.Poke.Generation.Descriptor;

namespace PokeDojo.src.Poke.Generation
{
    public class GenerationInfo
    {
        public int Generation { get; set;  }
        public Description Description { get; }
        public Gender Gender { get; }
        public PokemonType HiddenPower { get; set; }
        public int Happiness { get; set; }
        public Item Item { get; }

        public GenerationInfo()
        {
            List<PokemonType> Types = Initialize.Types();
            List<Item> Items = Initialize.Items();
            Generation = 1;
            Description = new Description();
            Gender = new Gender();
            HiddenPower = new PokemonType("Default", Types[0].MoveType, Types[0].DefenseType);
            Happiness = 0;
            Item = new Item(Items[0].Name, Items[0].Description, Items[0].PerformUseItem);
        }
    }
}
