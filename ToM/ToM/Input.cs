﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_or_More_Assignment
{
    interface IInput
    {
        int TotalPlayers();
        int TotalScore();
        void DoRoll();

    }
}
