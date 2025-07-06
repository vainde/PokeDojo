// Represents how the user views pokemon information
using PokeDojo.src.Poke;
using PokeDojo.src.Data.Moves;

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
            Console.WriteLine();
            ShowMenu(pokemon);
        }


        static public void ShowDefaultSummary(Pokemon pokemon)
        {
            ShowBasicDescription(pokemon);
        }

        static public void ShowMenu(Pokemon pokemon)
        {
            SummaryMenu(pokemon);
        }

        static public void SummaryMenu(Pokemon pokemon)
        {
            int option;
            do
            {
                Console.WriteLine("POKEMON INFORMATION");
                PrintBorder();
                Console.WriteLine("1. View Stats");
                Console.WriteLine("2. View Item");
                Console.WriteLine("3. View Moves");
                Console.WriteLine("4. Quit");
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
                        ShowMoveInformation(pokemon);
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
            } while (option != 4);
        }

        static public void ShowAllStats(Pokemon pokemon)
        {
            int option;
            do
            {
                Console.WriteLine("EACH STAT CATEGORY");
                PrintBorder();
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
                    default:
                        Console.WriteLine("Invalid option selected. Please try again!");
                        Console.WriteLine();
                        break;
                }
            } while (option != 5);
        }

        static public void ShowBasicDescription(Pokemon pokemon)
        {
            Console.WriteLine($"Name: {pokemon.Name}");
            Console.WriteLine($"Level: {pokemon.Level}");
            if(pokemon.Type.Count > 1)
            {
              Console.WriteLine($"Type: {pokemon.Type[0].Name} {pokemon.Type[1].Name}");
            }
            else
            {
              Console.WriteLine($"Type: {pokemon.Type[0].Name}");
            }
        }

        static public void ShowEarlyGenStats(Pokemon pokemon)
        {
            Console.WriteLine("STATS");
            Console.WriteLine("=========================");
            Console.WriteLine($"HP: {pokemon.Stat.Health}");
            Console.WriteLine($"Attack: {pokemon.Stat.Attack}");
            Console.WriteLine($"Defense: {pokemon.Stat.Defense}");
            Console.WriteLine($"Sp. Attack: {pokemon.Stat.SpAttack}");
            Console.WriteLine($"Sp. Defense: {pokemon.Stat.SpDefense}");
            Console.WriteLine($"Speed: {pokemon.Stat.Speed}");
        }

        static public void ShowEarlyGenEffort(Pokemon pokemon)
        {
            Console.WriteLine("EFFORT VALUES");
            PrintBorder();
            Console.WriteLine($"HP EV: {pokemon.Value.GetEffortValue().GetHealthEV()}");
            Console.WriteLine($"Attack EV: {pokemon.Value.GetEffortValue().GetAttackEV()}");
            Console.WriteLine($"Defense EV:  {pokemon.Value.GetEffortValue().GetDefenseEV()}");
            Console.WriteLine($"Sp.Attack EV: {pokemon.Value.GetEffortValue().GetDefenseEV()}");
            Console.WriteLine($"Sp. Defense EV:  {pokemon.Value.GetEffortValue().GetSpDefenseEV()}");
            Console.WriteLine($"Speed EV: {pokemon.Value.GetEffortValue().GetSpeedEV()}");
        }

        static public void ShowEarlyGenDeterminant(Pokemon pokemon)
        {
            Console.WriteLine("DETERMINANT VALUES");
            PrintBorder();
            Console.WriteLine($"HP DV: {pokemon.Value.GetIndividualValue().GetHealthIV()}");
            Console.WriteLine($"Attack DV: {pokemon.Value.GetIndividualValue().GetAttackIV()}");
            Console.WriteLine($"Defense EV: {pokemon.Value.GetIndividualValue().GetDefenseIV()}");
            Console.WriteLine($"Sp. Attack EV: {pokemon.Value.GetIndividualValue().GetSpAttackIV()}");
            Console.WriteLine($"Sp. Defense EV: {pokemon.Value.GetIndividualValue().GetSpDefenseIV()}");
            Console.WriteLine($"Speed EV: {pokemon.Value.GetIndividualValue().GetSpeedIV()}");
        }


        static public void ShowBaseStat(Pokemon pokemon)
        {
            Console.WriteLine("BASE STATS");
            PrintBorder();
            Console.WriteLine($"HP {pokemon.BaseStat.Health}");
            Console.WriteLine($"Attack: {pokemon.BaseStat.Attack}");
            Console.WriteLine($"Defense: {pokemon.BaseStat.Defense}");
            Console.WriteLine($"Sp. Attack: {pokemon.BaseStat.SpAttack}");
            Console.WriteLine($"Sp. Defense: {pokemon.BaseStat.SpDefense}");
            Console.WriteLine($"Speed: {pokemon.BaseStat.Speed}");
        }

        static public void ShowMoveInformation(Pokemon pokemon)
        {
            Console.WriteLine("MOVE INFORMATION");
            PrintBorder();
            int i = 1;
            foreach(Move move in pokemon.Moves)
            {
              Console.WriteLine($"Move {i}: {move.GetMoveInfo().Name}");
              Console.WriteLine($"Description: {move.GetMoveInfo().Description}");
              Console.WriteLine($"Category: {move.GetMoveInfo().Category}");
              Console.WriteLine($"Base Power: {move.GetMoveInfo().BasePower}");
              Console.WriteLine($"Power Points: {move.GetMoveInfo().PowerPoint}");
              Console.WriteLine($"Accuracy: {move.GetAccuracy() * 100}%");
              i++;
              Console.WriteLine();
            }
        }

        static void PrintBorder()
        {
          Console.WriteLine("=========================");
        }
    }
}
