using PokeDojo.src.Data.Stats;
using PokeDojo.src.Data.Type;
using PokeDojo.src.Data.Items;

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

    public static List<PokemonType> Types()
    {
      return new List<PokemonType>
      {
              // modify later
              new PokemonType("Fighting"),
              new PokemonType("Flying"),
              new PokemonType("Poison"),
              new PokemonType("Ground"),
              new PokemonType("Rock"),
              new PokemonType("Bug"),
              new PokemonType("Ghost"),
              new PokemonType("Steel"),
              new PokemonType("Fire"),
              new PokemonType("Water"),
              new PokemonType("Grass"),
              new PokemonType("Electric"),
              new PokemonType("Psychic"),
              new PokemonType("Ice"),
              new PokemonType("Dragon"),
              new PokemonType("Dark"),
              new PokemonType("Normal")
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