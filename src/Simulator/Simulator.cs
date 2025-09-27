using PokeDojo.src.Data;
using PokeDojo.src.Poke;
using PokeDojo.src.Data.Type;
using PokeDojo.src.Data.Moves;
using PokeDojo.src.Battles;
using PokeDojo.src.Simulator.Team;
using System.Collections.Generic;
using PokeDojo.src.Simulator.User;
using System.Numerics;

namespace PokeDojo.src.Simulator
{
    static class Simulator
    {
        static void Main()
        {
          Player player = new();
          // Pokemon need type, moves and status to pull from
          Dictionary<string, PokemonType> Types = Initialize.Types();
          Dictionary<string, Move> Moves = Initialize.Moves();

          // Use Squirtle and Charmander as dummy pokemon

          //SecondGenSnorlax.Value.GetIndividualValue().SetIndividualValue(15, 15, 15, 15, 15, 15);
          //SecondGenSnorlax.Value.GetEffortValue().SetEffortValue(65535, 65535, 65535, 65535, 65535, 65535);

          // Need a main menu for Party Options, Summary and Battle
          Console.WriteLine("Welcome to PokeDojo!");
          Console.WriteLine("Created by hikipeach");
          Console.WriteLine("Would you like to know more about PokeDojo?");
          Console.WriteLine("Yes [Y]");
          Console.WriteLine("No [N]");
          Console.Write(">");
          string about_user_input = Console.ReadLine()!;
          about_user_input = about_user_input.ToLower();
          if(about_user_input == "y")
          {
            Console.WriteLine("PokeDojo is an offline pokemon battle simulator where you fight against AI trainers.");
            Console.WriteLine("There is one game mode: Regular");
            Console.WriteLine("In regular battles, you will create your own team and battle against an AI trainer that has a preset team.");
          }
          Console.WriteLine("POKEDOJO");
          int user_input = -1;
          while(user_input != 5)
          {
            Console.WriteLine("1. View Team(s)"); //within that add the summary option. also add summar to battle
            Console.WriteLine("2. Create a Team");
            Console.WriteLine("3. Update a Team");
            Console.WriteLine("4. Battle");
            Console.WriteLine("5. Quit");
            Console.Write(">");
            user_input = Convert.ToInt32((Console.ReadLine()!));
            switch (user_input)
            {
              case 1:
                if(player.Teams.Count == 0)
                {
                  Console.WriteLine("No teams found.");
                }
                else
                {
                  player.DisplayTeams();
                }
                break;
              case 2:
                Console.WriteLine("What would you like to name your team?");
                string partyName = Console.ReadLine()!;
                Party party = new(partyName);
                player.Teams.Add(party);
                player.SaveTeams();
                break;
              case 3:
                if(player.Teams.Count == 0)
                {
                  Console.WriteLine("You do not have any teams to update. Please create a team first!");
                }
                else
                {
                  Console.WriteLine("Select the pokemon team you would like to update.");
                  for(int i = 0; i < player.Teams.Count; i++)
                  {
                    Console.WriteLine($"{i + 1}. {player.Teams[i].Name}");
                  }
                  int team = Convert.ToInt32(Console.ReadLine()!);
                  if(team < 1 || team > player.Teams.Count)
                  {
                    Console.WriteLine("Error: Invalid team selection.");
                  }
                  else
                  {
                    player.UpdateTeam(player.Teams[team - 1]);
                  }
                }
                break;
              case 4:
                if (player.Teams.Count == 0)
                {
                  Console.WriteLine("Error: Must have at least 1 team to battle.");
                }
                else
                {
                  Party playerTeam = SelectTeam(player);
                  if (playerTeam == null)
                  {
                    Console.WriteLine("Error selecting team.");
                  }
                  else
                  {
                    // randomize enemy here
                    Console.WriteLine("Battle starting...");
                  }
                }
              break;
              case 5:
                Console.WriteLine($"Goodbye!");
                break;
              default:
                Console.WriteLine("Invalid selection.");
                break;
            }
          }
        }

      static Party SelectTeam(Player player)
      {
        Console.WriteLine("SELECT TEAM");
        Console.WriteLine("Select the team you would like to send out into battle.");
        for (int i = 0; i < player.Teams.Count; i++)
        {
          Console.WriteLine($"{i + 1}. {player.Teams[i].Name}");
        }
        int teamSelection = Convert.ToInt32(Console.ReadLine());
        bool validTeam = teamSelection < 1 || teamSelection > player.Teams.Count;
        if (teamSelection < 1 || teamSelection > player.Teams.Count)
        {
          return null!;
        }
        else
        {
          Party team = player.Teams[teamSelection - 1];
          if (team.Team.Count == 0)
          {
            return null!;
          }
          else
          {
            Console.WriteLine($"Player selected team: {team.Name}");
            return player.Teams[teamSelection - 1];
          }
        }
      }
    }
}
