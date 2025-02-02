// Abstraction of the HUD in-battle
namespace PokeDojo.src.Poke.Generation.Descriptor
{
    public class Description
    {
        public string Name {  get; set; }
        public int Level {  get; set; }
        public Description()
        {
            Name = "";
            Level = 100;
        }
    }
}
