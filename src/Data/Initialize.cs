using PokeDojo.src.Poke;
using PokeDojo.src.Data.Stats;
using PokeDojo.src.Data.Type;
using PokeDojo.src.Data.Moves;
using PokeDojo.src.Data.Statuses;

namespace PokeDojo.src.Data
{
  public static class Initialize
  {
    public static Dictionary<string, MoveType> OffenseTypes()
    {
      return new Dictionary<string, MoveType>
      {
        {"Fighting",
          new(
            "Fighting",
            ["Normal", "Ice", "Rock", "Dark", "Steel"],
            ["Fire", "Water", "Grass", "Electric", "Fighting", "Ground", "Dragon"],
            ["Poison", "Flying", "Psychic", "Bug", "Fairy"], ["Ghost"]
          )
        },
        {
        "Flying",
          new(
          "Flying",
          ["Grass", "Fighting", "Bug"],
          ["Normal", "Fire", "Water", "Ice", "Poison", "Ground", "Flying", "Psychic", "Ghost", "Dragon", "Dark"],
          ["Electric", "Rock", "Steel"],
          []
          )
        },
        {
          "Poison",
          new(
            "Poison",
            ["Grass", "Fairy"],
            ["Normal", "Fire", "Water", "Electric", "Ice", "Fighting", "Flying", "Psychic", "Bug", "Dragon", "Dark"],
            ["Poison", "Ground", "Rock", "Ghost"], ["Steel"]
            )
        },
        {
          "Ground",
          new(
            "Ground",
            ["Fire", "Electric", "Poison", "Rock", "Steel"],
            ["Normal", "Water", "Ice", "Fighting", "Ground", "Psychic", "Ghost", "Dragon", "Dark", "Fairy"],
            ["Grass", "Bug"],
            ["Flying"]
            )
        },
        {
          "Rock",
          new(
            "Rock",
            ["Fire", "Ice", "Flying", "Bug"],
            ["Normal", "Water", "Grass", "Electric", "Poison", "Psychic", "Rock", "Ghost", "Dragon", "Dark", "Fairy"],
            ["Fighting", "Ground", "Steel"],
            []
            )
        },
        {
          "Normal",
          new(
            "Normal",
            [],
            ["Normal", "Fire", "Water", "Grass", "Electric", "Ice", "Fighting", "Poison", "Ground", "Flying", "Psychic", "Bug", "Dragon", "Dark", "Fairy"],
            ["Rock", "Steel"],
            ["Ghost"]
            )
        },
        {
          "Fire",
          new(
            "Fire",
            ["Grass", "Ice", "Bug", "Steel"],
            ["Normal", "Electric", "Fighting", "Poison", "Ground", "Flying", "Psychic", "Ghost", "Dark"],
            ["Fire", "Water", "Rock", "Dragon"],
            []
            )
        },
        {
          "Water",
          new(
            "Water",
            ["Fire", "Ground", "Rock"],
            ["Normal", "Electric", "Ice", "Fighting", "Poison", "Flying", "Psychic", "Bug", "Ghost", "Dark"],
            ["Water", "Grass", "Dragon"],
            []
            )
        },
        {
          "Grass",
          new(
            "Grass",
            ["Water", "Ground", "Rock"],
            ["Normal", "Electric", "Ice", "Fighting", "Psychic", "Bug", "Ghost", "Dark"],
            ["Fire", "Grass", "Poison", "Flying", "Bug", "Dragon", "Steel"],
            []
            )
        }
      };     
    }
      

    public static Dictionary<string, DefensiveType> DefenseTypes()
    {
      return new Dictionary<string, DefensiveType>
      {
        {"Normal", new DefensiveType("Normal", ["Fighting"], ["Normal", "Fire", "Water", "Grass", "Electric", "Ice", "Poison", "Ground", "Flying", "Psychic", "Bug", "Rock", "Dragon", "Dark", "Steel", "Fairy"], [], ["Ghost"])},
        {"Ground", new DefensiveType("Ground", ["Water", "Grass", "Ice"], ["Normal", "Fire", "Fighting", "Ground", "Flying", "Psychic", "Bug", "Ghost", "Dragon", "Dark", "Steel", "Fairy"], ["Poison", "Rock"], ["Electric"])},
        {"Fire", new DefensiveType("Fire", ["Water", "Ground", "Rock"], ["Normal", "Electric", "Fighting", "Poison", "Flying", "Psychic", "Ghost", "Dragon", "Dark"], ["Fire", "Grass", "Ice", "Bug", "Steel"], [])},
        {"Water", new DefensiveType("Water", ["Grass", "Electric"], ["Normal", "Fighting", "Poison", "Ground", "Flying", "Psychic", "Bug", "Rock", "Ghost", "Dragon", "Dark"], ["Fire", "Water", "Ice", "Steel"], [])},
        {"Grass", new DefensiveType("Grass", ["Fire", "Ice", "Poison", "Flying", "Bug"], ["Normal", "Fighting", "Psychic", "Rock", "Ghost", "Dragon", "Dark", "Steel"], ["Water", "Grass", "Electric", "Ground"], [])},
        {"Flying", new DefensiveType("Flying", ["Electric", "Ice", "Rock"], ["Normal", "Fire", "Water", "Poison", "Flying", "Psychic", "Ghost", "Dragon", "Dark", "Steel"], ["Grass", "Fighting", "Bug"], ["Ground"])},
        {"Poison", new DefensiveType("Poison", ["Ground", "Psychic"], ["Normal", "Fire", "Water", "Electric", "Ice", "Flying", "Rock", "Ghost", "Dragon", "Dark", "Steel"], ["Grass", "Fighting", "Poison", "Bug"], []){} }
      };
    }

