using PokeDojo.Poke;
namespace PokeDojo.Summaries
{
  static class Summary
  {
    static public void Gen1Summary(Pokemon pokemon)
    {
      Console.WriteLine($"{pokemon.GetDescription().GetName()} Gen 1 Summary");
      Console.WriteLine($"--------------------------------------------");
      ShowGen1Description(pokemon);
      int option;

      Console.WriteLine("1. Stats");
      Console.WriteLine("2. Effort Values");
      Console.WriteLine("3. Individual Values");
      Console.WriteLine("4. Base Stats");
      Console.WriteLine("5. Quit");

      do
      {
        Console.WriteLine("Option Selected");
        Console.Write(">");
        option = Convert.ToInt32(Console.ReadLine());
        switch (option)
        {
          case 1:
              ShowEarlyGenStats(pokemon);
            break;
          case 2:
            ShowEarlyGenEffort(pokemon);
            break;
          case 3:
            ShowEarlyGenDeterminant(pokemon);
            break;
          case 4:
            ShowBaseStat(pokemon);
            break;
          case 5:
            Console.WriteLine("Ending Gen 1 Summary");
            break;
          default:
            Console.WriteLine("Invalid option selected. Please try again!");
            break;
        }
      } while (option != 5);
    }

    static public void ShowGen1Description(Pokemon pokemon)
    {
      Console.WriteLine($"Name: {pokemon.GetDescription().GetName()}");
      Console.WriteLine($"Level: {pokemon.GetDescription().GetLevel()}");
    }

    static public void ShowGen2Description(Pokemon pokemon) 
    {
      Console.WriteLine($"Gender: {pokemon.GetGender().GetGender()}");
    }

    static public void ShowEarlyGenStats(Pokemon pokemon)
    {
      Console.WriteLine("STATS");
      Console.WriteLine("-----");
      Console.WriteLine($"HP: {pokemon.GetStat().GetHealth()}");
      Console.WriteLine($"Attack: {pokemon.GetStat().GetAttack()}");
      Console.WriteLine($"Defense: {pokemon.GetStat().GetDefense()}");
      Console.WriteLine($"Sp. Attack: {pokemon.GetStat().GetSpecialAttack()}");
      Console.WriteLine($"Sp. Defense: {pokemon.GetStat().GetSpecialDefense()}");
      Console.WriteLine($"Speed: {pokemon.GetStat().GetSpeed()}");
    }

    static public void ShowEarlyGenEffort(Pokemon pokemon)
    {
      Console.WriteLine("EFFORT VALUES");
      Console.WriteLine("------");
      Console.WriteLine($"HP EV: {pokemon.GetStatValue().GetEffortValue().GetHealthEV()}");
      Console.WriteLine($"Attack EV: {pokemon.GetStatValue().GetEffortValue().GetAttackEV()}");
      Console.WriteLine($"Defense EV:  {pokemon.GetStatValue().GetEffortValue().GetDefenseEV()}");
      Console.WriteLine($"Sp.Attack EV: {pokemon.GetStatValue().GetEffortValue().GetDefenseEV()}");
      Console.WriteLine($"Sp. Defense EV:  {pokemon.GetStatValue().GetEffortValue().GetSpDefenseEV()}");
      Console.WriteLine($"Speed EV: {pokemon.GetStatValue().GetEffortValue().GetSpeedEV()}");
    }

    static public void ShowEarlyGenDeterminant(Pokemon pokemon)
    {
      Console.WriteLine("DETERMINANT VALUES");
      Console.WriteLine("------------------");
      Console.WriteLine($"HP DV: {pokemon.GetStatValue().GetIndividualValue().GetHealthIV()}");
      Console.WriteLine($"Attack DV: {pokemon.GetStatValue().GetIndividualValue().GetAttackIV()}");
      Console.WriteLine($"Defense EV: {pokemon.GetStatValue().GetIndividualValue().GetDefenseIV()}");
      Console.WriteLine($"Sp. Attack EV: {pokemon.GetStatValue().GetIndividualValue().GetSpAttackIV()}");
      Console.WriteLine($"Sp. Defense EV: {pokemon.GetStatValue().GetIndividualValue().GetSpDefenseIV()}");
      Console.WriteLine($"Speed EV: {pokemon.GetStatValue().GetIndividualValue().GetSpeedIV()}");
    }


    static public void ShowBaseStat(Pokemon pokemon)
    {
      Console.WriteLine("BASE STATS");
      Console.WriteLine("----------");
      Console.WriteLine($"HP {pokemon.GetBaseStat().GetBaseHealth()}");
      Console.WriteLine($"Attack: {pokemon.GetBaseStat().GetBaseAttack()}");
      Console.WriteLine($"Defense: {pokemon.GetBaseStat().GetBaseDefense()}");
      Console.WriteLine($"Sp. Attack: {pokemon.GetBaseStat().GetBaseSpAttack()}");
      Console.WriteLine($"Sp. Defense: {pokemon.GetBaseStat().GetBaseSpDefense()}");
      Console.WriteLine($"Speed: {pokemon.GetBaseStat().GetBaseSpeed()}");
    }
  }
}
