using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_or_More_Assignment
{
    public class Die
    {
        private int Value { get; set; }
        public int GetValue()
        {
            return Value;
        }
        public void Roll()
        {
            Random rnd = new Random();
            Value = rnd.Next(1, 7);
        }
    }
}