    public static Dictionary<string, PokemonType> Types()
    {
      Dictionary<string, MoveType> Offense = OffenseTypes();
      Dictionary<string, DefensiveType> Defense = DefenseTypes();
      return new Dictionary<string, PokemonType>
      {
        {"Normal",  new("Normal", Offense["Normal"], Defense["Normal"])},
        {"Ground", new("Ground", Offense["Ground"], Defense["Ground"])},
        {"Fire", new("Fire", Offense["Fire"], Defense["Fire"])},
        {"Water", new("Water", Offense["Water"], Defense["Water"])},
        {"Grass", new("Grass", Offense["Grass"], Defense["Grass"])},
        {"Flying", new("Flying", Offense["Flying"], Defense["Flying"])},
        {"Poison", new("Poison", Offense["Poison"], Defense["Poison"])},
      };
    }

    public static Dictionary<string, MoveInfo> MoveInformation(){
      Dictionary<string, PokemonType> Types = Initialize.Types();
      return new Dictionary<string, MoveInfo> {
        {"BodySlam", new MoveInfo("Body Slam", "A full-body slam that may cause paralysis.", Types["Normal"], 85, 15, 1)},
        {"Earthquake", new ("Earthquake", "Tough but useless vs. flying foes.", Types["Ground"], 100, 10, 1)}
      };
    }
    public static Dictionary<string, Move> Moves()
    {
      Dictionary<string, MoveInfo> MoveInfo = MoveInformation();
      return new Dictionary<string, Move>
      {
        {
          "BodySlam",
          new Move(
            MoveInfo["BodySlam"],
            (self, target) =>
            {
              string selfName = self.Name!;
              Console.WriteLine($"{selfName} uses {MoveInfo["BodySlam"].Name}!");

              // can make a switch case later for text regarding type matchups
              if (target.Type[0].Name == "Ghost")
              {
                Console.WriteLine("But it was not effective!");
              }
              else
              {
                Random rand = new();
                // Checks if there's a chance of paralyzing
                bool paralyzeChance = rand.Next(1, 100) <= 30;
                if (paralyzeChance)
                {
                  string targetFirstType = target.Type[0].Name;
                }
              }
            })
        },
        {
        "Earthquake",
        new Move(MoveInfo["Earthquake"],
        (self, target) =>
        {
          string selfName = self.Name!;
          Console.WriteLine($"{selfName} uses {MoveInfo["Earthquake"].Name}!");

          if (target.Type[0].Name == "Flying")
          {
            Console.WriteLine("But it was not effective!");
          }
        })
        }
      };
    }
    public static Dictionary<string, Status> Status()
    {
      return new Dictionary<string, Status>
      {
        {
          "OK",
          new Status("OK", "No status applied.", onPokemon => {})
        },
        {"PAR",
          new Status("PAR", "The Speed of a paralyzed Pokémon is decreased by 75%, rounded down.",
          onPokemon =>
          {
            // Speed drop stays even if it's cured from paralysis with an item or through rest
            int currentSpeed = onPokemon.Stat.Speed;
            onPokemon.Stat.Speed = ((int)(currentSpeed * 0.75));
          }
        )}
      };
    }

    public static Dictionary<string, Pokemon> Pokemons()
    {
      Dictionary<string, PokemonType> Type = Types();

      return new Dictionary<string, Pokemon>
      {
        {
          "Bulbasaur",
          new Pokemon(
            new BaseStat(45, 49, 65, 49, 65, 45),
            [Type["Grass"], Type["Poison"]],
            "Bulbasaur"
          )
        },
        {
          "Ivysaur",
          new Pokemon(
            new BaseStat(60, 62, 80, 63, 80, 60),
            [Type["Grass"], Type["Poison"]],
            "Ivysaur"
          )
        },
        {
          "Venusaur",
          new Pokemon(
            new BaseStat(80, 82, 100, 83, 100, 80),
            [Type["Grass"], Type["Poison"]],
            "Venusaur"
          )
        },
        {
          "Charmander",
          new Pokemon(
            new BaseStat(39, 52, 60, 43, 50, 65),
            [Type["Fire"]],
            "Charmander"
          )
        },
        {
          "Charmeleon",
          new Pokemon(
            new BaseStat(58, 64, 80, 58, 65, 80),
            [Type["Fire"]],
            "Charmeleon"
          )
        },
        {
          "Charizard",
          new Pokemon(
            new BaseStat(78, 84, 109, 78, 85, 100),
            [Type["Fire"], Type["Flying"]],
            "Charizard"
          )
        },
        {
          "Squirtle",
          new Pokemon(
            new BaseStat(44, 48, 50, 65, 64, 43),
            [Type["Water"]],
            "Squirtle"
          )
        },
        {
          "Wartortle",
          new Pokemon(
            new BaseStat(59, 63, 65,80, 80, 58),
            [Type["Water"]],
            "Wartortle"
          )
        },
        {
          "Blastoise",
          new Pokemon(
            new BaseStat(79, 83, 85, 100, 105, 78),
            [Type["Water"]],
            "Blastoise"
          )
        }
      };
    }
  }
}