namespace blackjack.Models{

    public class PlayingCard
    {
        public int Id {get;set;}
        public string Suit {get;set;}
        public int ClassicValue;
        public int BlackJackValue;
        public bool IsAce;
    }
}