using blackjack.Models;
using System.Collections.Generic;
using System.Collections;

namespace blackjack.Services{

    public class BlackJackService
    {
        public List<PlayingCard> CardsDeck;
        public List<Player> Players;
        private int CardsIdIndex = 0;
        private int PlayerHighestPoints = 0;

        public BlackJackService()
        {

        }

        private void generateCardDeck()
        {
            this.CardsDeck = new List<PlayingCard>();
            this.CardsIdIndex = 0;

            this.CardsDeck.AddRange(generateSuitCards("club"));
            this.CardsDeck.AddRange(generateSuitCards("spade"));
            this.CardsDeck.AddRange(generateSuitCards("heart"));
            this.CardsDeck.AddRange(generateSuitCards("diamond"));
        }

        private List<PlayingCard> generateSuitCards(string suit)
        {
            List<PlayingCard> suitCards = new List<PlayingCard>();

            for (int i = 2; i < 15; i++)
            {
                this.CardsIdIndex++;

                suitCards.Add(new PlayingCard() {Id = this.CardsIdIndex});
                suitCards.Add(new PlayingCard() {Suit = suit});
                suitCards.Add(new PlayingCard() {ClassicValue = i});
                suitCards.Add(new PlayingCard() {BlackJackValue = i < 12 ? i : 10});
                suitCards.Add(new PlayingCard() {IsAce = i == 11 ? true : false});
            }

            return suitCards;
        }

        public void startGame(List<Player> players)
        {
            this.Players = players;
        }

        public List<Player> GetPlayers()
        {
            return this.Players;
        }

    }
}