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
         Dictionary<string, PokemonType> Types = Initialize.Types();
         Dictionary<string, Move> Moves = Initialize.Moves();
         Dictionary<string, Status> Status = Initialize.Status();

          // Using snorlax as a test pokemon
          Stat SnorlaxStat = new();
          BaseStat SnorlaxBaseStat = new();
          StatValue SnorlaxValue = new();
          GenerationInfo SnorlaxGen2 = new() { };

          SnorlaxGen2.Generation = 2;
          SnorlaxGen2.Description.Name = "Snorlax";
          SnorlaxGen2.Description.Level = 50;

          // Adding a type, move and status
          List<PokemonType> SnorlaxType = [Types["Normal"]];
          List<Move> SnorlaxMoves = [Moves["BodySlam"]];
          Status SnorlaxStatus = Status["OK"];
     
          Pokemon SecondGenSnorlax = new(SnorlaxStat, SnorlaxBaseStat, SnorlaxValue, SnorlaxType, SnorlaxGen2, SnorlaxMoves, SnorlaxStatus);
          SecondGenSnorlax.Generation.Happiness = 255;

          // Adding stats
          SecondGenSnorlax.BaseStat.SetBaseStat(160, 110, 65, 65, 110, 30);
          SecondGenSnorlax.Value.GetIndividualValue().SetIndividualValue(15, 15, 15, 15, 15, 15);
          SecondGenSnorlax.Value.GetEffortValue().SetEffortValue(65535, 65535, 65535, 65535, 65535, 65535);
          Stat.EarlyGenHealth(SecondGenSnorlax);
          Stat.EarlyGenAttack(SecondGenSnorlax);
          Stat.EarlyGenDefense(SecondGenSnorlax);
          Stat.EarlyGenSpAttack(SecondGenSnorlax);
          Stat.EarlyGenSpDefense(SecondGenSnorlax);
          Stat.EarlyGenSpeed(SecondGenSnorlax);
          HiddenPower.HiddenPowerType(SecondGenSnorlax);

          // Testing a second pokemon
          Stat GolemStat = new();
          BaseStat GolemBaseStat = new();
          StatValue GolemValue = new();
          GenerationInfo GolemGen2 = new();
          GolemGen2.Generation = 2;
          GolemGen2.Description.Name = "Golem";
          GolemGen2.Description.Level = 50;

          // Adding a type, move and status
          List<PokemonType> GolemType = [Types["Ground"]];
          List<Move> GolemMoves = [Moves["Earthquake"]];
          Status GolemStatus = Status["OK"];

          Pokemon SecondGenGolem = new(GolemStat, GolemBaseStat, GolemValue, GolemType, GolemGen2, GolemMoves, GolemStatus);
          SecondGenGolem.Generation.Happiness = 255;

          SecondGenGolem.BaseStat.SetBaseStat(80, 120, 130, 55, 65, 45);
          SecondGenGolem.Value.GetIndividualValue().SetIndividualValue(15, 15, 15, 15, 15, 15);
          SecondGenGolem.Value.GetEffortValue().SetEffortValue(65535, 65535, 65535, 65535, 65535, 65535);
          Stat.EarlyGenHealth(SecondGenGolem);
          Stat.EarlyGenAttack(SecondGenGolem);
          Stat.EarlyGenDefense(SecondGenGolem);
          Stat.EarlyGenSpAttack(SecondGenGolem);
          Stat.EarlyGenSpDefense(SecondGenGolem);
          Stat.EarlyGenSpeed(SecondGenGolem);

          // Testing Chansey instead of Golem
          Stat ChanseyStat = new();
          BaseStat ChanseyBaseStat = new();
          StatValue ChanseyValue = new();
          GenerationInfo ChanseyGen2 = new();
          ChanseyGen2.Generation = 2;
          ChanseyGen2.Description.Name = "Chansey";
          ChanseyGen2.Description.Level = 50;

          // Adding a type, move, and status for Chansey
          List<PokemonType> ChanseyType = [Types["Normal"]]; // Assume this is the correct type for Chansey
          List<Move> ChanseyMoves = [Moves["BodySlam"]]; // Assume this is the correct move for Chansey
          Status ChanseyStatus = Status["OK"]; // Assume this is the correct status for Chansey

          Pokemon SecondGenChansey = new(ChanseyStat, ChanseyBaseStat, ChanseyValue, ChanseyType, ChanseyGen2, ChanseyMoves, ChanseyStatus);
          SecondGenChansey.Generation.Happiness = 255;

          // Setting the base stats for Chansey
          SecondGenChansey.BaseStat.SetBaseStat(250, 5, 5, 35, 105, 50);

          // Setting the individual values (IVs) for Chansey
          SecondGenChansey.Value.GetIndividualValue().SetIndividualValue(15, 15, 15, 15, 15, 15);

          // Setting the effort values (EVs) for Chansey
          SecondGenChansey.Value.GetEffortValue().SetEffortValue(65535, 65535, 65535, 65535, 65535, 65535);

          // Calculating the early generation stats for Chansey
          Stat.EarlyGenHealth(SecondGenChansey);
          Stat.EarlyGenAttack(SecondGenChansey);
          Stat.EarlyGenDefense(SecondGenChansey);
          Stat.EarlyGenSpAttack(SecondGenChansey);
          Stat.EarlyGenSpDefense(SecondGenChansey);
          Stat.EarlyGenSpeed(SecondGenChansey);

          // Testing Dugtrio instead of Golem
          Stat DugtrioStat = new();
          BaseStat DugtrioBaseStat = new();
          StatValue DugtrioValue = new();
          GenerationInfo DugtrioGen2 = new();
          DugtrioGen2.Generation = 2;
          DugtrioGen2.Description.Name = "Dugtrio";
          DugtrioGen2.Description.Level = 50;

          // Adding a type, move, and status for Dugtrio
          List<PokemonType> DugtrioType = [Types["Ground"]]; // Assume this is the correct type for Dugtrio
          List<Move> DugtrioMoves = [Moves["Earthquake"]]; // Assume this is the correct move for Dugtrio
          Status DugtrioStatus = Status["OK"]; // Assume this is the correct status for Dugtrio

          Pokemon SecondGenDugtrio = new(DugtrioStat, DugtrioBaseStat, DugtrioValue, DugtrioType, DugtrioGen2, DugtrioMoves, DugtrioStatus);
          SecondGenDugtrio.Generation.Happiness = 255;

          // Setting the base stats for Dugtrio
          SecondGenDugtrio.BaseStat.SetBaseStat(35, 100, 50, 50, 70, 120);

          // Setting the individual values (IVs) for Dugtrio
          SecondGenDugtrio.Value.GetIndividualValue().SetIndividualValue(15, 15, 15, 15, 15, 15);

          // Setting the effort values (EVs) for Dugtrio
          SecondGenDugtrio.Value.GetEffortValue().SetEffortValue(65535, 65535, 65535, 65535, 65535, 65535);

          // Calculating the early generation stats for Dugtrio
          Stat.EarlyGenHealth(SecondGenDugtrio);
          Stat.EarlyGenAttack(SecondGenDugtrio);
          Stat.EarlyGenDefense(SecondGenDugtrio);
          Stat.EarlyGenSpAttack(SecondGenDugtrio);
          Stat.EarlyGenSpDefense(SecondGenDugtrio);
          Stat.EarlyGenSpeed(SecondGenDugtrio);

          List<Pokemon> team1 = [];
          List<Pokemon> team2 = [];

          team1.Add(SecondGenSnorlax);
          team1.Add(SecondGenDugtrio);
          team2.Add(SecondGenGolem); 
          team2.Add(SecondGenChansey);

          Battle battle = new(team1, team2);
          battle.HandleTurn();
        }
    }
}
