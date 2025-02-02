// Represents the gender of the pokemon and it's behavior

namespace PokeDojo.src.Poke.Generation.Descriptor
{
    public class Gender
    {
        public string? Value { get; set; }
        public double GenderRatio { get; set; }

        public Gender()
        {
            RandomizeGender();
            GenderRatio = 0.0;
        }

        public void RandomizeGender()
        {
            Random rand = new();
            if (rand.Next(0, 1) >= GenderRatio)
            {
                Value = "Male";
            }
            else
            {
                Value = "Female";
            }
        }
    }
}
