using PokeDojo.src.Poke;
using PokeDojo.src.Data.Moves;
using System;

namespace PokeDojo.src.Simulator.Summary
{
  static class Fight
  {
    static public void SimulateFight(Pokemon self, Pokemon target)
    {
      ShowTurn(self, target);
      DisplayWinner(self, target);
    }

    static public void ShowTurn(Pokemon you, Pokemon enemy)
    {
      int selfHP = you.GetStat().GetHealth();
      string selfName = you.GetGeneration().GetDescription().GetName();
      int selfLevel = you.GetGeneration().GetDescription().GetLevel();
      char selfGender = you.GetGeneration().GetGender().GetGender()[0];

      int targetHP = enemy.GetStat().GetHealth();
      string targetName = enemy.GetGeneration().GetDescription().GetName();
      int targetLevel = enemy.GetGeneration().GetDescription().GetLevel();
      char targetGender = enemy.GetGeneration().GetGender().GetGender()[0];
      int currentTurn = 1;

      while (you.GetStat().GetCurrentHealth() >= 0 && enemy.GetStat().GetCurrentHealth() >= 0)
      {
        Console.WriteLine($"TURN {currentTurn}");
        Console.WriteLine("========");
        Console.WriteLine($"{targetName} {targetGender} Lvl. {targetLevel}");
        Console.WriteLine($"HP: {enemy.GetStat().GetCurrentHealth()} / {targetHP}");
        Console.WriteLine();
        Console.WriteLine($"{selfName} {selfGender} Lvl. {selfLevel}");
        Console.WriteLine($"HP {you.GetStat().GetCurrentHealth()} / {selfHP}");
        Console.WriteLine();
        Console.WriteLine("MOVES");
        int j = 1;
        foreach (Move move in you.GetMoves())
        {
          Console.WriteLine($"Move {j}: {move.GetMoveInfo().GetName()}");
          j++;
        }
        Console.Write(">");
        int option = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        // check who's faster later
        if (option == 1)
        {
          Move choice = you.GetMoves()[option - 1];
          choice.PerformUseMove(you, enemy);
        }
        else
        {
          Console.WriteLine("Invalid move selected.");
        }

        // ENEMY'S TURN
        // Testing the enemy spamming the same move
        Move enemyChoice = enemy.GetMoves()[0];
        enemyChoice.PerformUseMove(enemy, you);
        Console.WriteLine();
        currentTurn++;
      }
    }
    static public void DisplayWinner(Pokemon you, Pokemon enemy)
    {
      string selfName = you.GetGeneration().GetDescription().GetName();
      string targetName = enemy.GetGeneration().GetDescription().GetName();

      if (you.GetStat().GetCurrentHealth() <= 0)
      {
        Console.WriteLine($"{selfName} fainted.");
        Console.WriteLine($"{targetName} wins!");
      }
      else if (enemy.GetStat().GetCurrentHealth() <= 0)
      {
        Console.WriteLine($"{targetName} fainted.");
        Console.WriteLine($"{selfName} wins!");
      }
    }
  }
}
