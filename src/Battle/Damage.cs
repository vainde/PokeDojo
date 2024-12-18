// Represents damage dealt by pokemon's moves
using PokeDojo.src.Data.Moves;
using PokeDojo.src.Poke;
using PokeDojo.src.Battle.Event;

namespace PokeDojo.src.Battle
{
  static class Damage
  {
    public static int Gen1Damage(Pokemon self, Pokemon target, Move move)
    {
      string firstType = self.GetPokemonType()[0].GetName();
      bool dualType = self.GetPokemonType().Count > 1;
      bool enemyDualType = self.GetPokemonType().Count == 2;
      double trueSTAB;
      double firstSTAB = move.GetMoveInfo().GetName() == firstType ? 1.5 : 1.0;

      // By default the STAB is based on the first type assuming the pokemon is monotyped
      trueSTAB = firstSTAB;

      if (dualType)
      {
        string secondType = self.GetPokemonType()[1].GetName();
        double secondSTAB = move.GetMoveInfo().GetName() == secondType ? 1.5 : 1.0;
        if (firstSTAB > 1.49 && firstSTAB < 1.51 || secondSTAB > 1.49 && secondSTAB < 1.51)
        {
          trueSTAB = 1.5;
        }
      }

      int criticalHit = CriticalHit.IsCriticalHit(self, move) ? 2 : 1;

      int level = self.GetGeneration().GetDescription().GetLevel();
      int basePower = move.GetMoveInfo().GetBasePower();

      // If the move used is special, use the special attack of the pokemon against the target's special defense
      string moveCategory = move.GetMoveInfo().GetCategory();
      int selfAttackType;
      int targetDefenseType;

      if(moveCategory == "Special")
      {
        selfAttackType = self.GetStat().GetSpecialAttack();
        targetDefenseType = target.GetStat().GetSpecialDefense();
      }
      else
      {
        selfAttackType = self.GetStat().GetAttack();
        targetDefenseType = self.GetStat().GetDefense();
      }

      double attackRatio = (double)selfAttackType / targetDefenseType; 

      int assessCrit = ((2 * level * criticalHit) / 5) + 2;
      int assessPower = (int)((assessCrit * basePower * attackRatio) / 50) + 2;

      double firstTypeAdvantage = move.GetTypeAdvantage(target, 0);
      double secondTypeAdvantage;

      if (!enemyDualType)
        secondTypeAdvantage = 1;
      else
        secondTypeAdvantage = move.GetTypeAdvantage(target, 1);

      int beforeRandom = (int)(assessPower * trueSTAB * firstTypeAdvantage * secondTypeAdvantage);
      Random random = new Random();
      int randomValue = beforeRandom >= 1 ? 1 : Convert.ToInt32(random.Next(217, 255) / 255);

      int afterRandom = beforeRandom * randomValue;
      return afterRandom;
    }
  }
}
