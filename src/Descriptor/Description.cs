// Abstraction of the HUD in-battle
namespace PokeDojo.src.Descriptor
{
    public class Description
    {
        string name;
        int level;
        public Description()
        {
            name = "";
            level = 100;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetLevel(int level)
        {
            this.level = level;
        }

        public string GetName()
        {
            return name;
        }

        public int GetLevel()
        {
            return level;
        }
    }
}
