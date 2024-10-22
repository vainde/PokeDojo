// Represents the gender of the pokemon and it's behavior

namespace PokeDojo.Stats
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
      this.value = gender;
    }

    public void SetGenderRatio(double genderRatio)
    {
      this.genderRatio = genderRatio;
    }

    public void RandomizeGender()
    {
      if(genderRatio >= 0.5)
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
