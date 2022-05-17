using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class GameCLI : Game
{
    public GameCLI(): base(new InputCLI(), new OutputCLI())
    {
            
    }
}

