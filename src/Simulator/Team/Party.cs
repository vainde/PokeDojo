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
        Console.WriteLine("2. Search for a pokemon.");
        Console.WriteLine("3. Quit");
        option = Convert.ToInt32(Console.ReadLine());
      } while (option < 1 || option > 3);
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

    public static int SearchForPokemon()
    {
      int filter = -1;
      bool invalidFilter = filter < 1 || filter > 3;
      while(invalidFilter)
      {
        Console.WriteLine("POKEMON SEARCH");
        Console.WriteLine("=====================");
        Console.WriteLine("1. Filter by type");
        Console.WriteLine("2. Filter by moves they can learn");
        Console.WriteLine("3. Filter by base stat (descending)");
        Console.Write(">");
        filter = Convert.ToInt32(Console.ReadLine());
        if(invalidFilter)
        {
          Console.WriteLine("Error: Invalid filter. Please select 1, 2 or 3.");
        }
      }
      return filter;
    }
  }
}
