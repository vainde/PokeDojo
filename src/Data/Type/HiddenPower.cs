// Responsible for calculating a pokemon's HP type based on IV

using PokeDojo.src.Poke;
using PokeDojo.src.Data.Type;

namespace PokeDojo.src.Data.Type
{
    static class HiddenPower
    {
        static public int HiddenPowerValue(Pokemon pokemon)
        {
            /* 
             * Type is determined by adding the two least significant bits
             * of the attack and defense ivs
             * */
            int attackIV = pokemon.Value.GetIndividualValue().GetAttackIV();
            int defenseIV = pokemon.Value.GetIndividualValue().GetDefenseIV();
            int hiddenPowerValue = 4 * (attackIV % 4) + defenseIV % 4;
            return hiddenPowerValue;
        }

        static public void HiddenPowerType(Pokemon pokemon)
        {
          List<PokemonType> Types = Initialize.Types();

          pokemon.Generation.HiddenPower = Types[0];
        }
  }
}
