using System;
using PokeDojo.src.Poke;

namespace PokeDojo.src.Simulator.Team
{
  class Party
  {
    List<Pokemon> party;
    int generation;
    string filter;

    public Party()
    {
      party = new List<Pokemon>();
      generation = 1;
      filter = "Default";
    }

    void Menu()
    {
      Console.WriteLine("1. Add a pokemon by name");
      Console.WriteLine("2. Search for a pokemon.");
    }

    void AddPokemon()
    {
      Console.WriteLine();
    }

    void SelectPokemon()
    {

    }

    void SearchForPokemon()
    {
      Console.WriteLine("SEARCH FOR A POKEMON");
      Console.WriteLine("=====================");
      Console.WriteLine("1. Filter by type");
      Console.WriteLine("2. Filter by moves they can learn");
      Console.WriteLine("3. Filter by base stat");
    }

    // Individual functions for filtering by type, moves and base stat. Then return the specific type, move or base stat.

    void DisplayPokemon(List <Pokemon> allPokemon)
    {
      switch (filter)
      {
        case "type":
          break;
        case "moves":
          break;
        case "base stat":
          break;
        default:
          break;
      }
    }
  }
}
