using blackjack.Models;
using System.Collections.Generic;

namespace blackjack.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BankRoll { get; set; }
        public int AmountWon { get; set; }
        public bool IsDealer {get;set;}
        public List<PlayingCard> Cards {get;}
        public int Points {get;set;}
        public bool Standing {get;set;}

        public bool GameModeOn {get; set;}

        public int CurrentBetValue {get;set;}
        public bool Bust {get; set;}
        public bool BlackJack {get;set;}
        public bool NaturalBlackJack {get;set;}
        public bool WinnerOfRound {get;set;}
    }

}