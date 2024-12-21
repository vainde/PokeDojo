using System;
using PokeDojo.src.Data.Moves;
using PokeDojo.src.Data.Statuses;
using PokeDojo.src.Poke;

namespace PokeDojo.src.Battles
{
  class Battle
  {
    // Stores
    int turn;
    readonly bool forfeit;
    bool classic;
    readonly List<Pokemon> playerTeam;
    readonly List<Pokemon> enemyTeam;

    public Battle(List<Pokemon> playerTeam, List<Pokemon> enemyTeam)
    {
      turn = 1;
      forfeit = false;
      classic = false;
      this.playerTeam = playerTeam;
      this.enemyTeam = enemyTeam;
    }

    public void SelectBattleType()
    {
      // Classic means the first pokemon in the party goes first
      Console.WriteLine("Select Battle Type");
      Console.WriteLine("1. Classic: First pokemon in party goes first just like the pokemon games.");
      Console.WriteLine("2. Modern: Select which pokemon you'd like to go first.");
      Console.Write(">");
      int option = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine();
      if (option == 2)
      {
        classic = true;
      }
    }
    public void HandleTurn()
    {
      SendOutFirstPokemon(out Pokemon playerCurrentPokemon);
      Pokemon enemyCurrentPokemon = GetFirstPokemon(enemyTeam);
      bool battleOver = false;
      do
      {
        DisplayTurn(turn);
        DisplayPokemon(playerCurrentPokemon);
        DisplayPokemon(enemyCurrentPokemon);
        HandlePlayerChoice(playerTeam, playerCurrentPokemon, enemyCurrentPokemon);
        EnemySelectMove(enemyCurrentPokemon);
        bool playerCurrentFainted = IsFainted(playerTeam, playerCurrentPokemon);
        bool enemyCurrentFainted = IsFainted(enemyTeam, enemyCurrentPokemon);
        if (playerCurrentFainted && playerTeam.Count != 0)
        {
          DisplayPokemonFainted(playerCurrentPokemon);
          Pokemon nextPokemon = SelectPokemonToSwitchOut(playerTeam);
          SwitchOut(playerTeam, nextPokemon);
        }
        else if (enemyCurrentFainted && enemyTeam.Count != 0)
        {
          DisplayPokemonFainted(enemyCurrentPokemon);
          SwitchOut(enemyTeam, enemyTeam[1]);
        }
        bool playerTeamFainted = GetTeamFainted(playerTeam);
        bool enemyTeamFainted = GetTeamFainted(enemyTeam);
        battleOver = playerTeamFainted || enemyTeamFainted || forfeit;
        turn++;
      } while (!battleOver);
      StopBattle();
    }

    public static void DisplayPokemonFainted(Pokemon pokemon)
    {
      string name = pokemon.GetGeneration().GetDescription().GetName();
      Console.WriteLine($"{name} has fainted.");
    }

    public static Pokemon GetFirstPokemon(List<Pokemon> team)
    {
      Pokemon firstPokemon = team[0];
      return firstPokemon;
    }

    public void SendOutFirstPokemon(out Pokemon playerCurrentPokemon)
    {
      SelectBattleType();
      if (classic)
      {
        playerCurrentPokemon = SelectFirstPokemon(playerTeam);
      }
      else
      {
        playerCurrentPokemon = GetFirstPokemon(playerTeam);
      }
    }

    public static Pokemon SelectFirstPokemon(List<Pokemon> team)
    {
      int option;
      Console.WriteLine("Select the pokemon you would like to send into battle first.");
      for(int i = 0; i < team.Count; i++)
      {
        Console.WriteLine($"{i + 1}. {team[i].GetGeneration().GetDescription().GetName()}");
      }
      Console.Write(">");
      option = Convert.ToInt32(Console.ReadLine());
      return team[option - 1];
    }

    // Represents the choices for the battle (use moves or switch out)
    public static int SelectChoice()
    {
      Console.WriteLine("1. Moves");
      Console.WriteLine("2. Switch Out");
      Console.Write(">");
      int option = Convert.ToInt32(Console.ReadLine());
      return option;
    }

    public static void HandlePlayerChoice(List<Pokemon> team, Pokemon player, Pokemon enemy)
    {
      int choice = -1;

      while (choice != 1 && choice != 2)
      {
        choice = SelectChoice();

        if (choice == 1)
        {
          int moveIndex = SelectMove(player);
          UseMove(player, enemy, moveIndex);
          player.GetMoves()[moveIndex].DecreasePowerPoints();
        }
        else if (choice == 2)
        {
          Pokemon nextPokemon = SelectPokemonToSwitchOut(team);
          SwitchOut(team, nextPokemon);
          Console.WriteLine();
        }
        else
        {
          Console.WriteLine("Error: Invalid choice selected. Please select 1 for Moves, 2 for Switch Out and 3 to cancel.");
        }
        int enemyMoveIndex = EnemySelectMove(enemy);
        UseMove(enemy, player, enemyMoveIndex);
        enemy.GetMoves()[enemyMoveIndex].DecreasePowerPoints();
        Console.WriteLine();
        //change to switch case later
      }
    }

