using System;
using PokeDojo.Descriptor;
using PokeDojo.Stats;
using PokeDojo.Value;

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

      List<Nature> Natures =
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

      /*
       * Early Gen consists of Gen 1 and Gen 2
       * Gen 1: No item
       * Gen 2: Has item, hp type, shiny, gender
       */
      Description AlakazamDesc = new Description();
      Stat AlakazamStat = new Stat();
      BaseStat AlakazamBaseStat = new BaseStat();
      StatValue AlakazamValue = new StatValue();
      Gender AlakazamGender = new Gender();
      Pokemon Alakazam = new Pokemon(AlakazamDesc, AlakazamStat, AlakazamBaseStat, AlakazamValue, AlakazamGender, Natures[4]);

      // Let's use an Alakazam with max SP.ATK AND max SPD EV's and max IV's based on Gen 2
      Alakazam.GetDescription().SetName("Alakazam");
      Alakazam.GetDescription().SetLevel(100);
      Alakazam.GetBaseStat().SetBaseStat(55, 50, 40, 135, 85, 120);
      Alakazam.GetStatValue().GetIndividualValue().SetIndividualValue(15, 15, 15, 15, 15, 15);
      Alakazam.GetStatValue().GetEffortValue().SetEffortValue(65535, 65535, 65535, 65535, 65535, 65535);
      Alakazam.GetStat().EarlyGenHealth(Alakazam);
      Alakazam.GetStat().EarlyGenAttack(Alakazam);
      Alakazam.GetStat().EarlyGenDefense(Alakazam);
      Alakazam.GetStat().EarlyGenSpAttack(Alakazam);
      Alakazam.GetStat().EarlyGenSpDefense(Alakazam);
      Alakazam.GetStat().EarlyGenSpeed(Alakazam);

      Console.WriteLine("ALAKAZAM SUMMARY");
      Console.WriteLine($"Name: {Alakazam.GetDescription().GetName()}");
      Console.WriteLine($"Level: {Alakazam.GetDescription().GetLevel()}");
      Console.WriteLine($"Gender: {Alakazam.GetGender().GetGender()}");
      Console.WriteLine($"HP: {Alakazam.GetStat().GetHealth()}");
      Console.WriteLine($"Attack: {Alakazam.GetStat().GetAttack()}");
      Console.WriteLine($"Defense: {Alakazam.GetStat().GetDefense()}");
      Console.WriteLine($"Sp. Attack: {Alakazam.GetStat().GetSpecialAttack()}");
      Console.WriteLine($"Sp. Defense: {Alakazam.GetStat().GetSpecialDefense()}");
      Console.WriteLine($"Speed: {Alakazam.GetStat().GetSpeed()}");
    }
  }
}
