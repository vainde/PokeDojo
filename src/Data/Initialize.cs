using PokeDojo.src.Data.Stats;
using PokeDojo.src.Data.Type;
using PokeDojo.src.Data.Items;
using PokeDojo.src.Data.Moves;
using PokeDojo.src.Data.Statuses;

namespace PokeDojo.src.Data
{
  public static class Initialize
  {
    public static List<Nature> Natures()
    {
      return new List<Nature>
      {
        // Natures that don't increase or decrease a stat
        new Nature("Hardy", "Attack", "Attack"),
        new Nature("Docile", "Defense", "Defense"),
        new Nature("Bashful", "Special Attack", "Special Attack"),
        new Nature("Quirky", "Special Defense", "Special Defense"),
        new Nature("Serious", "Speed", "Speed"),

        // Natures that increase the attack stat
        new Nature("Lonely", "Attack", "Defense"),
        new Nature("Adamant", "Attack", "Special Attack"),
        new Nature("Naughty", "Attack", "Special Defense"),
        new Nature("Brave", "Attack", "Speed"),

        // Natures that increase defense
        new Nature("Bold", "Defense", "Attack"),
        new Nature("Impish", "Defense", "Special Attack"),
        new Nature("Lax", "Defense", "Special Defense"),
        new Nature("Relaxed", "Defense", "Speed"),

        //Natures that increae special attack
        new Nature("Modest", "Special Attack", "Attack"),
        new Nature("Mild", "Special Attack", "Defense"),
        new Nature("Rash", "Special Attack", "Special Defense"),
        new Nature("Quiet", "Special Attack", "Speed"),

        // Natures that increase special defense
        new Nature("Calm", "Special Defense", "Attack"),
        new Nature("Gentle", "Special Defense", "Defense"),
        new Nature("Careful", "Special Defense", "Special Attack"),
        new Nature("Sassy", "Special Defense", "Speed"),

        // Natures that increase speed
        new Nature("Timid", "Speed", "Attack"),
        new Nature("Hasty", "Speed", "Defense"),
        new Nature("Jolly", "Speed", "Special Attack"),
        new Nature("Naive", "Speed", "Special Defense")
      };
    }

    public static List<MoveType> MoveTypes()
    {
      return new List<MoveType>
      {
              new MoveType("Fighting", ["Normal", "Ice", "Rock", "Dark", "Steel"], ["Fire", "Water", "Grass", "Electric", "Fighting", "Ground", "Dragon"], ["Poison", "Flying", "Psychic", "Bug", "Fairy"], ["Ghost"]),
              new MoveType("Flying", ["Grass", "Fighting", "Bug"], ["Normal", "Fire", "Water", "Ice", "Poison", "Ground", "Flying", "Psychic", "Ghost", "Dragon", "Dark"], ["Electric", "Rock", "Steel"], []),
              new MoveType("Poison", ["Grass", "Fairy"], ["Normal", "Fire", "Water", "Electric", "Ice", "Fighting", "Flying", "Psychic", "Bug", "Dragon", "Dark"], ["Poison", "Ground", "Rock", "Ghost"], ["Steel"]),
              new MoveType("Ground", ["Fire", "Electric", "Poison", "Rock", "Steel"], ["Normal", "Water", "Ice", "Fighting", "Ground", "Psychic", "Ghost", "Dragon", "Dark", "Fairy"], ["Grass", "Bug"], ["Flying"]),
              new MoveType("Rock", ["Fire", "Ice", "Flying", "Bug"], ["Normal", "Water", "Grass", "Electric", "Poison", "Psychic", "Rock", "Ghost", "Dragon", "Dark", "Fairy"], ["Fighting", "Ground", "Steel"], []),
              /* Will continue these later, I just want to test snorlax for now.
              new MoveType("Bug", []),
              new MoveType("Ghost"),
              new PokemonType("Steel"),
              new PokemonType("Fire"),
              new PokemonType("Water"),
              new PokemonType("Grass"),
              new PokemonType("Electric"),
              new PokemonType("Psychic"),
              new PokemonType("Ice"),
              new PokemonType("Dragon"),
              new PokemonType("Dark"),*/
              new MoveType("Normal", [], ["Normal", "Fire", "Water", "Grass", "Electric", "Ice", "Fighting", "Poison", "Ground", "Flying", "Psychic", "Bug", "Dragon", "Dark", "Fairy"], ["Rock", "Steel"], ["Ghost"])
      };
    }

    public static List<DefensiveType> DefenseTypes()
    {
      return new List<DefensiveType>()
      {
        new DefensiveType("Normal", ["Fighting"], ["Normal", "Fire", "Water", "Grass", "Electric", "Ice", "Poison", "Ground", "Flying", "Psychic", "Bug", "Rock", "Dragon", "Dark", "Steel", "Fairy"], [], ["Ghost"]),
        new DefensiveType("Ground", ["Water", "Grass", "Ice"], ["Normal", "Fire", "Fighting", "Ground", "Flying", "Psychic", "Bug", "Ghost", "Dragon", "Dark", "Steel", "Fairy"], ["Poison", "Rock"], ["Electric"])
      };
    }

