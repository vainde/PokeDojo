using PokeDojo.src.Data.Stats;
using PokeDojo.src.Data.Type;
using PokeDojo.src.Data.Items;
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
        )},
        {
        "Flying",
          new(
          "Flying",
          ["Grass", "Fighting", "Bug"],
          ["Normal", "Fire", "Water", "Ice", "Poison", "Ground", "Flying", "Psychic", "Ghost", "Dragon", "Dark"],
          ["Electric", "Rock", "Steel"],
          []
        )},
        {"Poison", new("Poison", ["Grass", "Fairy"], ["Normal", "Fire", "Water", "Electric", "Ice", "Fighting", "Flying", "Psychic", "Bug", "Dragon", "Dark"], ["Poison", "Ground", "Rock", "Ghost"], ["Steel"])},
        {"Ground", new("Ground", ["Fire", "Electric", "Poison", "Rock", "Steel"], ["Normal", "Water", "Ice", "Fighting", "Ground", "Psychic", "Ghost", "Dragon", "Dark", "Fairy"], ["Grass", "Bug"], ["Flying"])},
        {"Rock", new("Rock", ["Fire", "Ice", "Flying", "Bug"], ["Normal", "Water", "Grass", "Electric", "Poison", "Psychic", "Rock", "Ghost", "Dragon", "Dark", "Fairy"], ["Fighting", "Ground", "Steel"], [])},
        {"Normal", new("Normal", [], ["Normal", "Fire", "Water", "Grass", "Electric", "Ice", "Fighting", "Poison", "Ground", "Flying", "Psychic", "Bug", "Dragon", "Dark", "Fairy"], ["Rock", "Steel"], ["Ghost"])}
      };     
    }
      

    public static Dictionary<string, DefensiveType> DefenseTypes()
    {
      return new Dictionary<string, DefensiveType>
      {
        {"Normal", new DefensiveType("Normal", ["Fighting"], ["Normal", "Fire", "Water", "Grass", "Electric", "Ice", "Poison", "Ground", "Flying", "Psychic", "Bug", "Rock", "Dragon", "Dark", "Steel", "Fairy"], [], ["Ghost"])},
        {"Ground", new DefensiveType("Ground", ["Water", "Grass", "Ice"], ["Normal", "Fire", "Fighting", "Ground", "Flying", "Psychic", "Bug", "Ghost", "Dragon", "Dark", "Steel", "Fairy"], ["Poison", "Rock"], ["Electric"])}
      };
    }

    public static Dictionary<string, PokemonType> Types()
    {
      Dictionary<string, MoveType> Offense = OffenseTypes();
      Dictionary<string, DefensiveType> Defense = DefenseTypes();
      return new Dictionary<string, PokemonType>
      {
        {"Normal",  new("Normal", Offense["Normal"], Defense["Normal"])},
        {"Ground", new("Ground", Offense["Ground"], Defense["Ground"])}
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
              string selfName = self.Generation.Description.Name;
              Console.WriteLine($"{selfName} uses {MoveInfo["BodySlam"].Name}!");

              // can make a switch case later for text regarding type matchups
              if (target.Type[0].Name == "Ghost")
              {
                Console.WriteLine("But it was not effective!");
              }
              else
              {
                Random rand = new Random();
                // Checks if there's a chance of paralyzing
                bool paralyzeChance = rand.Next(1, 100) <= 30;
                if (paralyzeChance)
                {
                  string targetFirstType = target.Type[0].Name;
                  int generation = self.Generation.Generation;
                  //check how much it's supposed to slow based on gen 1 and gen 2
                  if (generation == 2 && (targetFirstType != "Normal" && targetFirstType != "Ground")) // have to account for dual types
                  {
                    int targetSpeed = target.Stat.Speed;
                    target.Stat.Speed = ((int)(targetSpeed * 0.75));
                    string targetName = self.Generation.Description.Name;
                    Console.WriteLine($"Enemy {targetName} is paralyzed! It may not attack!");
                  }
                }
              }
            })
        },
        {
        "Earthquake",
        new Move(MoveInfo["Earthquake"],
        (self, target) =>
        {
          string selfName = self.Generation.Description.Name;
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

    public static Dictionary<string, Item> Items()
    {
      return new Dictionary<string, Item>
      {
        {
          "",
          new Item("", "", onPokemon => {})
        },
        {
          "Leftovers",
          new Item(
            "Leftovers",
            "At the end of every turn, holder restores 1/6 of its max HP.",
            onPokemon =>
            {
              int maxHealth = onPokemon.Stat.Health;
              int currentHealth = onPokemon.Stat.CurrentHealth;

              // If the pokemon is already at max health, it doesn't need to heal
              if(currentHealth != maxHealth)
              {
                // Ratio at which leftovers recovers health
                int restoreHealth = (maxHealth / 16);
                // Health restored can't go over max health
                if(currentHealth + restoreHealth > maxHealth)
                {
                  onPokemon.Stat.CurrentHealth = maxHealth;
                }
                // Restore health by 1/16 of max health
                else
                {
                  onPokemon.Stat.CurrentHealth = currentHealth + restoreHealth;
                }
              }
            }
          )
        },
        {
          "Light Ball",
          new Item(
          "Light Ball",
          "If held by Pikachu, it's special attack is doubled.",
          onPokemon =>
          {
            string pokemonName = onPokemon.Generation.Description.Name;
            // Pikachu with a lightball needs to double it's sp. attack
            if(pokemonName == "Pikachu")
            {
              int specialAttack = onPokemon.Stat.SpAttack;
              onPokemon.Stat.SpAttack = specialAttack * 2;
            }
          }
          )
        },
        {
          "Gold Berry",
          new Item(
            "Gold Berry",
            "Restores 30 HP when at 1/2 max HP or less.",
            onPokemon =>
            {
              int maxHealth = onPokemon.Stat.Health;
              int currentHealth = onPokemon.Stat.CurrentHealth;
              // Needs to heal by 30 HP if it meets the condition
              if(currentHealth < (maxHealth / 2))
              {
                onPokemon.Stat.CurrentHealth = currentHealth + 30;
              }
            }
          )
        },
        {
          "Thick Club",
          new Item(
            "Thick Club",
            "If held by a Cubone or Marowak, its Attack is doubled",
            onPokemon =>
            {
              string pokemonName = onPokemon.Generation.Description.Name;
              if(pokemonName == "Cubone" || pokemonName == "Marowak")
              {
                int attack = onPokemon.Stat.Attack;
                onPokemon.Stat.Attack = (attack * 2);
              }
            }
          )
        }
      };
    }
  }
}