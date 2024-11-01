// Responsible for defining the type system in pokemon used for their type and moves
namespace PokeDojo.src.Type
{
    class PokemonType
    {
        string name;
        List<PokemonType> strongAgainst;
        List<PokemonType> neutralAgainst;
        List<PokemonType> weakAgainst;
        List<PokemonType> nullAgainst;

        public PokemonType(string name)
        {
            this.name = name;
            strongAgainst = new List<PokemonType>();
            neutralAgainst = new List<PokemonType>();
            weakAgainst = new List<PokemonType>();
            nullAgainst = new List<PokemonType>();
        }

        public void SetStrongAgainst(List<PokemonType> strongAgainst)
        {
            this.strongAgainst = strongAgainst;
        }

        public void SetNeutralAgainst(List<PokemonType> neutralAgainst)
        {
            this.neutralAgainst = neutralAgainst;
        }

        public void SetWeakAgainst(List<PokemonType> weakAgainst)
        {
            this.weakAgainst = weakAgainst;
        }

        public void SetNullAgainst(List<PokemonType> nullAgainst)
        {
            this.nullAgainst = nullAgainst;
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
