// Represents the critical hit chance
using PokeDojo.src.Poke;
using PokeDojo.src.Data.Moves;
using System;

namespace PokeDojo.src.Battles.Event
{
  static class CriticalHit
  {
    // On a normal move, if the random number is less than the threshold, a critical hit is performed
    public static bool IsCriticalHit(Pokemon pokemon, Move move)
    {
      Random random = new Random();
      if (pokemon.GetGeneration().GetGeneration() == 1)
      {
        byte randomNumber = Convert.ToByte(random.Next(0, 255));
        byte threshold = ProcessThreshold(pokemon, move);
        // Process crits for moves normally
        if (randomNumber < threshold)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
      else
      {
        int value = random.Next(1, 16);
          if (value == 1)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    public static byte ProcessThreshold(Pokemon pokemon, Move move)
    {
      byte threshold;
      if (pokemon.GetGeneration().GetGeneration() == 1)
      {
        //refactor later
        if (move.GetMoveInfo().GetHighCrit())
        {
           int preThreshold = (int)Convert.ToByte(pokemon.GetStat().GetSpeed() / 2);
           threshold = (byte)Math.Min(preThreshold, 255);
        }
        else
        {
          threshold = Convert.ToByte(pokemon.GetStat().GetSpeed() / 2);
        }
      }
      else
      {
        threshold = Convert.ToByte((pokemon.GetStat().GetSpeed() / 2) / 256);
      }
      return threshold;
    }
  }
}
