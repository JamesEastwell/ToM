using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_or_More_Assignment
{
    interface IOutput
    {
        void DisplayIntro();
        void SummariseRound(Player[] Players);
        void DisplayRoll(Player[] Players);
        int EndGame(Player[] Players);

    }
}
