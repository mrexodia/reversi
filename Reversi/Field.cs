using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    class Field
    {
        public enum State
        {
            Empty,
            Full
        }

        public State state { get; set; }
        public Player owner { get; private set; }

        public Field(Player owner)
        {
            this.owner = owner;
        }
    }
}
