using PokeDojo.Poke;
using PokeDojo.Descriptor;
using PokeDojo.Stats;
using PokeDojo.Value;
using PokeDojo.Summaries;
using PokeDojo.Types;
using PokeDojo.Generation;

namespace PokeDojo.Simulator
{
    class Simulator
  {

    static void Main()
    {
      //Setting up natures

      List<Nature> natures = new List<Nature>
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

      List<PokemonType> Types = new List<PokemonType>
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

      //TESTING GEN 1 AND GEN 2
      Description SnorlaxDesc = new Description();
      Stat SnorlaxStat = new Stat();
      BaseStat SnorlaxBaseStat = new BaseStat();
      StatValue SnorlaxValue = new StatValue();
      PokemonType SnorlaxType = Types[16];
      GenerationInfo SnorlaxGen1 = new GenerationInfo(1, SnorlaxDesc);

      // Gen 1 Snorlax
      Pokemon Snorlax = new Pokemon(SnorlaxStat, SnorlaxBaseStat, SnorlaxValue, SnorlaxType, SnorlaxGen1);
      Snorlax.GetGeneration().GetDescription().SetName("Snorlax"); 
      Snorlax.GetGeneration().GetDescription().SetLevel(100);
      Snorlax.GetPokemonType().SetName("Normal");

      // Let's use a Snorlax with max ATK and max HP EV's and max IV's based on Early Gen
      Snorlax.GetBaseStat().SetBaseStat(160, 110, 65, 65, 110, 30);
      Snorlax.GetStatValue().GetIndividualValue().SetIndividualValue(15, 15, 15, 15, 15, 15);
      Snorlax.GetStatValue().GetEffortValue().SetEffortValue(65535, 65535, 65535, 65535, 65535, 65535);
      Snorlax.GetStat().EarlyGenHealth(Snorlax);
      Snorlax.GetStat().EarlyGenAttack(Snorlax);
      Snorlax.GetStat().EarlyGenDefense(Snorlax);
      Snorlax.GetStat().EarlyGenSpAttack(Snorlax);
      Snorlax.GetStat().EarlyGenSpDefense(Snorlax);
      Snorlax.GetStat().EarlyGenSpeed(Snorlax);

      // Gen 2 Snorlax
      Gender SnorlaxGender = new Gender();
      GenerationInfo SnorlaxGen2 = new GenerationInfo(2, SnorlaxDesc);
      Pokemon SecondGenSnorlax = new(SnorlaxStat, SnorlaxBaseStat, SnorlaxValue, SnorlaxType, SnorlaxGen2);
      SecondGenSnorlax.GetGeneration().SetHappiness(255);
      // Setting Hidden Power
      HiddenPower.HiddenPowerType(SecondGenSnorlax, Types);

      // Setting Stats for Snorlax
      SecondGenSnorlax.GetBaseStat().SetBaseStat(160, 110, 65, 65, 110, 30);
      SecondGenSnorlax.GetStatValue().GetIndividualValue().SetIndividualValue(15, 15, 15, 15, 15, 15);
      SecondGenSnorlax.GetStatValue().GetEffortValue().SetEffortValue(65535, 65535, 65535, 65535, 65535, 65535);
      SecondGenSnorlax.GetStat().EarlyGenHealth(Snorlax);
      SecondGenSnorlax.GetStat().EarlyGenAttack(Snorlax);
      SecondGenSnorlax.GetStat().EarlyGenDefense(Snorlax);
      SecondGenSnorlax.GetStat().EarlyGenSpAttack(Snorlax);
      SecondGenSnorlax.GetStat().EarlyGenSpDefense(Snorlax);
      SecondGenSnorlax.GetStat().EarlyGenSpeed(Snorlax);


      Summary.Gen1Summary(Snorlax);
      Summary.Gen2Summary(SecondGenSnorlax);
    }
  }
}
