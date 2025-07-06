using PokeDojo.src.Data;
using PokeDojo.src.Poke;
using PokeDojo.src.Data.Type;
using PokeDojo.src.Data.Moves;
using PokeDojo.src.Battles;
using PokeDojo.src.Simulator.Team;

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

          Party party = new Party();

          // Need a main menu for Party Options, Summary and Battle
          
          int option = -1;
          while (option != 3)
          {
            option = party.CreateATeam();
          }
        
          List<Pokemon> team1 = [];
          List<Pokemon> team2 = [];

          Battle battle = new(team1, team2);
          battle.HandleTurn();
        }
    }
}
