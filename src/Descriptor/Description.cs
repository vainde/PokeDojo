// Abstraction of the HUD in-battle
namespace PokeDojo.src.Descriptor
{
    class Description
    {
        string name;
        int level;
        int generation;
        public Description()
        {
            name = "";
            level = 100;
            generation = 1;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetLevel(int level)
        {
            this.level = level;
        }

        public void SetGeneration(int generation)
        {
            this.generation = generation;
        }

        public string GetName()
        {
            return name;
        }

        public int GetLevel()
        {
            return level;
        }

        public int GetGeneration()
        {
            return generation;
        }
    }
}
