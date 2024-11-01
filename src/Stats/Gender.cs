// Represents the gender of the pokemon and it's behavior

namespace PokeDojo.src.Stats
{
    class Gender
    {
        string value;
        double genderRatio;

        public Gender()
        {
            value = "Male";
            genderRatio = 0.0;
        }

        public string GetGender()
        {
            return value;
        }

        public double GetGenderRatio()
        {
            return genderRatio;
        }
        public void SetGender(string gender)
        {
            value = gender;
        }

        public void SetGenderRatio(double genderRatio)
        {
            this.genderRatio = genderRatio;
        }

        // For AI trainers
        public void RandomizeGender()
        {
            if (genderRatio >= 0.5)
            {
                value = "Male";
            }
            else
            {
                value = "Female";
            }
        }
    }
}
