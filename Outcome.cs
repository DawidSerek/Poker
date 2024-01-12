using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Outcome
    {
        EvalEnum firstEval;
        int secondEval;
        int handUtility;

        public Outcome(EvalEnum firstEval, int secondEval, int handUtility)
        {
            this.FirstEval = firstEval;
            this.SecondEval = secondEval;
            this.HandUtility = handUtility;
        }

        public EvalEnum FirstEval { get => firstEval; set => firstEval = value; }
        public int SecondEval { get => secondEval; set => secondEval = value; }
        public int HandUtility { get => handUtility; set => handUtility = value; }

        public override string? ToString() => ($"first eval: {firstEval}, second eval: {secondEval}, hand utility: {handUtility}");
    }

    public enum EvalEnum
    {
        err = 0,
        high = 1,
        pair = 2,
        pairs = 3,
        three = 4,
        street = 5,
        straight = 6,
        flush = 7,
        house = 8,
        quads = 9,
        poker = 10,
        rpoker = 11
    }
}
