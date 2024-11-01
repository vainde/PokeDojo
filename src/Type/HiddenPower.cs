// Responsible for calculating a pokemon's HP type based on IV

// Responsible for calculating a pokemon's HP type based on IV
using PokeDojo.src.Poke;

namespace PokeDojo.src.Type
{
    static class HiddenPower
    {
        static public int HiddenPowerValue(Pokemon pokemon)
        {
            /* 
             * Type is determined by adding the two least significant bits
             * of the attack and defense ivs
             * */
            int attackIV = pokemon.GetStatValue().GetIndividualValue().GetAttackIV();
            int defenseIV = pokemon.GetStatValue().GetIndividualValue().GetDefenseIV();
            int hiddenPowerValue = 4 * (attackIV % 4) + defenseIV % 4;
            return hiddenPowerValue;
        }

        static public void HiddenPowerType(Pokemon pokemon, List<PokemonType> types)
        {
            int HPValue = HiddenPowerValue(pokemon);
            if (HPValue >= 0 && HPValue <= 15)
            {
                pokemon.GetGeneration().SetHiddenPower(types[HPValue]);
            }
        }
    }
}
