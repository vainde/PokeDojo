using System;
using PokeDojo.src.Poke;
using PokeDojo.src.Data;

namespace PokeDojo.src.Simulator.Team
{
  class Party(int generation)
  {
    public List<Pokemon> Team { get; set; } = [];
    public int Generation { get; set; } = generation;

    public static void PrintBorder()
    {
      Console.WriteLine("=========================");
    }

    public static int CreateATeam()
    {
      int option;
      do
      {
        Console.WriteLine("CREATE A TEAM");
        PrintBorder();
        Console.WriteLine("1. Add a pokemon by name");
        Console.WriteLine("2. Quit");
        option = Convert.ToInt32(Console.ReadLine());
      } while (option < 1 || option > 2);
      return option;
    }

    public static void AddPokemon()
    {
      Console.WriteLine("ADD A POKEMON BY NAME");
      PrintBorder();
      Console.WriteLine("Enter pokemon by name: ");
      //Find pokemon name if it matches the key in Pokemon[Name];
      //Return value
    }
  }
}
