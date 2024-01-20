using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerWinForms
{
    public class Card
    {
        CardColor color;
        CardValue value;
        int id;
        string path;

        public Card() { }
        public Card(int id)
        {
            this.id = id;
            id--;
            this.value = (CardValue)(id % 13 + 1);
            this.color = (CardColor)(id / 13) + 1;
            path = "_" + id + "_" + value + "_of_" + color;
        }

        public CardColor Color { get => color; }
        public CardValue Value { get => value; }
        public int Id { get => id; init => id = value; }
        public string Path { get => path; }

        public override string? ToString()
        {
            return $"{value} of {color}/id:{id}";
        }
    }

    public enum CardColor
    {
        hearts = 1,
        spades = 2,
        clubs = 3,
        diamonds = 4
    }

    public enum CardValue
    {
        two = 1,
        three = 2,
        four = 3,
        five = 4,
        six = 5,
        seven = 6,
        eight = 7,
        nine = 8,
        ten = 9,
        jack = 10,
        queen = 11,
        king = 12,
        ace = 13
    }

}
