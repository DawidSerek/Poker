using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal static class Dealer
    {
        public static List<Player> Players = new List<Player>();
        public static void AddPlayer() => Players.Add(new Player());

        public static void ShuffleDeck()
        {
            for(int i = 0; i < 100; i++) {
                Random rand = new Random();
                int deckCount = Deck.CurrentCardLayout.Count;

                int RandomIndex1 = (int)rand.Next(deckCount);
                int RandomIndex2 = (int)rand.Next(deckCount);

                Card temp = Deck.CurrentCardLayout[RandomIndex1];

                Deck.CurrentCardLayout[RandomIndex1] = Deck.CurrentCardLayout[RandomIndex2];
                Deck.CurrentCardLayout[RandomIndex2] = temp;
            }
        }


        public static (EvalEnum, int) Evaluate(Card[] EvaluatedCards)
        {
            if( EvaluatedCards.Length != 5 ) 
                throw new ArgumentException("Provided amount of cards should be of size 5");
            
            //sort cards to determine if given hand is street
            EvaluatedCards = EvaluatedCards.OrderBy(x => x.Value).ToArray();
            bool hasStreet = true;
            for(int i = 1; i < 5; i++)
                if (EvaluatedCards[i - 1].Value + 1 != EvaluatedCards[i].Value)
                {
                    hasStreet = false;
                    hasStreet = (int)EvaluatedCards[4].Value == 13 &&
                        (int)EvaluatedCards[0].Value == 2 &&
                        (int)EvaluatedCards[1].Value == 3 &&
                        (int)EvaluatedCards[2].Value == 4 &&
                        (int)EvaluatedCards[3].Value == 5; //anoying edge case with ace
                    break;
                }

            //count occurances to determine if we have pair, two pairs, flush, house, etc. $ determine highest card
            int[] cardColors = new int[4 + 1];
            int[] cardValues = new int[13 + 1];
            int highestCard = -1;
            foreach ( Card c in EvaluatedCards)
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
                if(cardValues[i] >= NoOccurrencesMax)
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

                for(int i = 1; i < 13 + 1; i++)
                    if (cardValues[i] == 2)
                    {
                        lowerPairValue = i;
                        break;
                    }
                secondEval = MostRepeatedVal * 10000 + lowerPairValue * 100 + highestCard;
            }  
            else if (pairs == 1)
                firstEval = EvalEnum.pair;


            return (firstEval, secondEval);
        }

        public enum EvalEnum
        {
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
}
