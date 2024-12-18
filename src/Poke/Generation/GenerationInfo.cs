using PokeDojo.src.Data;
using PokeDojo.src.Data.Type;
using PokeDojo.src.Poke.Generation.Descriptor;

namespace PokeDojo.src.Poke.Generation
{
    public class GenerationInfo
    {
        int generation;
        Description description;
        Gender gender;
        PokemonType hiddenPower;
        int happiness;

        public GenerationInfo()
        {
            List<PokemonType> Types = Initialize.Types();
            generation = 1;
            description = new Description();
            gender = new Gender();
            hiddenPower = new PokemonType("Default", Types[0].GetMoveType(), Types[0].GetDefensiveType());
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

        public void SetGeneration(int generation)
        {
            this.generation = generation;
        }
    }
}
