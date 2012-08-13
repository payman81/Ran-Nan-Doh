using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using RanNanDoh.Models;

namespace RanNanDoh.Tests
{
    public class MoveCalculatorTests
    {
        MoveCalculator _target;

        [SetUp]
        public void Setup()
        {
            _target = new MoveCalculator();
        }

        [TestCase(Bl.MoveType.Punch, Bl.MoveType.Block)]
        [TestCase(Bl.MoveType.Kick, Bl.MoveType.Punch)]
        [TestCase(Bl.MoveType.Block, Bl.MoveType.Kick)]
        public void MoveWon_LoosingMoves(Bl.MoveType myMove, Bl.MoveType opponentMove)
        {
            var result = _target.MoveWon(myMove, opponentMove);

            Assert.IsFalse(result);
        }

        [TestCase(Bl.MoveType.Punch, Bl.MoveType.Block)]
        [TestCase(Bl.MoveType.Kick, Bl.MoveType.Punch)]
        [TestCase(Bl.MoveType.Block, Bl.MoveType.Kick)]
        public void MoveWon_WinningMoves(Bl.MoveType opponentMove, Bl.MoveType myMove)
        {
            var result = _target.MoveWon(myMove, opponentMove);

            Assert.IsTrue(result);
        }
    }
}