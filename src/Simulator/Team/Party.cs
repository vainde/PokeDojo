using System;
using PokeDojo.src.Poke;
using PokeDojo.src.Data;
using PokeDojo.src.Data.Moves;
using System.Text.Json;
using PokeDojo.src.Data.Type;

namespace PokeDojo.src.Simulator.Team
{
  class Party
  {
    public string Name { get; set; }
    public List<Pokemon> Team { get; set; } = [];

    public Party(string name) {
      Name = name;
    }
    public static void PrintBorder()
    {
      Console.WriteLine("=========================");
    }

    public void UpdateTeam()
    {
      int option;
      do
      {
        Console.WriteLine("UPDATE PARTY");
        PrintBorder();
        Console.WriteLine("1. Add a pokemon to the party");
        Console.WriteLine("2. Remove a pokemon from the party");
        Console.WriteLine("3. See the available pokemon you can add to the party");
        Console.WriteLine("4. Quit");
        option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
          case 1:
            AddPokemon();
            break;
          case 2:
            RemovePokemon();
            break;
          case 3:
            AvailablePokemon();
            break;
          case 4:
            Console.WriteLine("Quitting Update Party...");
            break;
        }
      } while (option >= 1 && option <= 3);

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

    public void AddPokemon()
    {
      if (Team.Count == 6)
      {
        Console.WriteLine("Your party is full so you can not add any more pokemon.");
      }
      else
      {
        Dictionary<string, Pokemon> Pokemons = Initialize.Pokemons();
        Console.WriteLine("ADD A POKEMON TO PARTY BY NAME");
        PrintBorder();
        Console.Write("Enter pokemon by name: ");
        string? name = Console.ReadLine();
        if (name != null && Pokemons.TryGetValue(name, out Pokemon? value))
        {
          Team.Add(value);
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
      Console.Write("Enter pokemon by name: ");
      string? name = Console.ReadLine();
      Pokemon? removedPokemon = null;
      foreach (Pokemon pokemon in Team)
      {
        if (pokemon.Name == name)
        {
          removedPokemon = pokemon;
        }
      }
      if (removedPokemon != null)
      {
        Team.Remove(removedPokemon);
        Console.WriteLine($"{removedPokemon.Name} has been removed from the party.");
      }
    }

    public void DisplayParty()
    {
      foreach (Pokemon pokemon in Team)
      {
        Console.WriteLine(pokemon.Name);
        Console.WriteLine($"Lvl: {pokemon.Level}");
        Console.Write($"Type: ");
        foreach (PokemonType type in pokemon.Type)
        {
          Console.Write(type.Name);
          if (pokemon.Type.Count == 2)
          {
            Console.Write(" ");
          }
        }
        Console.WriteLine();
        Console.WriteLine($"HP: {pokemon.Stat.CurrentHealth} / {pokemon.Stat.Health}");
      }
    }

    public void SaveParty()
    {
      //load json file, edit 'Party' with current team
      string jsonTeam = JsonSerializer.Serialize(Team);
      Console.WriteLine(jsonTeam);
    }
  }
}
