namespace PokeDojo.src.Value
{
    public class EffortValue
    {
        int healthEV;
        int attackEV;
        int spAttackEV;
        int defenseEV;
        int spDefenseEV;
        int speedEV;

        public EffortValue()
        {
            healthEV = 0;
            attackEV = 0;
            spAttackEV = 0;
            defenseEV = 0;
            spDefenseEV = 0;
            speedEV = 0;
        }

        public void SetEffortValue(int health, int attack, int spAttack, int defense, int spDefense, int speed)
        {
            healthEV = health;
            attackEV = attack;
            spAttackEV = spAttack;
            defenseEV = defense;
            spDefenseEV = spDefense;
            speedEV = speed;
        }

        public int GetHealthEV()
        {
            return healthEV;
        }
        public int GetAttackEV()
        {
            return attackEV;
        }

        public int GetSpAttackEV()
        {
            return spAttackEV;
        }
        public int GetDefenseEV()
        {
            return defenseEV;
        }
        public int GetSpDefenseEV()
        {
            return spDefenseEV;
        }
        public int GetSpeedEV()
        {
            return speedEV;
        }
    }
}
