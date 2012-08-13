using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RanNanDoh.Bl;
using RanNanDoh.ViewModels;
using RanNanDoh.Models;

namespace RanNanDoh.Controllers
{
    public class GameController : Controller
    {
        private IMoveCalculator _moveCalc;

        public GameController(IMoveCalculator moveCalc)
        {
            _moveCalc = moveCalc;
        }

        [HttpGet]
        public ActionResult Play()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Play")]
        public ActionResult PlayPost(MoveType moveOne, MoveType moveTwo, MoveType moveThree)
        {
            var moveResults = new List<MoveResult> {
                new MoveResult { YourMove = moveOne, TheirMove = MoveType.Kick, Won = _moveCalc.MoveWon(moveOne, MoveType.Kick) },
                new MoveResult { YourMove = moveTwo, TheirMove = MoveType.Punch, Won = _moveCalc.MoveWon(moveTwo, MoveType.Punch) },
                new MoveResult { YourMove = moveThree, TheirMove = MoveType.Block, Won = _moveCalc.MoveWon(moveThree, MoveType.Block) }
            };

            return PlayResult(moveResults);
        }

        public ActionResult PlayResult(IEnumerable<MoveResult> moveResults)
        {
            return View("PlayResult", moveResults);
        }

    }

}

namespace RanNanDoh.Bl
{
    public enum MoveType { Kick, Punch, Block };
}

namespace RanNanDoh.ViewModels
{
    public class MoveResult
    {
        public MoveType YourMove { get; set; }
        public MoveType TheirMove { get; set; }
        public bool Won { get; set; }
    }
}
