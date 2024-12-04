// Responsible for defining the type system in pokemon used for their type and moves
using PokeDojo.src.Poke;
namespace PokeDojo.src.Data.Type
{
    public class PokemonType
    {
        string name;
        readonly List<string> strongAgainst;
        readonly List<string> neutralAgainst;
        readonly List<string> resistantAgainst;
        readonly List<string> weakAgainst;
        readonly List<string> nullAgainst;

        public PokemonType(string name, List<string> strongAgainst, List<string> neutralAgainst, List<string> resistantAgainst, List<string> nullAgainst, List<string> weakAgainst)
        {
          this.name = name;
          this.strongAgainst = strongAgainst;
          this.neutralAgainst = neutralAgainst;
          this.resistantAgainst = resistantAgainst;
          this.weakAgainst = weakAgainst;
          this.nullAgainst = nullAgainst;
        }

        public List<string> GetStrongAgainst()
        {
          return strongAgainst;
        }

        public List<string> GetNeutralAgainst()
        {
          return neutralAgainst;
        }

        public List<string> GetResistantAgainst()
        {
          return resistantAgainst;
        }

        public List<string> GetWeakAgainst()
        {
          return weakAgainst; 
        }

        public List<string> GetNullAgainst()
        {
          return nullAgainst;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
    }
}
