// Responsible for extending the pokemon base class for gen 2 content
using PokeDojo.Descriptor;
using PokeDojo.Stats;
using PokeDojo.Value;
using PokeDojo.Types;

namespace PokeDojo.Poke
{
  class Gen2Pokemon : Pokemon
  {
    Gen2Description description;
    Gender gender;

    public Gen2Pokemon(Gen2Description description, Stat stat, BaseStat baseStat, StatValue value, Gender gender, PokemonType type) : base(description, stat, baseStat, value, type)
    {
      this.description = description;
      this.gender = gender;
    }

    public Gender GetGender()
    {
      return gender;
    }

    public new Gen2Description GetDescription()
    {
      return description;
    }
  }
}
