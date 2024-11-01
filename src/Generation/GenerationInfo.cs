using PokeDojo.src.Descriptor;
using PokeDojo.src.Stats;
using PokeDojo.src.Type;

namespace PokeDojo.src.Generation
{
    class GenerationInfo
    {
        int generation;
        Description description;
        Gender gender;
        PokemonType hiddenPower;
        int happiness;

        public GenerationInfo(int generation, Description description)
        {
            this.generation = generation;
            this.description = description;
            gender = new Gender();
            hiddenPower = new PokemonType("");
            happiness = 0;
        }
        public Gender GetGender()
        {
            return gender;
        }

        public Description GetDescription()
        {
            return description;
        }

        public void SetHappiness(int happiness)
        {
            if (happiness <= 255)
            {
                this.happiness = happiness;
            }
        }

        public void SetHiddenPower(PokemonType type)
        {
            hiddenPower = type;
        }
        public int GetHappiness()
        {
            return happiness;
        }

        public PokemonType GetHiddenPower()
        {
            return hiddenPower;
        }

        public int GetGeneration()
        {
            return generation;
        }
    }
}
