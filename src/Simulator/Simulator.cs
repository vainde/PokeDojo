using PokeDojo.src.Data;
using PokeDojo.src.Poke;
using PokeDojo.src.Data.Type;
using PokeDojo.src.Data.Stats;
using PokeDojo.src.Data.Value;
using PokeDojo.src.Data.Moves;
using PokeDojo.src.Data.Statuses;
using PokeDojo.src.Battles;

namespace PokeDojo.src.Simulator
{
    static class Simulator
    {
        static void Main()
        {
          // Pokemon need type, moves and status to pull from
          Dictionary<string, PokemonType> Types = Initialize.Types();
          Dictionary<string, Move> Moves = Initialize.Moves();

          // Use Squirtle and Charmander as dummy pokemon

          //SecondGenSnorlax.Value.GetIndividualValue().SetIndividualValue(15, 15, 15, 15, 15, 15);
          //SecondGenSnorlax.Value.GetEffortValue().SetEffortValue(65535, 65535, 65535, 65535, 65535, 65535);
        
          List<Pokemon> team1 = [];
          List<Pokemon> team2 = [];

          Battle battle = new(team1, team2);
          battle.HandleTurn();
        }
    }
}
