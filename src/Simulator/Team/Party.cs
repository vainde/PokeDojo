using System;
using PokeDojo.src.Poke;

namespace PokeDojo.src.Simulator.Team
{
  class Party
  {
    readonly List<Pokemon> party;
    int generation;

    public Party(int generation)
    {
      party = new List<Pokemon>();
      this.generation = generation;
    }
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

    public void AddPokemon()
    {
      Console.WriteLine("ADD A POKEMON");
      PrintBorder();
      Console.WriteLine("Enter pokemon by name: ");
      // Looks in initialize.Pokedex
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

    // Individual functions for filtering by type, moves and base stat. Then return the specific type, move or base stat.

    public static void DisplayPokemon(List <Pokemon> allPokemon)
    {
      int filter = SearchForPokemon();
      switch (filter)
      {
        case 1:
          // get the type
          break;
        case 2:
          // get the move
          break;
        case 3:
          // get the base stat
          break;
        default:
          break;
      }
    }
  }
}
