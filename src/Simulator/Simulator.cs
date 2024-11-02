using PokeDojo.src.Data;
using PokeDojo.src.Descriptor;
using PokeDojo.src.Generation;
using PokeDojo.src.Poke;
using PokeDojo.src.Stats;
using PokeDojo.src.Type;
using PokeDojo.src.Value;
using PokeDojo.src.Items;
using PokeDojo.src.Summaries;

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
          HiddenPower.HiddenPowerType(SecondGenSnorlax, Types);

          Summary.Gen2Summary(SecondGenSnorlax);

        }
    }
}
