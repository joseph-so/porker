using Xunit;

namespace Poker.Test
{
    public class PlayerHandTest
    {
        [Fact]
        public void RoyalFlush()
        {
            PlayerHand p = new PlayerHand("TD JD QD KD AD");
            Assert.Equal(10, p.Rank);
        }

        [Fact]
        public void StraightFlush()
        {
            PlayerHand p = new PlayerHand("2D 4D 5D 3D 6D");
            Assert.Equal(9, p.Rank);
            
            //A 2 3 4 5 cannot be used as a low card
            p = new PlayerHand("2D 4D 5D 3D AD");
            Assert.NotEqual(9, p.Rank);
        }

        [Fact]
        public void FourOfAKind()
        {
            PlayerHand p = new PlayerHand("2D 2S 9D 2H 2C");
            Assert.Equal(8, p.Rank);
        }

        [Fact]
        public void FullHouse()
        {
            PlayerHand p = new PlayerHand("2H 3S 2D 3H 2C");
            Assert.Equal(7, p.Rank);
        }

        [Fact]
        public void Flush()
        {
            //Test with Diamonds
            PlayerHand p = new PlayerHand("2D 3D 5D 7D 9D");
            Assert.Equal(6, p.Rank);

            p = new PlayerHand("AH 8H 5H 7H 9H");
            Assert.Equal(6, p.Rank);

            p = new PlayerHand("JS 8S KS 7S 9S");
            Assert.Equal(6, p.Rank);

            p = new PlayerHand("QC TC 5C 2C JC");
            Assert.Equal(6, p.Rank);
            
            //This is a Straight flush
            p = new PlayerHand("2D 4D 5D 3D 6D");
            Assert.NotEqual(6, p.Rank);
        }

        [Fact]
        public void Straight()
        {
            PlayerHand p = new PlayerHand("2D 4D 5D 3D 6S");
            Assert.Equal(5, p.Rank);

            //A 2 3 4 5 cannot be used as a low card
            p = new PlayerHand("2D 4D 5D 3S AD");
            Assert.NotEqual(5, p.Rank);

            //This is a Straight flush
            p = new PlayerHand("2D 4D 5D 3D 6D");
            Assert.NotEqual(5, p.Rank);
        }

        [Fact]
        public void ThreeOfAKind()
        {
            PlayerHand p = new PlayerHand("2H 3S 2D 5H 2C");
            Assert.Equal(4, p.Rank);

            p = new PlayerHand("2H 3S 2D 3H 2C");
            Assert.NotEqual(4, p.Rank);
        }

        [Fact]
        public void TwoPairs()
        {
            PlayerHand p = new PlayerHand("3H 5D AS 5C 3C");
            Assert.Equal(3, p.Rank);
        }

        [Fact]
        public void Pair()
        {
            PlayerHand p = new PlayerHand("3H 5D AS 9C AC");
            Assert.Equal(2, p.Rank);

            //This is a 2 pair
            p = new PlayerHand("3H 5D AS 5C 3C");
            Assert.NotEqual(2, p.Rank);
        }

        [Fact]
        public void HighCard()
        {
            PlayerHand p = new PlayerHand("9D 8S 2D TS JS");
            Assert.Equal(1, p.Rank);

            p = new PlayerHand("2S 4D 5D 3D AD");
            Assert.Equal(1, p.Rank);

            //This is a straight
            p = new PlayerHand("2S 4D 5D 3D 6D");
            Assert.NotEqual(1, p.Rank);
        }

        [Fact]
        public void CompareWithDifferentRank()
        {
            PlayerHand player1= new PlayerHand("TS JS KS QS AS");
            PlayerHand player2 = new PlayerHand("TC TD KD QD AD");
            Assert.Equal(1, player1.Compare(player2));
            Assert.Equal(-1, player2.Compare(player1));
        }

        [Fact]
        public void CompareWithSameRank()
        {
            PlayerHand player1 = new PlayerHand("TS TD KS KD QS");
            PlayerHand player2 = new PlayerHand("TH TC KC QH QD");
            Assert.Equal(1, player1.Compare(player2));
            Assert.Equal(-1, player2.Compare(player1));

            player1 = new PlayerHand("TS TD KS KD AS");
            player2 = new PlayerHand("TH TC KC KH QD");
            Assert.Equal(1, player1.Compare(player2));
            Assert.Equal(-1, player2.Compare(player1));
        }

        [Fact]
        public void Draw()
        {
            PlayerHand player1 = new PlayerHand("TS JS KS QS AS");
            PlayerHand player2 = new PlayerHand("KD QD TD AD JD");
            Assert.Equal(0, player1.Compare(player2));
            Assert.Equal(0, player2.Compare(player1));
        }
    }
    
}
