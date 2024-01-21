using PokerWinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerWinForms
{
    public static class Dealer
    {
        //game management
        public static List<Player> Players = new List<Player>();
        public static void AddPlayer() => Players.Add(new Player());
        public static void ShuffleDeck(int amountOfShuffles = 100)
        {
            for (int i = 0; i < amountOfShuffles; i++)
            {
                Random rand = new Random();
                int deckCount = Deck.CurrentCardLayout.Count;

                int RandomIndex1 = (int)rand.Next(deckCount);
                int RandomIndex2 = (int)rand.Next(deckCount);

                Card temp = Deck.CurrentCardLayout[RandomIndex1];

                Deck.CurrentCardLayout[RandomIndex1] = Deck.CurrentCardLayout[RandomIndex2];
                Deck.CurrentCardLayout[RandomIndex2] = temp;
            }
        }

        //evaulation process
        public static Outcome Evaluate(List<Card> EvaluatedCards)
        {
            if (EvaluatedCards.Count != 5)
                throw new ArgumentException("Provided amount of cards should be of size 5");

            //sort cards to determine if given hand is street
            EvaluatedCards = EvaluatedCards.OrderBy(x => x.Value).ToList();
            bool hasStreet = true;
            for (int i = 1; i < 5; i++)
                if (EvaluatedCards[i - 1].Value + 1 != EvaluatedCards[i].Value)
                {
                    hasStreet = false;
                    hasStreet = (int)EvaluatedCards[4].Value == 13 &&
                        (int)EvaluatedCards[0].Value == 1 &&
                        (int)EvaluatedCards[1].Value == 2 &&
                        (int)EvaluatedCards[2].Value == 3 &&
                        (int)EvaluatedCards[3].Value == 4; //anoying edge case with ace
                    break;
                }

            //count occurances to determine if we have pair, two pairs, flush, house, etc. $ determine highest card
            int[] cardColors = new int[4 + 1];
            int[] cardValues = new int[13 + 1];
            int highestCard = -1;
            foreach (Card c in EvaluatedCards)
            {
                cardColors[(int)c.Color]++;
                cardValues[(int)c.Value]++;
                highestCard = Math.Max(highestCard, (int)c.Value);
            }

            int MostRepeatedVal = -1, //for extra edge cases
                NoOccurrencesMax = cardValues[1];
            int pairs = 0;
            bool hasThreeOaK = false,
                hasFlush = false,
                hasFourOaK = false;

            for (int i = 1; i < 13 + 1; i++)
            {
                if (cardValues[i] >= NoOccurrencesMax)
                {
                    NoOccurrencesMax = cardValues[i];
                    MostRepeatedVal = i;
                }

                switch (cardValues[i])
                {
                    case 2:
                        pairs++;
                        break;
                    case 3:
                        hasThreeOaK = true;
                        break;
                    case 4:
                        hasFourOaK = true;
                        break;
                }
            }
            for (int i = 0; i < 4 + 1; i++)
                if (cardColors[i] == 5) hasFlush = true;



            //evaluate
            EvalEnum firstEval = EvalEnum.high;
            int secondEval = highestCard;

            if (hasFlush && hasStreet && highestCard == 13)
                firstEval = EvalEnum.rpoker;
            else if (hasFlush && hasStreet)
                firstEval = EvalEnum.poker;
            else if (hasFourOaK)
            {
                firstEval = EvalEnum.quads;
                secondEval = MostRepeatedVal * 100 + highestCard;
            }
            else if (hasThreeOaK && pairs == 1)
            {
                firstEval = EvalEnum.house;
                secondEval = MostRepeatedVal;
            }
            else if (hasFlush)
                firstEval = EvalEnum.flush;
            else if (hasStreet)
                firstEval = EvalEnum.street;
            else if (hasThreeOaK)
                firstEval = EvalEnum.three;
            else if (pairs == 2)
            {
                firstEval = EvalEnum.pairs;
                int lowerPairValue = -1;

                for (int i = 1; i < 13 + 1; i++)
                    if (cardValues[i] == 2)
                    {
                        lowerPairValue = i;
                        break;
                    }
                secondEval = MostRepeatedVal * 10000 + lowerPairValue * 100 + highestCard;
            }
            else if (pairs == 1)
            {
                firstEval = EvalEnum.pair;
                secondEval = MostRepeatedVal * 100 + highestCard;
            }

            Outcome outcome = new Outcome(firstEval, secondEval, 2);

            return outcome;
        }
        private static Outcome nthEvaluate(List<(Card, int)> EvaluatedCards, int prevUtility)
        {
            if (EvaluatedCards.Count == 5)
            {
                List<Card> input = new List<Card>();
                foreach (var card in EvaluatedCards)
                    input.Add(card.Item1);
                return Evaluate(input);
            }

            Outcome output = new Outcome(EvalEnum.err, -1, prevUtility);
            for (int i = 0; i < EvaluatedCards.Count; i++)
            {
                List<(Card, int)> EvaluatedCardsWOi = EvaluatedCards.Where((_, index) => index != i).ToList();

                Outcome rec = nthEvaluate(EvaluatedCardsWOi, prevUtility);
                if (EvaluateOutputToInt(output) < EvaluateOutputToInt(rec))
                {
                    output = new Outcome(
                        rec.FirstEval,
                        rec.SecondEval,
                        rec.HandUtility -
                        ((EvaluatedCards[i].Item2 == 0 || EvaluatedCards[i].Item2 == 1) ? 1 : 0)
                    );
                }
            }
            return output;
        }
        public static Outcome nthEvaluateInit(List<Card> EvaluatedCards)
        {
            if (EvaluatedCards.Count != 5 && EvaluatedCards.Count != 6 && EvaluatedCards.Count != 7)
                throw new ArgumentException("Provided amount of cards should be of size 5-7");

            List<(Card, int)> input = new List<(Card, int)>();

            for (int i = 0; i < EvaluatedCards.Count; i++)
                input.Add((EvaluatedCards[i], i));

            Outcome output = nthEvaluate(input, -7);
            return output;
        }

        //comparasion utilities
        public static int EvaluateOutputToInt(Outcome o) => ((int)o.FirstEval * 1000000 + o.SecondEval);
        public static int OutcomeComparator(Outcome o1, Outcome o2)
        {
            if (EvaluateOutputToInt(o1) == EvaluateOutputToInt(o2)) return 0;
            if (EvaluateOutputToInt(o1) > EvaluateOutputToInt(o2)) return 1;
            return -1;
        }
    }
}