    public static List<PokemonType> Types()
    {
      List<MoveType> MoveTypes = Initialize.MoveTypes();
      List<DefensiveType> Types = DefenseTypes();

      return new List<PokemonType>()
      {
        new PokemonType("Normal", MoveTypes[5], Types[0]),
        new PokemonType("Ground", MoveTypes[3], Types[1])
      };
    }

    public static List<MoveInfo> MoveInformation(){
      List<PokemonType> Types = Initialize.Types();

      return new List<MoveInfo>()
      {
        new MoveInfo("Body Slam", "A full-body slam that may cause paralysis.", Types[0], 85, 15),
        new MoveInfo("Earthquake", "Tough but useless vs. flying foes.", Types[1], 100, 10)
      };
    }
    public static List<Move> Moves()
    {
      List<MoveInfo> MoveInfo = MoveInformation();
      return new List<Move>()
      {
        new Move(MoveInfo[0],
        (self, target) =>
        {
          string selfName = self.GetGeneration().GetDescription().GetName();
          Console.WriteLine($"{selfName} uses {MoveInfo[0].GetName()}.");

          // can make a switch case later for text regarding type matchups
          if (target.GetPokemonType()[0].GetName() == "Ghost")
          {
            Console.WriteLine("But it was not effective!");
          }
          else
          {
            Random rand = new Random();
            // Checks if there's a chance of paralyzing
            if (rand.Next(0, 1) < 0.30)
            {
              string targetFirstType = target.GetPokemonType()[0].GetName();
              int generation = self.GetGeneration().GetGeneration();
              //check how much it's supposed to slow based on gen 1 and gen 2
              if (generation == 2 && (targetFirstType != "Normal" && targetFirstType != "Ground"))
              {
                int targetSpeed = target.GetStat().GetSpeed();
                target.GetStat().SetSpeed((int)(targetSpeed * 0.75));

                string targetName = self.GetGeneration().GetDescription().GetName();
                Console.WriteLine($"Enemy {targetName} is paralyzed! It may not attack!");
              }
            }
          }
        }),
        new Move(MoveInfo[1],
        (self, target) =>
        {
          string selfName = self.GetGeneration().GetDescription().GetName();
          Console.WriteLine($"{selfName} uses {MoveInfo[1].GetName()}.");

          if (target.GetPokemonType()[0].GetName() == "Flying")
          {
            Console.WriteLine("But it was not effective!");
          }
        })
      };
    }
    public static List<Status> Status()
    {
      return new List<Status>()
      {
        new Status("None", "No status applied.", onPokemon => {}),
        new Status("Paralyze", "The Speed of a paralyzed Pokémon is decreased by 75%, rounded down.", 
          onPokemon =>
          {
            // Speed drop stays even if it's cured from paralysis with an item or through rest
            int currentSpeed = onPokemon.GetStat().GetSpeed();
            onPokemon.GetStat().SetSpeed((int)(currentSpeed * 0.75));
          }
        ),
      };
    }

    public static List<Item> Items()
    {
      return new List<Item>{
        new Item(
          "",
          "",
          onPokemon =>
          {

          }
          ),
        new Item(
          "Leftovers",
          "At the end of every turn, holder restores 1/6 of its max HP.",
          onPokemon =>
          {
            int maxHealth = onPokemon.GetStat().GetHealth();
            int currentHealth = onPokemon.GetStat().GetCurrentHealth();

            // If the pokemon is already at max health, it doesn't need to heal
            if(currentHealth != maxHealth)
            {
              // Ratio at which leftovers recovers health
              int restoreHealth = (maxHealth / 16);
              // Health restored can't go over max health
              if(currentHealth + restoreHealth > maxHealth)
              {
                onPokemon.GetStat().SetCurrentHealth(maxHealth);
              }
              // Restore health by 1/16 of max health
              else
              {
                onPokemon.GetStat().SetCurrentHealth(currentHealth + restoreHealth);
              }
            }
          }
        ),
        new Item(
          "Light Ball", 
          "If held by Pikachu, it's special attack is doubled.",
          onPokemon =>
          {
            string pokemonName = onPokemon.GetGeneration().GetDescription().GetName();
            // Pikachu with a lightball needs to double it's sp. attack
            if(pokemonName == "Pikachu")
            {
              int specialAttack = onPokemon.GetStat().GetSpecialAttack();
              onPokemon.GetStat().SetSpecialAttack(specialAttack * 2);
            }
          }
          ),
        new Item(
          "Gold Berry",
          "Restores 30 HP when at 1/2 max HP or less.",
          onPokemon =>
          {
            int maxHealth = onPokemon.GetStat().GetHealth();
            int currentHealth = onPokemon.GetStat().GetCurrentHealth();
            // Needs to heal by 30 HP if it meets the condition
            if(currentHealth < (maxHealth / 2))
            {
              onPokemon.GetStat().SetCurrentHealth(currentHealth + 30);
            }
          }
          ),
        new Item(
          "Thick Club",
          "If held by a Cubone or Marowak, its Attack is doubled",
          onPokemon =>
          {
            string pokemonName = onPokemon.GetGeneration().GetDescription().GetName();
            if(pokemonName == "Cubone" || pokemonName == "Marowak")
            {
              int attack = onPokemon.GetStat().GetAttack();
              onPokemon.GetStat().SetAttack(attack * 2);
            }
          }
          )
      };
    }
  }
}