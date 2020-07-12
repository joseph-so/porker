using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    class PlayerHand
    {

        private readonly bool _isFlush = false;
        private readonly bool _isStraight = false;
        private readonly Dictionary<int, int> _cardHand;

        private static readonly Dictionary<char, int> CardMap = new Dictionary<char, int>
        {
            {'2', 2},
            {'3', 3},
            {'4', 4},
            {'5', 5},
            {'6', 6},
            {'7', 7},
            {'8', 8},
            {'9', 9},
            {'T', 10},
            {'J', 11},
            {'Q', 12},
            {'K', 13},
            {'A', 14}
        };

        public PlayerHand(string cards)
        {
            string[] cardDeck = cards.Split(' ');
            _isFlush = IsFlush(cardDeck);

            _cardHand = (from card in cardDeck
                    group card by card[0]
                    into c
                    select new {Key = CardMap[c.Key], Count = c.Count()})
                .OrderByDescending(t => t.Count).ThenByDescending(t => t.Key)
                .ToDictionary(t => t.Key, t => t.Count);

            _isStraight = IsStraight();

            Rank = CheckRank();
        }

        public int Rank { get; private set; } = 0;

        protected int[] Cards => _cardHand.Keys.ToArray();

        private int CheckRank()
        {
            if (IsStraightFlush())
                return _cardHand.FirstOrDefault().Key == 14 ? 10 : 9;

            if (IsFourOfAKind())
                return 8;

            if (IsFullHouse())
                return 7;

            if (_isFlush)
                return 6;

            if (_isStraight)
                return 5;

            if (IsThreeOfAKind())
                return 4;

            if (IsTwoPairs())
                return 3;

            return IsPair()?2:1;
        }
        
        private static bool IsFlush(IEnumerable<string> cards) => cards.GroupBy(c => c[1]).Count() == 1;
        private bool IsFourOfAKind() => _cardHand.FirstOrDefault().Value == 4;
        private bool IsFullHouse() => (_cardHand.FirstOrDefault().Value == 3 && _cardHand.LastOrDefault().Value == 2);
        private bool IsPair() => (_cardHand.FirstOrDefault().Value == 2 && _cardHand.Count == 4);
        private bool IsStraight() =>
            (_cardHand.Count == 5 & _cardHand.FirstOrDefault().Key - _cardHand.LastOrDefault().Key == 4);
        private bool IsStraightFlush() => _isFlush && _isStraight;
        private bool IsThreeOfAKind() => (_cardHand.FirstOrDefault().Value == 3 && _cardHand.Count == 3);
        private bool IsTwoPairs() => (_cardHand.FirstOrDefault().Value == 2 && _cardHand.Count == 3);

        public int Compare(PlayerHand otherPlayerHand)
        {
            if (Rank != otherPlayerHand.Rank) return Rank > otherPlayerHand.Rank ? 1 : -1;
            
            int[] cards = Cards;
            int[] otherPlayerCards = otherPlayerHand.Cards;
                
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] != otherPlayerCards[i])
                    return cards[i] > otherPlayerCards[i] ? 1 : -1;
            }

            return 0;

        }
    }
}