    // Shows the current move list for the pokemon
    public static int SelectMove(Pokemon pokemon)
    {
      List<Move> moves = pokemon.GetMoves();
      int option = -1;
      do
      {
        for (int i = 0; i < moves.Count; i++)
        {
          string name = moves[i].GetMoveInfo().GetName();
          int basePower = moves[i].GetMoveInfo().GetBasePower();
          int powerPoint = moves[i].GetCurrentPowerPoints();
          double accuracy = moves[i].GetAccuracy();

          Console.WriteLine($"{i + 1}. {name}");
          Console.WriteLine($"Base Power: {basePower} Accuracy: {accuracy * 100}% Power Points: {powerPoint}");
        }
        Console.WriteLine($"{moves.Count + 1}. Cancel");
        Console.Write(">");
        option = Convert.ToInt32(Console.ReadLine());

        if(!(option > 0 && option <= moves.Count) || moves[option - 1].GetCurrentPowerPoints() == 0)
        {
          Console.WriteLine("Invalid option selected, please try again.");
        }
        Console.WriteLine();
      } while (!(option > 0 && option <= moves.Count) || option == moves.Count + 1);
      return option - 1;
    }

    public static int EnemySelectMove(Pokemon pokemon)
    {
      Random rand = new Random();
      int max = pokemon.GetMoves().Count;
      int option = rand.Next(1, max);
      return option - 1;
    }

    public static void UseMove(Pokemon self, Pokemon target, int option)
    {
      self.GetMoves()[option].PerformUseMove(self, target);
    }

    public static Pokemon SelectPokemonToSwitchOut(List<Pokemon> team)
    {
      int option = -1;
      Console.WriteLine("Please select a pokemon to switch out to.");
      while (option < 1 || option > team.Count)
      {
        for (int i = 1; i < team.Count; i++)
        {
          string currentPokemonName = team[i].GetGeneration().GetDescription().GetName();
          int currentPokemonHP = team[i].GetStat().GetCurrentHealth();
          int currentPokemonMaxHP = team[i].GetStat().GetHealth();
          string currentPokemonStatus = team[i].GetStatus().GetStatus();
          Console.WriteLine($"{i}. {currentPokemonName} | HP: {currentPokemonHP}/{currentPokemonMaxHP} | STATUS: {currentPokemonStatus}");
        }
        Console.WriteLine($"{team.Count}. Cancel");
        Console.Write(">");
        option = Convert.ToInt32(Console.ReadLine());
        if((option < 1 || option > team.Count) || option == team.Count + 1)
        {
          Console.WriteLine("Invalid option: Please select a valid pokemon.");
        }
        else
        {
          return team[option - 1];
        }
      }
    }

    public static void SwitchOut(List<Pokemon> team, Pokemon nextPokemon)
    {
      Pokemon tempCurrentPokemon = team[0];
      int nextPokemonIndex = team.IndexOf(nextPokemon);
      team[0] = nextPokemon;
      team[nextPokemonIndex] = tempCurrentPokemon;
    }

    static bool IsFainted(List<Pokemon> team, Pokemon pokemon)
    {
      if (pokemon.GetStat().GetCurrentHealth() <= 0)
      {
        // find the pokemon in the team and remove them
        int pokemonIndex = team.IndexOf(pokemon);
        team.Remove(team[pokemonIndex]);
        return true;
      }
      else
      {
        return false;
      }
    }

    public static void EnemyMove(Pokemon pokemon)
    {
      // Reference: https://essentialsdocs.fandom.com/wiki/Battle_AI
    }

    public static bool GetTeamFainted(List<Pokemon> team)
    {
      return team.Count == 0;
    }
    public static void DisplayTurn(int turn)
    {
      Console.WriteLine($"Turn {turn}");
      Console.WriteLine("=============");
    }

    public static void DisplayPokemon(Pokemon pokemon)
    {
      string name = pokemon.GetGeneration().GetDescription().GetName();
      int level = pokemon.GetGeneration().GetDescription().GetLevel();
      char gender = pokemon.GetGeneration().GetGender().GetGender()[0];
      int currentHP = pokemon.GetStat().GetCurrentHealth();
      int totalHP = pokemon.GetStat().GetHealth();

      Console.WriteLine($"{name} {gender} Lvl. {level}");
      Console.WriteLine($"HP: {currentHP} / {totalHP}");
      Console.WriteLine();
    }
    public void StopBattle()
    {
      // Check if either team has 0 pokemon alive or has forfeited
      bool playerTeamFainted = playerTeam.Count == 0;
      bool enemyTeamFainted = enemyTeam.Count == 0;
      if (forfeit || (playerTeamFainted || enemyTeamFainted))
      {
        Console.WriteLine("The battle is now over.");
        if (playerTeamFainted || forfeit)
        {
          Console.WriteLine("Enemy won!");
        }
        else
        {
          Console.WriteLine("You won!");
        }
      }
    }
  }
}