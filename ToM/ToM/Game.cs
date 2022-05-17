using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_or_More_Assignment
{
    class Game
    {
        private IInput Input;
        private IOutput Output;
        private Player[] PlayerList;
        protected Game(IInput Input, IOutput Output, int NumPlayers, int TargetScore)
        {
            this.Input = Input;
            this.Output = Output;
            PlayerList = new Player[NumPlayers];
            for (int i = 0; i < NumPlayers; i++)
            {
                PlayerList[i] = new Player(5);
            }
        }

        public void Run()
        {
            //Display Intro

            //Take input for total players and target score

            bool GameOver = false;
            while (GameOver == false)
            {
                foreach (Player Player in PlayerList)
                {
                    //Roll
                    for (int i = 0; i <= 5; i++)
                    {
                        Player.RollDie(i);
                    }
                    int[] Matched = Player.SummariseRolls();
                    int[] MatchingDie = GetMostOccurring(Matched);


                }
            }
        }
        private int[] GetMostOccurring(int[] Matched)
        {
            int Biggest = 0;
            for (int i = 0; i < Matched.Length; i++)
            {
                if (Matched[i] > Biggest)
                {
                    Biggest = Matched[i];
                }
            }
            int Saved = (Array.IndexOf(Matched, Biggest)) + 1;
            int[] MatchingDie = new int[2];
            MatchingDie[0] = Biggest;
            MatchingDie[1] = Saved;
            return MatchingDie;
        }
        private int ChangeScore(int[] MatchingDie)
        {
            //change the score for the players based on what they rolled
        }
    }
}
