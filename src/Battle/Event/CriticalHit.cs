// Represents the critical hit chance
using PokeDojo.src.Poke;
using PokeDojo.src.Data.Moves;

namespace PokeDojo.src.Battle.Event
{
    static class CriticalHit
    {
        // On a normal move, if the random number is less than the threshold, a critical hit is performed
        public static bool IsCriticalHit(Pokemon pokemon, Move move)
        {
            Random random = new Random();
            byte threshold = Convert.ToByte(pokemon.GetStat().GetSpeed() / 2);
            byte randomNumber = Convert.ToByte(random.Next(0, 255));

            //Process moves with high crit here
            if (move.GetHighCrit())
            {
                threshold *= 8;
                if (threshold > 255)
                {
                    threshold = 255;
                }
            }

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
    }
}
