using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    class Field
    {
        enum State
        {
            Empty,
            Semi,
            Full
        }

        public Player Owner { get; set; }
    }
}
