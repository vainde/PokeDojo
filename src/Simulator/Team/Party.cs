using System;
using PokeDojo.src.Poke;
using PokeDojo.src.Data;
using PokeDojo.src.Data.Moves;

namespace PokeDojo.src.Simulator.Team
{
  class Party
  {
    public List<Pokemon> Team { get; set; } = [];

    public static void PrintBorder()
    {
      Console.WriteLine("=========================");
    }

    public int CreateATeam()
    {
      int option;
      do
      {
        Console.WriteLine("PARTY MENU");
        PrintBorder();
        Console.WriteLine("1. Add a pokemon to the party");
        Console.WriteLine("2. Remove a pokemon from the party");
        Console.WriteLine("3. See available pokemon");
        Console.WriteLine("4. Quit");
        option = Convert.ToInt32(Console.ReadLine());
      } while (option < 1 || option > 4);
      return option;
    }

    public void AvailablePokemon()
    {
      Console.WriteLine("AVAILABLE POKEMON");
      PrintBorder();
      Dictionary<string, Pokemon> Pokemons = Initialize.Pokemons();
      foreach (KeyValuePair<string, Pokemon> entry in Pokemons)
      {
        Pokemon pokemon = entry.Value;
        Console.WriteLine($"{pokemon.Name}");
      }
      PrintBorder();
    }

    public void AddPokemon(List<Pokemon> team)
    {
      if (team.Count == 6)
      {
        Console.WriteLine("Your party is full so you can not add any more pokemon.");
      }
      else
      {
        Dictionary<string, Pokemon> Pokemons = Initialize.Pokemons();
        Console.WriteLine("ADD A POKEMON TO PARTY BY NAME");
        PrintBorder();
        Console.WriteLine("Enter pokemon by name: ");
        string? name = Console.ReadLine();
        if (name != null && Pokemons.TryGetValue(name, out Pokemon? value))
        {
          team.Add(value);
          Console.WriteLine($"{value.Name} has been added to the party.");
        }
        else
        {
          Console.WriteLine("Invalid pokemon name entered.");
        }
      }
    }

    public void RemovePokemon()
    {
      Console.WriteLine("REMOVE POKEMON FROM PARTY BY NAME");
      PrintBorder();
      Console.WriteLine("Enter pokemon by name: ");
      string? name = Console.ReadLine();
      foreach(Pokemon pokemon in Team)
      {
        if (pokemon.Name == name)
        {
          Team.Remove(pokemon);
          Console.WriteLine($"{pokemon.Name} has been removed from the party.");
        }      
      }
    }
  }
}
