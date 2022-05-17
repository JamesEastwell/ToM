using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_or_More_Assignment
{
    class Player
    {
        private Die[] Die { get; set; }
        private int Score = 0;
        public int GetScore()
        {
            return Score;
        }
        public void SetScore(int Score)
        {
            this.Score = Score;
        }

        public Player(int NumDie)
        {
            Die = new Die[NumDie];
            for (int i = 0; i < NumDie; i++)
            {
                Die[i] = new Die();
            }
        }

        public void RollDie(int DieNumber)
        {
            Die[DieNumber].Roll();
        }
        public Die GetDie(int DieIndex)
        {
            return Die[DieIndex];
        }
        public int[] SummariseRolls()
        {
            int[] Matched = new int[6];
            foreach (Die Dice in Die)
            {
                int i = Dice.GetValue();
                if (i == 1) { Matched[0]++; }
                else if (i == 2) { Matched[1]++; }
                else if (i == 3) { Matched[2]++; }
                else if (i == 4) { Matched[3]++; }
                else if (i == 5) { Matched[4]++; }
                else if (i == 6) { Matched[5]++; }
            }
            return Matched;
        }
    }
}
