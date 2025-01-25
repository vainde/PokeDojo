using PokeDojo.src.Data;
using PokeDojo.src.Poke.Generation;
using PokeDojo.src.Poke;
using PokeDojo.src.Data.Type;
using PokeDojo.src.Data.Stats;
using PokeDojo.src.Data.Value;
using PokeDojo.src.Data.Moves;
using PokeDojo.src.Data.Statuses;
using PokeDojo.src.Battles;

namespace PokeDojo.src.Simulator
{
    static class Simulator
    {
        static void Main()
        {
          // Pokemon need a type and items selection to pull from
          List<PokemonType> Types = Initialize.Types();
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
     
          Pokemon SecondGenSnorlax = new(SnorlaxStat, SnorlaxBaseStat, SnorlaxValue, SnorlaxType, SnorlaxGen2, SnorlaxMoves, SnorlaxStatus);
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

          Pokemon SecondGenGolem = new(GolemStat, GolemBaseStat, GolemValue, GolemType, GolemGen2, GolemMoves, GolemStatus);
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

          // Testing Chansey instead of Golem
          Stat ChanseyStat = new Stat();
          BaseStat ChanseyBaseStat = new BaseStat();
          StatValue ChanseyValue = new StatValue();
          GenerationInfo ChanseyGen2 = new GenerationInfo();
          ChanseyGen2.SetGeneration(2);
          ChanseyGen2.GetDescription().SetName("Chansey");
          ChanseyGen2.GetDescription().SetLevel(50);

          // Adding a type, move, and status for Chansey
          List<PokemonType> ChanseyType = [Types[0]]; // Assume this is the correct type for Chansey
          List<Move> ChanseyMoves = [Moves[0]]; // Assume this is the correct move for Chansey
          Status ChanseyStatus = Status[0]; // Assume this is the correct status for Chansey

          Pokemon SecondGenChansey = new(ChanseyStat, ChanseyBaseStat, ChanseyValue, ChanseyType, ChanseyGen2, ChanseyMoves, ChanseyStatus);
          SecondGenChansey.GetGeneration().SetHappiness(255);

          // Setting the base stats for Chansey
          SecondGenChansey.GetBaseStat().SetBaseStat(250, 5, 5, 35, 105, 50);

          // Setting the individual values (IVs) for Chansey
          SecondGenChansey.GetStatValue().GetIndividualValue().SetIndividualValue(15, 15, 15, 15, 15, 15);

          // Setting the effort values (EVs) for Chansey
          SecondGenChansey.GetStatValue().GetEffortValue().SetEffortValue(65535, 65535, 65535, 65535, 65535, 65535);

          // Calculating the early generation stats for Chansey
          SecondGenChansey.GetStat().EarlyGenHealth(SecondGenChansey);
          SecondGenChansey.GetStat().EarlyGenAttack(SecondGenChansey);
          SecondGenChansey.GetStat().EarlyGenDefense(SecondGenChansey);
          SecondGenChansey.GetStat().EarlyGenSpAttack(SecondGenChansey);
          SecondGenChansey.GetStat().EarlyGenSpDefense(SecondGenChansey);
          SecondGenChansey.GetStat().EarlyGenSpeed(SecondGenChansey);

          // Testing Dugtrio instead of Golem
          Stat DugtrioStat = new Stat();
          BaseStat DugtrioBaseStat = new BaseStat();
          StatValue DugtrioValue = new StatValue();
          GenerationInfo DugtrioGen2 = new GenerationInfo();
          DugtrioGen2.SetGeneration(2);
          DugtrioGen2.GetDescription().SetName("Dugtrio");
          DugtrioGen2.GetDescription().SetLevel(50);

          // Adding a type, move, and status for Dugtrio
          List<PokemonType> DugtrioType = [Types[1]]; // Assume this is the correct type for Dugtrio
          List<Move> DugtrioMoves = [Moves[1]]; // Assume this is the correct move for Dugtrio
          Status DugtrioStatus = Status[0]; // Assume this is the correct status for Dugtrio

          Pokemon SecondGenDugtrio = new(DugtrioStat, DugtrioBaseStat, DugtrioValue, DugtrioType, DugtrioGen2, DugtrioMoves, DugtrioStatus);
          SecondGenDugtrio.GetGeneration().SetHappiness(255);

          // Setting the base stats for Dugtrio
          SecondGenDugtrio.GetBaseStat().SetBaseStat(35, 100, 50, 50, 70, 120);

          // Setting the individual values (IVs) for Dugtrio
          SecondGenDugtrio.GetStatValue().GetIndividualValue().SetIndividualValue(15, 15, 15, 15, 15, 15);

          // Setting the effort values (EVs) for Dugtrio
          SecondGenDugtrio.GetStatValue().GetEffortValue().SetEffortValue(65535, 65535, 65535, 65535, 65535, 65535);

          // Calculating the early generation stats for Dugtrio
          SecondGenDugtrio.GetStat().EarlyGenHealth(SecondGenDugtrio);
          SecondGenDugtrio.GetStat().EarlyGenAttack(SecondGenDugtrio);
          SecondGenDugtrio.GetStat().EarlyGenDefense(SecondGenDugtrio);
          SecondGenDugtrio.GetStat().EarlyGenSpAttack(SecondGenDugtrio);
          SecondGenDugtrio.GetStat().EarlyGenSpDefense(SecondGenDugtrio);
          SecondGenDugtrio.GetStat().EarlyGenSpeed(SecondGenDugtrio);


          List<Pokemon> team1 = new List<Pokemon>();
          List<Pokemon> team2 = new List<Pokemon>();

          team1.Add(SecondGenSnorlax);
          team1.Add(SecondGenDugtrio);
          team2.Add(SecondGenGolem); 
          team2.Add(SecondGenChansey);

          Battle battle = new Battle(team1, team2);
          battle.HandleTurn();
        }
    }
}
