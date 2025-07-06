// Representsz damage dealt by pokemon's moves
using PokeDojo.src.Data.Moves;
using PokeDojo.src.Poke;
using PokeDojo.src.Battles.Event;

namespace PokeDojo.src.Battles
{
  static class Damage
  {
    public static int Gen1Damage(Pokemon self, Pokemon target, Move move)
    {

      double trueSTAB = CalculateTrueSTAB(self, move);
      double enemyFirstTypeAdvantage;
      double criticalHit;

      int selfLevel = self.Level;

      bool critHappened = CriticalHit.IsCriticalHit(self, move);
      if (critHappened)
      {
          criticalHit = (double)(2 * selfLevel + 5) / (selfLevel + 5);
      }
      else
      {
          criticalHit = 1;
      }

      if(criticalHit > 1.01)
      {
        move.CritHappened = true;
      }

      int level = self.Level;
      int basePower = move.GetMoveInfo().BasePower;

      // If the move used is special, use the special attack of the pokemon against the target's special defense
      GetAttackAndDefenseType(self, target, move, out int selfAttackType, out int targetDefenseType);

      double attackRatio = (double)selfAttackType / targetDefenseType;

      // This value applies the extra damage for a crit
      int assessCrit = (int)((2 * level * criticalHit) / 5) + 2;

      // This value encapsulates the entire damage
      int assessPower = (int)((assessCrit * basePower * attackRatio) / 50) + 2;

      enemyFirstTypeAdvantage = move.GetTypeAdvantage(target, 0);
      GetSecondTypeAdvantage(self, target, move, out double enemySecondTypeAdvantage);

      int beforeRandom = (int)(assessPower * trueSTAB * enemyFirstTypeAdvantage * enemySecondTypeAdvantage);
      Random random = new();
      int randomValue = beforeRandom >= 1 ? 1 : Convert.ToInt32(random.Next(217, 255) / 255);

      int damageAfterRandom = beforeRandom * randomValue;
      return damageAfterRandom;
    }

    static public double CalculateTrueSTAB(Pokemon self, Move move)
    {
      string firstType = self.Type[0].Name;
      bool dualType = self.Type.Count > 1;
      double trueSTAB;
      double firstSTAB = move.GetMoveInfo().Name == firstType ? 1.5 : 1.0;

      // By default the STAB is based on the first type assuming the pokemon is monotyped
      trueSTAB = firstSTAB;

      if (dualType)
      {
        string secondType = self.Type[1].Name;
        double secondSTAB = move.GetMoveInfo().Name == secondType ? 1.5 : 1.0;
        if (firstSTAB > 1.49 && firstSTAB < 1.51 || secondSTAB > 1.49 && secondSTAB < 1.51)
        {
          trueSTAB = 1.5;
        }
      }
      return trueSTAB;
    }

    public static void GetAttackAndDefenseType(Pokemon self, Pokemon target, Move move, out int selfAttackType, out int targetDefenseType)
    {
      string moveCategory = move.GetMoveInfo().Category!;

      if (moveCategory == "Special")
      {
        selfAttackType = self.Stat.SpAttack;
        targetDefenseType = target.Stat.SpDefense;
      }
      else
      {
        selfAttackType = self.Stat.Attack;
        targetDefenseType = self.Stat.Defense;
      }
    }

    public static void GetSecondTypeAdvantage(Pokemon self, Pokemon target, Move move, out double secondTypeAdvantage)
    {
      bool enemyDualType = self.Type.Count == 2;

      if (!enemyDualType)
        secondTypeAdvantage = 1;
      else
        secondTypeAdvantage = move.GetTypeAdvantage(target, 1);
    }
  }
}
