using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class OutputCLI: IOutput
{
    public void DisplayIntro()
    {
        Console.WriteLine("Hello and welcome to the game Three or More");
        Console.WriteLine("In this game you will be asked to pick a number of players and total score you would like to play to");
        Console.WriteLine("All players will then take turns rolling 5 die and seeing who can match the most amount of die.");
        Console.WriteLine("If a player matches 0 or 1 dice then their turn is over and they get no points.");
        Console.WriteLine("If a player matches 2 die, then the player will get the chance to roll again to match at least 3");
        Console.WriteLine("If a player matches 3 die, then they will get 3 points added to their total");
        Console.WriteLine("If a player matches 4 die, then they will get 6 points added to their total");
        Console.WriteLine("If a player matches all 5 die, then they will get the maximum 12 points added to their total");
        Console.WriteLine("The game will end when anyone of the players reaches the predetermined total");
        Console.WriteLine("-----------------------------------------------------------------------------------");
    }
    public void SummariseRound(Player[] PlayersList)
    {
        Console.WriteLine("All players have now completed their turns in this round.");
        Console.WriteLine("Here are the current totals for all the players: ");
        //loop to print all the players scores
        for(int i = 0; i < PlayersList.Length; i++)
        {
            Console.WriteLine("Player " + (i+1) + ":" + PlayersList[i].GetScore());
        }
    }
    public void DisplayRoll(int[] SortedDie)
    {
        Console.WriteLine("You have rolled: " + String.Join(",", SortedDie));
    }
    public void EndGame(Player[] PlayersList)
    {
        //output all the scores of all players
        Player HighestScoring = PlayersList[0];
        int HighestScoringPlayer = 0;
        Player TempScoring = PlayersList[0];
        int TempScoringPlayer = 0;
        for (int i = 0; i < PlayersList.Length; i++)
        {
            Console.WriteLine("Player " + (i + 1) + ", finished with a score of:" + PlayersList[i].GetScore());
            Player CurrentPlayer = PlayersList[i];
            if (CurrentPlayer.GetScore() >= HighestScoring.GetScore())
            {
                TempScoring = HighestScoring;
                TempScoringPlayer = HighestScoringPlayer;
                HighestScoring = CurrentPlayer;
                HighestScoringPlayer = i;
                
            }
        }
        if (HighestScoring.GetScore() == TempScoring.GetScore())
        {
            //Draw
            Console.WriteLine("There were multiple winners.");
            Console.WriteLine("Congratulations to all of you");
        }
        else
        {
            //output who won
            Console.WriteLine("The winner of this game of Three or More is Player " + (HighestScoringPlayer + 1) + " who reached a score of: " + HighestScoring.GetScore());
            Console.WriteLine("Congratulations!");
        }
    }
    public void NextPlayer()
    {
        Console.WriteLine("You have now finished your turn.");
        Console.WriteLine("---------------------------------------------------------");
    }
}

