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
          "Leftovers",
          "At the end of every turn, holder restores 1/6 of its max HP",
          onPokemon =>
          {
            int maxHealth = onPokemon.GetStat().GetHealth();
            int currentHealth = onPokemon.GetStat().GetCurrentHealth();

            if(currentHealth != maxHealth)
            {
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
        )
      };
    }
  }
}