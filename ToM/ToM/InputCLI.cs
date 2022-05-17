using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class InputCLI: IInput
{
    public int TotalPlayers()
    {
        string input = "";
        bool Check = false;
        int Players = 0;
        while (Check == false || Players <= 0 || Players >= 200)
        {
     
            Console.WriteLine("Please enter the number of player who will be playing in the game? ");
            input = Console.ReadLine();
            Check = int.TryParse(input, out Players);
            if (Check == false || Players <= 0 || Players >= 200)
            {
                Console.WriteLine("The value inputted was not an integer or above 0 and therefore is not an accurate number of players. Please enter again. ");
            }
            else
            {
                Console.WriteLine("Thank you.");
            }
        }
        return Players;
    }
    public int TotalScore()
    {
        string input = "";
        int Score = 0;
        bool Check = false;
        while (Check == false || Score <= 0 || Score >= 500)
        {
            Console.WriteLine("Please enter what score you would like to play to. ");
            input = Console.ReadLine();
            Check = int.TryParse(input, out Score);
            if (Check == false || Score <= 0 || Score >= 500)
            {
                Console.WriteLine("The value inputted was not an integer or you inputted 0. Therefore this is not an accurate score to play to. Please enter again. ");
            }
            else
            {
                Console.WriteLine("Thank you.");
            }
        }
        return Score;
    }
    public void DoRoll()
    {
        Console.WriteLine("Press Enter to roll your die: ");
        bool check = false;
        ConsoleKeyInfo cki;
        while (check == false)
        {
            cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Enter)
            {
                return;
            }
            else
            {
                Console.WriteLine("\nPlease make sure you press the correct key to make your roll:");
            }
        }
        return;
    }
}
