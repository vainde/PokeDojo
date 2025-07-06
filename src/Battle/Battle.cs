using PokeDojo.src.Data.Moves;
using PokeDojo.src.Poke;

namespace PokeDojo.src.Battles
{
  class Battle(List<Pokemon> PlayerTeam, List<Pokemon> EnemyTeam)
  {
    public int Turn = 1;
    public readonly bool Forfeit = false;
    public bool Modern = false;
    public readonly List<Pokemon> PlayerTeam = PlayerTeam;
    public readonly List<Pokemon> EnemyTeam = EnemyTeam;

    public void SelectBattleType()
    {
      // Classic means the first pokemon in the party goes first
      Console.WriteLine("Select Battle Type");
      Console.WriteLine("1. Classic: First pokemon in party goes first just like the pokemon games.");
      Console.WriteLine("2. Modern: Select which pokemon you'd like to go first.");
      Console.Write(">");
      int.TryParse(Console.ReadLine(), out int option);
      Console.WriteLine();
      if (option == 2)
      {
        Modern = true;
      }
    }
    public void DisplayCurrentPokemon(Pokemon player, Pokemon enemy)
    {
      DisplayTurn(Turn);
      DisplayPokemon(player);
      DisplayPokemon(enemy);
    }
    public void HandleTurn()
    {
      SendOutFirstPokemon(out Pokemon playerCurrentPokemon);
      Pokemon enemyCurrentPokemon = GetFirstPokemon(EnemyTeam);
      bool battleOver;
      bool enemyTeamFainted;
      bool playerTeamFainted;
      bool playerCurrentFainted;
      bool enemyCurrentFainted;
      int choice;

      do
      {
        DisplayCurrentPokemon(playerCurrentPokemon, enemyCurrentPokemon);
        choice = HandlePlayerChoice(PlayerTeam, playerCurrentPokemon);
        HandleEnemyChoice(enemyCurrentPokemon, out int enemyMoveIndex);

        if (choice >= 0)
        {
          HandleAttack(choice, playerCurrentPokemon, enemyCurrentPokemon);
        }
        // Enemy will attack them after switching out
        else if (choice == -1)
        {
          playerCurrentPokemon = PlayerTeam[0];
          Console.WriteLine($"Player sent out {playerCurrentPokemon.Name}!");
          enemyCurrentPokemon.Moves[enemyMoveIndex].PerformUseMove(enemyCurrentPokemon, playerCurrentPokemon);
          DisplayPokemon(playerCurrentPokemon);
        }

        playerCurrentFainted = IsFainted(playerCurrentPokemon);
        enemyCurrentFainted = IsFainted(enemyCurrentPokemon);
        playerTeamFainted = GetTeamFainted(PlayerTeam);
        enemyTeamFainted = GetTeamFainted(EnemyTeam);

        if (playerCurrentFainted && !playerTeamFainted)
        {
          playerCurrentPokemon = PokemonFainted(playerCurrentPokemon, playerCurrentFainted, PlayerTeam);
        }
        else if (enemyCurrentFainted && !enemyTeamFainted)
        {
          int enemyCurrentIdx = EnemyTeam.IndexOf(enemyCurrentPokemon);
          enemyCurrentPokemon = PokemonFainted(enemyCurrentPokemon, enemyCurrentFainted, EnemyTeam, enemyCurrentIdx);
        }
        battleOver = playerTeamFainted || enemyTeamFainted || Forfeit;

        if (battleOver)
        {
          StopBattle(!playerTeamFainted);
        }
        else
        {
          Turn++;
        }
      } while (!battleOver);
    }

    public static Pokemon PokemonFainted(Pokemon pokemon, bool pokemonFainted, List<Pokemon> team, int enemyIdx = -1)
    {
      Pokemon nextPokemon;
      string whoSwitched;

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
      whoSwitched = enemyIdx == -1 ? "Player" : "Enemy";
      Console.WriteLine($"{whoSwitched} sent out {pokemon.Name}");
      Console.WriteLine();
      return nextPokemon;
    }

    public static void HandleMove(Pokemon currentPokemon, Pokemon currentTarget, int choice)
    {
      Move selectedMove = currentPokemon.Moves[choice];
      selectedMove.PerformUseMove(currentPokemon, currentTarget);
      selectedMove.CurrentPowerPoint -= 1;
      DisplayPokemon(currentTarget);
    }

    /*i can put handlemove on a queue based on speed
      if player is faster then queue player action first, then enemy second
      else enemy first then player second
     dequeue first and invoke, second and invoke gg ez*/

