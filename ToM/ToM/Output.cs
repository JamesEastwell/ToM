using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IOutput
{
    void DisplayIntro();
    void SummariseRound(Player[] PlayersList);
    void DisplayRoll(int[] SortedDie);
    void EndGame(Player[] PlayersList);
    void NextPlayer();

}

