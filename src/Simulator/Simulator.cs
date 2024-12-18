using PokeDojo.src.Data;
using PokeDojo.src.Poke.Generation;
using PokeDojo.src.Poke;
using PokeDojo.src.Data.Items;
using PokeDojo.src.Data.Type;
using PokeDojo.src.Data.Stats;
using PokeDojo.src.Data.Value;
using PokeDojo.src.Data.Moves;
using PokeDojo.src.Data.Statuses;

namespace PokeDojo.src.Simulator
{
    static class Simulator
    {
        static void Main()
        {
          // Pokemon need a type and items selection to pull from
          List<PokemonType> Types = Initialize.Types();
          List<Item> Items = Initialize.Items();
          List<Move> Moves = Initialize.Moves();
          List<Status> Status = Initialize.Status();

          // Using snorlax as a test pokemon
          Stat SnorlaxStat = new Stat();
          BaseStat SnorlaxBaseStat = new BaseStat();
          StatValue SnorlaxValue = new StatValue();
          GenerationInfo SnorlaxGen2 = new GenerationInfo();

          SnorlaxGen2.SetGeneration(2);
          SnorlaxGen2.GetDescription().SetName("Snorlax");
          SnorlaxGen2.GetDescription().SetLevel(50);

          // Adding a type, move and status
          List<PokemonType> SnorlaxType = [Types[0]];
          List<Move> SnorlaxMoves = [Moves[0]];
          Status SnorlaxStatus = Status[0];
     
          Pokemon SecondGenSnorlax = new(SnorlaxStat, SnorlaxBaseStat, SnorlaxValue, SnorlaxType, SnorlaxGen2, Items[0], SnorlaxMoves, SnorlaxStatus);
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
          HiddenPower.HiddenPowerType(SecondGenSnorlax);

          // Testing a second pokemon
          Stat GolemStat = new Stat();
          BaseStat GolemBaseStat = new BaseStat();
          StatValue GolemValue = new StatValue();
          GenerationInfo GolemGen2 = new GenerationInfo();
          GolemGen2.SetGeneration(2);
          GolemGen2.GetDescription().SetName("Golem");
          GolemGen2.GetDescription().SetLevel(50);

          // Adding a type, move and status
          List<PokemonType> GolemType = [Types[1]];
          List<Move> GolemMoves = [Moves[1]];
          Status GolemStatus = Status[0];

          Pokemon SecondGenGolem = new(GolemStat, GolemBaseStat, GolemValue, GolemType, GolemGen2, Items[0], GolemMoves, GolemStatus);
          SecondGenGolem.GetGeneration().SetHappiness(255);

          SecondGenGolem.GetBaseStat().SetBaseStat(80, 120, 130, 55, 65, 45);
          SecondGenGolem.GetStatValue().GetIndividualValue().SetIndividualValue(15, 15, 15, 15, 15, 15);
          SecondGenGolem.GetStatValue().GetEffortValue().SetEffortValue(65535, 65535, 65535, 65535, 65535, 65535);
          SecondGenGolem.GetStat().EarlyGenHealth(SecondGenGolem);
          SecondGenGolem.GetStat().EarlyGenAttack(SecondGenGolem);
          SecondGenGolem.GetStat().EarlyGenDefense(SecondGenGolem);
          SecondGenGolem.GetStat().EarlyGenSpAttack(SecondGenGolem);
          SecondGenGolem.GetStat().EarlyGenSpDefense(SecondGenGolem);
          SecondGenGolem.GetStat().EarlyGenSpeed(SecondGenGolem);
          HiddenPower.HiddenPowerType(SecondGenSnorlax);

          Summary.Summary.Gen2Summary(SecondGenSnorlax);
          Summary.Summary.Gen2Summary(SecondGenGolem);
          Summary.Fight.SimulateFight(SecondGenSnorlax, SecondGenGolem);
        }
    }
}
