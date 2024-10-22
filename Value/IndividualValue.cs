namespace PokeDojo.Value
{
  class IndividualValue
  {
    int healthIV;
    int attackIV;
    int spAttackIV;
    int defenseIV;
    int spDefenseIV;
    int speedIV;

    public IndividualValue()
    {
      healthIV = 0;
      attackIV = 0;
      spAttackIV = 0;
      defenseIV = 0;
      spDefenseIV = 0;
      speedIV = 0;
    }

    public void SetIndividualValue(int health, int attack, int spAttack, int defense, int spDefense, int speed)
    {
      this.healthIV = health;
      this.attackIV = attack;
      this.spAttackIV = spAttack;
      this.defenseIV = defense;
      this.spDefenseIV = spDefense;
      this.speedIV = speed;
    }

    public int GetHealthIV()
    {
      return healthIV;
    }

    public int GetAttackIV()
    {
      return attackIV;
    }

    public int GetSpAttackIV()
    {
      return spAttackIV;
    }

    public int GetDefenseIV()
    {
      return defenseIV;
    }

    public int GetSpDefenseIV()
    {
      return spDefenseIV;
    }

    public int GetSpeedIV()
    {
      return speedIV;
    }
  }
}
