using PokeDojo.src.Data;
using PokeDojo.src.Poke.Generation;
using PokeDojo.src.Poke;
using PokeDojo.src.Simulator.Summary;
using PokeDojo.src.Data.Items;
using PokeDojo.src.Data.Type;
using PokeDojo.src.Data.Stats;
using PokeDojo.src.Data.Value;
using PokeDojo.src.Poke.Generation.Descriptor;

namespace PokeDojo.src.Simulator
{
    class Simulator
    {
        static void Main()
        {
          List<Nature> Natures = Initialize.Natures();
          List<PokemonType> Types = Initialize.Types();
          List<Item> Items = Initialize.Items();

          // Using snorlax as a test pokemon
          Description SnorlaxDesc = new Description();
          Stat SnorlaxStat = new Stat();
          BaseStat SnorlaxBaseStat = new BaseStat();
          StatValue SnorlaxValue = new StatValue();
          PokemonType SnorlaxType = Types[16];
          GenerationInfo SnorlaxGen2 = new GenerationInfo();
          Gender SnorlaxGender = new Gender();

          SnorlaxGen2.SetGeneration(2);
          SnorlaxGen2.GetDescription().SetName("Snorlax");
          SnorlaxGen2.GetDescription().SetLevel(50);

          Pokemon SecondGenSnorlax = new(SnorlaxStat, SnorlaxBaseStat, SnorlaxValue, SnorlaxType, SnorlaxGen2, Items[0]);
          SecondGenSnorlax.GetGeneration().SetHappiness(255);

          // Adding stats
          SecondGenSnorlax.GetBaseStat().SetBaseStat(160, 110, 65, 65, 110, 30);
          SecondGenSnorlax.GetStatValue().GetIndividualValue().SetIndividualValue(15, 15, 15, 15, 15, 15);
          SecondGenSnorlax.GetStatValue().GetEffortValue().SetEffortValue(65535, 65535, 65535, 65535, 65535, 65535);
          SecondGenSnorlax.GetStat().EarlyGenHealth(SecondGenSnorlax);
          SecondGenSnorlax.GetStat().EarlyGenAttack(SecondGenSnorlax);
          SecondGenSnorlax.GetStat().EarlyGenDefense(SecondGenSnorlax);
          SecondGenSnorlax.GetStat().EarlyGenSpAttack(SecondGenSnorlax);
          SecondGenSnorlax.GetStat().EarlyGenSpDefense(SecondGenSnorlax);
          SecondGenSnorlax.GetStat().EarlyGenSpeed(SecondGenSnorlax);

          HiddenPower.HiddenPowerType(SecondGenSnorlax, Types);

          Summary.Summary.Gen2Summary(SecondGenSnorlax);
        }
    }
}
