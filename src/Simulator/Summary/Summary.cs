// Represents how the user views pokemon information
using PokeDojo.src.Poke;

namespace PokeDojo.src.Simulator.Summary
{
    static class Summary
    {
        static public void Gen1Summary(Pokemon pokemon)
        {
            ShowDefaultSummary(pokemon);
            Console.WriteLine();
            ShowMenu(pokemon);
        }

        static public void Gen2Summary(Pokemon pokemon)
        {
            ShowDefaultSummary(pokemon);
            ShowGender(pokemon);
            ShowGen2Description(pokemon);
            Console.WriteLine();
            ShowMenu(pokemon);
        }


        static public void ShowDefaultSummary(Pokemon pokemon)
        {
            SummaryTitle(pokemon);
            ShowBasicDescription(pokemon);
        }

        static public void ShowMenu(Pokemon pokemon)
        {
            SummaryMenu(pokemon);
        }

        static public void SummaryMenu(Pokemon pokemon)
        {
            int option = 0;
            do
            {
                Console.WriteLine("POKEMON INFORMATION");
                Console.WriteLine("========================");
                Console.WriteLine("1. View Stats");
                Console.WriteLine("2. View Item");
                Console.WriteLine("3. Quit");
                Console.WriteLine();
                Console.WriteLine("What would you like to see?");
                Console.Write(">");
                option = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (option)
                {
                    case 1:
                        ShowAllStats(pokemon);
                        break;
                    case 2:
                        ShowItemInformation(pokemon);
                        break;
                    case 3:
                        Console.WriteLine("EXITING PROGRAM...");
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Invalid option selected.");
                        Console.WriteLine();
                        break;
                }
            } while (option != 3);
        }

        static public void SummaryTitle(Pokemon pokemon)
        {
            Console.WriteLine($"{pokemon.GetGeneration().GetDescription().GetName()} Gen {pokemon.GetGeneration().GetGeneration()} Summary");
            Console.WriteLine($"========================");
        }

        static public void ShowAllStats(Pokemon pokemon)
        {
            int option;
            do
            {
                Console.WriteLine("EACH STAT CATEGORY");
                Console.WriteLine("=========================");
                Console.WriteLine("1. Stats");
                Console.WriteLine("2. Effort Values");
                Console.WriteLine("3. Individual Values");
                Console.WriteLine("4. Base Stats");
                Console.WriteLine("5. Go Back");
                Console.WriteLine();
                Console.WriteLine("What would you like to see?");
                Console.Write(">");
                option = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (option)
                {
                    case 1:
                        ShowEarlyGenStats(pokemon);
                        Console.WriteLine();
                        break;
                    case 2:
                        ShowEarlyGenEffort(pokemon);
                        Console.WriteLine();
                        break;
                    case 3:
                        ShowEarlyGenDeterminant(pokemon);
                        Console.WriteLine();
                        break;
                    case 4:
                        ShowBaseStat(pokemon);
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.WriteLine($"Ending Gen {pokemon.GetGeneration().GetGeneration()} Summary");
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Invalid option selected. Please try again!");
                        Console.WriteLine();
                        break;
                }
            } while (option != 5);
        }

        static public void ShowItemInformation(Pokemon pokemon)
        {
            int option;
            do
            {
                Console.WriteLine("ITEM INFORMATION");
                Console.WriteLine("=========================");
                Console.WriteLine("1. View Item");
                Console.WriteLine("2. Go Back");
                Console.WriteLine("What would you like to see?");
                Console.Write(">");
                option = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (option)
                {
                    case 1:
                        if (pokemon.GetItem().GetName() == "")
                        {
                            Console.WriteLine("No item selected.");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine(pokemon.GetItem().GetName());
                            Console.WriteLine(pokemon.GetItem().GetDescription());
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Finished showing item...");
                        Console.WriteLine();
                        break;
                }

            } while (option != 2);
        }

        static public void ShowBasicDescription(Pokemon pokemon)
        {
            Console.WriteLine($"Name: {pokemon.GetGeneration().GetDescription().GetName()}");
            Console.WriteLine($"Level: {pokemon.GetGeneration().GetDescription().GetLevel()}");
            Console.WriteLine($"Type: {pokemon.GetPokemonType().GetName()}");
        }

        static public void ShowGen2Description(Pokemon pokemon)
        {
            Console.WriteLine($"Happiness: {pokemon.GetGeneration().GetHappiness()}");
            Console.WriteLine($"Hidden Power: {pokemon.GetGeneration().GetHiddenPower().GetName()}");
        }

        static public void ShowGender(Pokemon pokemon)
        {
            Console.WriteLine($"Gender: {pokemon.GetGeneration().GetGender().GetGender()}");
        }

        static public void ShowEarlyGenStats(Pokemon pokemon)
        {
            Console.WriteLine("STATS");
            Console.WriteLine("=========================");
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
            Console.WriteLine("=========================");
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
            Console.WriteLine("=========================");
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
            Console.WriteLine("=========================");
            Console.WriteLine($"HP {pokemon.GetBaseStat().GetBaseHealth()}");
            Console.WriteLine($"Attack: {pokemon.GetBaseStat().GetBaseAttack()}");
            Console.WriteLine($"Defense: {pokemon.GetBaseStat().GetBaseDefense()}");
            Console.WriteLine($"Sp. Attack: {pokemon.GetBaseStat().GetBaseSpAttack()}");
            Console.WriteLine($"Sp. Defense: {pokemon.GetBaseStat().GetBaseSpDefense()}");
            Console.WriteLine($"Speed: {pokemon.GetBaseStat().GetBaseSpeed()}");
        }
    }
}
