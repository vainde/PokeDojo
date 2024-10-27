using System;
using PokeDojo.Descriptor;
using PokeDojo.Stats;

namespace PokeDojo.Simulator
{
  class Simulator
  {

    static void Main()
    {
      //Setting up natures

      // Neutral Natures
      Nature Hardy = new Nature("Hardy", "Attack", "Attack");
      Nature Docile = new Nature("Docile", "Defense", "Defense");
      Nature Bashful = new Nature("Bashful", "Special Attack", "Special Attack");
      Nature Quirky = new Nature("Quirky", "Special Defense", "Special Defense");
      Nature Serious = new Nature("Serious", "Speed", "Speed");

      // Natures that increase attack
      Nature Lonely = new Nature("Lonely", "Attack", "Defense");
      Nature Adamant = new Nature("Adamant", "Attack", "Special Attack");
      Nature Naughty = new Nature("Naughty", "Attack", "Special Defense");
      Nature Brave = new Nature("Brave", "Attack", "Speed");

      // Natures that increase defense
      Nature Bold = new Nature("Bold", "Defense", "Attack");
      Nature Impish = new Nature("Impish", "Defense", "Special Attack");
      Nature Lax = new Nature("Lax", "Defense", "Special Defense");
      Nature Relaxed = new Nature("Relaxed", "Defense", "Speed");

      // Natures that increase special attack
      Nature Modest = new Nature("Modest", "Special Attack", "Attack");
      Nature Mild = new Nature("Mild", "Special Attack", "Defense"); 
      Nature Rash = new Nature("Rash", "Special Attack", "Special Defense");
      Nature Quiet = new Nature("Quiet", "Special Attack", "Speed");

      // Natures that increase special defense
      Nature Calm = new Nature("Calm", "Special Defense", "Attack");
      Nature Gentle = new Nature("Gentle", "Special Defense", "Defense");
      Nature Careful = new Nature("Careful", "Special Defense", "Special Attack");
      Nature Sassy = new Nature("Sassy", "Special Defense", "Speed");

      // Natures that increase speed
      Nature Timid = new Nature("Timid", "Speed", "Attack");
      Nature Hasty = new Nature("Hasty", "Speed", "Defense");
      Nature Jolly = new Nature("Jolly", "Speed", "Special Attack");
      Nature Naive = new Nature("Naive", "Speed", "Special Defense");

      List<Nature> natures =
        new List<Nature>()
        {
          Hardy,
          Docile,
          Quirky,
          Serious,
          Lonely,
          Adamant,
          Naughty,
          Brave,
          Bold,
          Impish,
          Lax,
          Relaxed,
          Modest,
          Mild,
          Rash,
          Quiet,
          Calm,
          Gentle,
          Careful,
          Sassy,
          Timid,
          Hasty,
          Jolly,
          Naive
        };

      // TO DO LATER: Test Gen 1
    }
  }
}