    public static void HandleAttack(int choice, Pokemon playerCurrentPokemon, Pokemon enemyCurrentPokemon)
    {
      int playerCurrentSpeed = playerCurrentPokemon.Stat.Speed;
      int enemyCurrentSpeed = enemyCurrentPokemon.Stat.Speed;

      Queue<Action> MoveQueue = new();
      if (playerCurrentSpeed > enemyCurrentSpeed)
      {
        if (CheckPokemonAlive(playerCurrentPokemon))
        {
          MoveQueue.Enqueue(() => HandleMove(playerCurrentPokemon, enemyCurrentPokemon, choice));
          MoveQueue.Dequeue().Invoke();
        }
        if (CheckPokemonAlive(enemyCurrentPokemon))
        {
          MoveQueue.Enqueue(() => HandleMove(enemyCurrentPokemon, playerCurrentPokemon, choice));
          MoveQueue.Dequeue().Invoke();
        }
      }
      else if (playerCurrentSpeed < enemyCurrentSpeed)
      {
        if (CheckPokemonAlive(enemyCurrentPokemon))
        {
          MoveQueue.Enqueue(() => HandleMove(enemyCurrentPokemon, playerCurrentPokemon, choice));
          MoveQueue.Dequeue().Invoke();
        }
        if (CheckPokemonAlive(playerCurrentPokemon))
        {
          MoveQueue.Enqueue(() => HandleMove(playerCurrentPokemon, enemyCurrentPokemon, choice));
          MoveQueue.Dequeue().Invoke();
        }
      }
      else
      {
        Random rand = new();
        if (rand.Next(0, 1) <= 0.5)
        {
          if (CheckPokemonAlive(playerCurrentPokemon))
          {
            MoveQueue.Enqueue(() => HandleMove(playerCurrentPokemon, enemyCurrentPokemon, choice));
            MoveQueue.Dequeue().Invoke();
          }
          if (CheckPokemonAlive(enemyCurrentPokemon))
          {
            MoveQueue.Enqueue(() => HandleMove(enemyCurrentPokemon, playerCurrentPokemon, choice));
            MoveQueue.Dequeue().Invoke();
          }
        }
        else
        {
          if (CheckPokemonAlive(enemyCurrentPokemon))
          {
            MoveQueue.Enqueue(() => HandleMove(enemyCurrentPokemon, playerCurrentPokemon, choice));
            MoveQueue.Dequeue().Invoke();
          }
          if (CheckPokemonAlive(playerCurrentPokemon))
          {
            MoveQueue.Enqueue(() => HandleMove(playerCurrentPokemon, enemyCurrentPokemon, choice));
            MoveQueue.Dequeue().Invoke();
          }
        }
      }
    }

    public static bool CheckPokemonAlive(Pokemon pokemon)
    {
      return pokemon.Stat.CurrentHealth > 0;
    }
    public static void DisplayPokemonFainted(Pokemon pokemon)
    {
      string name = pokemon.Name;
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
      if (Modern)
      {
        playerCurrentPokemon = SelectFirstPokemon(PlayerTeam);
      }
      else
      {
        playerCurrentPokemon = GetFirstPokemon(PlayerTeam);
      }
    }

    public static Pokemon SelectFirstPokemon(List<Pokemon> team)
    {
      int option;
      Console.WriteLine("Select the pokemon you would like to send into battle first.");
      for (int i = 0; i < team.Count; i++)
      {
        Console.WriteLine($"{i + 1}. {team[i].Name}");
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

    public static int HandlePlayerChoice(List<Pokemon> team, Pokemon player)
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
      List<Move> moves = pokemon.Moves;
      int option;
      do
      {
        for (int i = 0; i < moves.Count; i++)
        {
          string name = moves[i].GetMoveInfo().Name;
          int basePower = moves[i].GetMoveInfo().BasePower;
          int powerPoint = moves[i].CurrentPowerPoint;
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
          if (moves[option - 1].CurrentPowerPoint == 0)
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
      Random rand = new();
      int max = pokemon.Moves.Count;
      int option = rand.Next(1, max);
      return option - 1;
    }

    public static void HandleEnemyChoice(Pokemon enemy, out int enemyMoveIndex)
    {
      enemyMoveIndex = EnemySelectMove(enemy);
    }

    public static void UseMove(Pokemon self, Pokemon target, int option)
    {
      self.Moves[option].PerformUseMove(self, target);
    }

    public static Pokemon SelectPokemonToSwitchOut(List<Pokemon> team, bool afterFainted)
    {
      int option = -1;
      Console.WriteLine("Please select a pokemon to switch out to.");
      while (!afterFainted && (option < 1 || option > team.Count) || (afterFainted && option < 1 || option >= team.Count))
      {
        for (int i = 1; i < team.Count; i++)
        {
          string currentPokemonName = team[i].Name;
          int currentPokemonHP = team[i].Stat.CurrentHealth;
          int currentPokemonMaxHP = team[i].Stat.Health;
          string currentPokemonStatus = team[i].Status.Name;
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
      if (pokemon.Stat.CurrentHealth <= 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public static bool GetTeamFainted(List<Pokemon> team)
    {
      int healthSum = 0;
      foreach (Pokemon pokemon in team)
      {
        healthSum += pokemon.Stat.CurrentHealth;
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
    public static void DisplayTurn(int Turn)
    {
      Console.WriteLine($"Turn {Turn}");
      Console.WriteLine("=============");
    }

    public static void DisplayPokemon(Pokemon pokemon)
    {
      string name = pokemon.Name;
      int level = pokemon.Level;
      int currentHP = pokemon.Stat.CurrentHealth;
      int totalHP = pokemon.Stat.Health;

      if (currentHP <= 0)
        currentHP = 0;

      Console.WriteLine($"{name} Lvl. {level}");
      Console.WriteLine($"HP: {currentHP} / {totalHP}");
      CheckStatus(pokemon);
      Console.Write('\n');
    }

    public static void CheckStatus(Pokemon pokemon)
    {
      string status = pokemon.Status.Name;
      if(status != "OK")
      {
        Console.WriteLine($"STATUS: {status}");
      }
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
        if (team[i].Stat.CurrentHealth <= 0)
        {
          return true;
        }
      }
      return false;
    }
  }
}