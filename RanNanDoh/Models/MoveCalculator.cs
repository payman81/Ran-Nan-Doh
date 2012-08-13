using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RanNanDoh.Bl;

namespace RanNanDoh.Models
{
    public interface IMoveCalculator
    {
        bool MoveWon(MoveType move1, MoveType move2);
    }

    public class MoveCalculator : IMoveCalculator
    {
        public bool MoveWon(MoveType move1, MoveType move2)
        {
            if ((move1 == MoveType.Punch && move2 == MoveType.Block) ||
                (move1 == MoveType.Kick && move2 == MoveType.Punch) ||
                (move1 == MoveType.Block && move2 == MoveType.Kick))
                return true;

            return false;
        }
    }
}