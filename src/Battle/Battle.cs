using System;
using System.Numerics;
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
    bool modern;
    readonly List<Pokemon> playerTeam;
    readonly List<Pokemon> enemyTeam;

    public Battle(List<Pokemon> playerTeam, List<Pokemon> enemyTeam)
    {
      turn = 1;
      forfeit = false;
      modern = false;
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
        modern = true;
      }
    }
    public void DisplayCurrentPokemon(Pokemon player, Pokemon enemy)
    {
      DisplayTurn(turn);
      DisplayPokemon(player);
      DisplayPokemon(enemy);
    }
    public void HandleTurn()
    {
      SendOutFirstPokemon(out Pokemon playerCurrentPokemon);
      Pokemon enemyCurrentPokemon = GetFirstPokemon(enemyTeam);
      bool battleOver;
      bool enemyTeamFainted;
      do
      {
        DisplayCurrentPokemon(playerCurrentPokemon, enemyCurrentPokemon);
        int choice = HandlePlayerChoice(playerTeam, playerCurrentPokemon, enemyCurrentPokemon);
        HandleEnemyChoice(enemyCurrentPokemon, out int enemyMoveIndex);

        if (choice >= 0)
        {
          HandleAttack(choice, playerCurrentPokemon, enemyCurrentPokemon, enemyMoveIndex);
        }
        // Enemy will attack them after switching out
        else if (choice == -1)
        {
          playerCurrentPokemon = playerTeam[0];
          Console.WriteLine($"Player sent out {playerCurrentPokemon.GetGeneration().GetDescription().GetName()}!");
          enemyCurrentPokemon.GetMoves()[enemyMoveIndex].PerformUseMove(enemyCurrentPokemon, playerCurrentPokemon);
          DisplayPokemon(playerCurrentPokemon);
        }

        bool playerCurrentFainted = IsFainted(playerCurrentPokemon);
        bool enemyCurrentFainted = IsFainted(enemyCurrentPokemon);
        bool playerTeamFainted = GetTeamFainted(playerTeam);
        enemyTeamFainted = GetTeamFainted(enemyTeam);

        if (playerCurrentFainted && !playerTeamFainted)
        {
          playerCurrentPokemon = PokemonFainted(playerCurrentPokemon, playerCurrentFainted, playerTeam);
        }
        else if (enemyCurrentFainted && !enemyTeamFainted)
        {
          int enemyCurrentIdx = enemyTeam.IndexOf(enemyCurrentPokemon);
          enemyCurrentPokemon = PokemonFainted(enemyCurrentPokemon, enemyCurrentFainted, enemyTeam, enemyCurrentIdx);
        }
        battleOver = playerTeamFainted || enemyTeamFainted || forfeit;
        turn++;
      } while (!battleOver);
    }

    public static Pokemon PokemonFainted(Pokemon pokemon, bool pokemonFainted, List<Pokemon> team, int enemyIdx = -1)
    {
      Pokemon nextPokemon;
      DisplayPokemonFainted(pokemon);
      if (enemyIdx == -1)
      {
        nextPokemon = SelectPokemonToSwitchOut(team, pokemonFainted);
      }
      else
      {
        nextPokemon = team[enemyIdx + 1];
      }
      SwitchOut(team, nextPokemon);
      pokemon = nextPokemon;
      string whoSwitched = enemyIdx == -1 ? "Player" : "Enemy";
      Console.WriteLine($"{whoSwitched} sent out {pokemon.GetGeneration().GetDescription().GetName()}");
      Console.WriteLine();
      return nextPokemon;
    }

    public static void HandleMove(Pokemon currentPokemon, Pokemon currentTarget, int choice)
    {
      Move selectedMove = currentPokemon.GetMoves()[choice];
      selectedMove.PerformUseMove(currentPokemon, currentTarget);
      currentPokemon.DecreasePowerPoint(selectedMove);
      DisplayPokemon(currentTarget);
    }

    public static void HandleAttack(int choice, Pokemon playerCurrentPokemon, Pokemon enemyCurrentPokemon, int enemyMoveIndex)
    {
      int playerCurrentSpeed = playerCurrentPokemon.GetStat().GetSpeed();
      int enemyCurrentSpeed = enemyCurrentPokemon.GetStat().GetSpeed();
      if (playerCurrentSpeed > enemyCurrentSpeed)
      {
        int playerCurrentHP = playerCurrentPokemon.GetStat().GetCurrentHealth();
        if (playerCurrentHP >= 0)
        {
          HandleMove(playerCurrentPokemon, enemyCurrentPokemon, choice);
        }
        int enemyCurrentHP = enemyCurrentPokemon.GetStat().GetCurrentHealth();
        if (enemyCurrentHP >= 0)
        {
          HandleMove(enemyCurrentPokemon, playerCurrentPokemon, choice);
        }
      }
      else if (playerCurrentSpeed < enemyCurrentSpeed)
      {
        // Make sure that they dont attack if they are dead
        int enemyCurrentHP = enemyCurrentPokemon.GetStat().GetCurrentHealth();
        if (enemyCurrentHP >= 0)
        {
          HandleMove(enemyCurrentPokemon, playerCurrentPokemon, choice);
        }
        int playerCurrentHP = playerCurrentPokemon.GetStat().GetCurrentHealth();
        if (playerCurrentHP >= 0)
        {
          HandleMove(playerCurrentPokemon, enemyCurrentPokemon, choice);
        }
      }
      else
      {
        Random rand = new Random();
        if(rand.Next(0, 1) <= 0.5)
        {
          HandleMove(playerCurrentPokemon, enemyCurrentPokemon, choice);
        }
        else
        {
          HandleMove(enemyCurrentPokemon, playerCurrentPokemon, choice);
        }
      }
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
      if (modern)
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
      for (int i = 0; i < team.Count; i++)
      {
        Console.WriteLine($"{i + 1}. {team[i].GetGeneration().GetDescription().GetName()}");
      }
      Console.Write(">");
      option = Convert.ToInt32(Console.ReadLine());
      SwitchOut(team, team[option - 1]);
      return team[0];
    }

    // Represents the choices for the battle (use moves or switch out)
    public static int SelectChoice(List<Pokemon> team)
    {
      bool oneLastMember = OneLastMember(team);
      int option = -1;
      while (option < 1 || option > 2 || (oneLastMember && option == 2))
      {
        Console.WriteLine("1. Moves");
        if (!oneLastMember || team.Count != 1)
        {
          Console.WriteLine("2. Switch Out");
        }
        Console.Write(">");
        option = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        if (oneLastMember && option == 2)
        {
          Console.WriteLine("Error: Invalid option selected.");
        }
      }
      return option;
    }

    public static int HandlePlayerChoice(List<Pokemon> team, Pokemon player, Pokemon enemy)
    {
      int playerMoveIndex = -1;
      Pokemon nextPokemon = team[0];

      do
      {
        int choice = 0;

        while (choice < 1 || choice > 2)
        {
          // Picks either move or switch out
          choice = SelectChoice(team);
        }
        // If the player selects move they should be able to cancel it
        if (choice == 1)
        {
          // By default it's the value the player picks to cancel
          playerMoveIndex = SelectMove(player);
          if (playerMoveIndex != -1)
          {
            return playerMoveIndex;
          }
        }
        else if (choice == 2 && team.Count > 1)
        {
          nextPokemon = SelectPokemonToSwitchOut(team, false);
          if (nextPokemon != team[0])
          {
            SwitchOut(team, nextPokemon);
            return -1;
          }
        }
        else
        {
          Console.WriteLine("Error: Invalid choice selected");
        }
        //change to switch case later
      } while (playerMoveIndex != 1 || nextPokemon != team[0]);
      return -2;
    }

    // Shows the current move list for the pokemon
    public static int SelectMove(Pokemon pokemon)
    {
      List<Move> moves = pokemon.GetMoves();
      int option;
      do
      {
        for (int i = 0; i < moves.Count; i++)
        {
          string name = moves[i].GetMoveInfo().GetName();
          int basePower = moves[i].GetMoveInfo().GetBasePower();
          int powerPoint = pokemon.GetPowerPoints()[i];
          double accuracy = moves[i].GetAccuracy();

          Console.WriteLine($"{i + 1}. {name}");
          Console.WriteLine($"Base Power: {basePower} Accuracy: {accuracy * 100}% Power Points: {powerPoint}");
        }
        Console.WriteLine($"{moves.Count + 1}. Cancel");
        Console.Write(">");
        option = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        if (option < 0 || option > moves.Count + 1)
        {
          Console.WriteLine("Invalid option selected, please try again.");
          if (pokemon.GetPowerPoints()[option - 1] == 0)
          {
            Console.WriteLine($"{moves[option - 1]} has 0 PP left.");
          }
        }
      } while (option < 0 || option > moves.Count + 1);

      if (option == moves.Count + 1)
      {
        return -1;
      }
      else
      {
        return option - 1;
      }
    }

    public static int EnemySelectMove(Pokemon pokemon)
    {
      Random rand = new Random();
      int max = pokemon.GetMoves().Count;
      int option = rand.Next(1, max);
      return option - 1;
    }

    public static void HandleEnemyChoice(Pokemon enemy, out int enemyMoveIndex)
    {
      enemyMoveIndex = EnemySelectMove(enemy);
    }

    public static void UseMove(Pokemon self, Pokemon target, int option)
    {
      self.GetMoves()[option].PerformUseMove(self, target);
    }

    public static Pokemon SelectPokemonToSwitchOut(List<Pokemon> team, bool afterFainted)
    {
      int option = -1;
      Console.WriteLine("Please select a pokemon to switch out to.");
      while (!afterFainted && (option < 1 || option > team.Count) || (afterFainted && option < 1 || option >= team.Count))
      {
        for (int i = 1; i < team.Count; i++)
        {
          string currentPokemonName = team[i].GetGeneration().GetDescription().GetName();
          int currentPokemonHP = team[i].GetStat().GetCurrentHealth();
          int currentPokemonMaxHP = team[i].GetStat().GetHealth();
          string currentPokemonStatus = team[i].GetStatus().GetStatus();
          Console.WriteLine($"{i}. {currentPokemonName} | HP: {currentPokemonHP}/{currentPokemonMaxHP} | STATUS: {currentPokemonStatus}");
          if (!afterFainted)
          {
            Console.WriteLine($"{team.Count}. Cancel");
          }
          Console.Write(">");
          option = Convert.ToInt32(Console.ReadLine());
          Console.WriteLine();
          if ((!afterFainted && (option < 1 || option > team.Count) || (afterFainted && option < 1 || option > team.Count)))
          {
            Console.WriteLine("Invalid option: Please select a valid pokemon.");
          }
          else if(option == team.Count)
          {
            return team[0];
          }
        }
      }
      return team[option];
    }

    public static void SwitchOut(List<Pokemon> team, Pokemon nextPokemon)
    {
      Pokemon tempCurrentPokemon = team[0];
      int nextPokemonIndex = team.IndexOf(nextPokemon);
      team[0] = nextPokemon;
      team[nextPokemonIndex] = tempCurrentPokemon;
    }

    static bool IsFainted(Pokemon pokemon)
    {
      if (pokemon.GetStat().GetCurrentHealth() <= 0)
      {
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
      int healthSum = 0;
      foreach (Pokemon pokemon in team)
      {
        healthSum += pokemon.GetStat().GetCurrentHealth();
      }

      // Have to find a way to make current health be at an minimum of 0
      if (healthSum <= 0)
      {
        return true;
      }
      else
      {
        return false;
      }
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

      if (currentHP <= 0)
        currentHP = 0;

      Console.WriteLine($"{name} {gender} Lvl. {level}");
      Console.WriteLine($"HP: {currentHP} / {totalHP}");
      Console.WriteLine();
    }
    public static void StopBattle(bool playerWon)
    {
      Console.WriteLine("The battle is now over.");
      if (playerWon)
      {
        Console.WriteLine("You are victorious!");
      }
      else
      {
        Console.WriteLine("The enemy is victorious...");
      }
    }

    public static bool OneLastMember(List<Pokemon> team)
    {
      for (int i = 0; i < team.Count; i++)
      {
        if (team[i].GetStat().GetCurrentHealth() <= 0)
        {
          return true;
        }
      }
      return false;
    }
  }
}