using blackjack.Models;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace blackjack.Services
{

    public class BlackJackService
    {
        public List<PlayingCard> CardsDeck;
        public List<Player> Players;
        public Player dealer;
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

                suitCards.Add(new PlayingCard() { Id = this.CardsIdIndex });
                suitCards.Add(new PlayingCard() { Suit = suit });
                suitCards.Add(new PlayingCard() { ClassicValue = i });
                suitCards.Add(new PlayingCard() { BlackJackValue = i < 12 ? i : 10 });
                suitCards.Add(new PlayingCard() { IsAce = i == 11 ? true : false });
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

        public void dealHand(Player dealer)
        {
            this.generateCardDeck();
            this.PlayerHighestPoints = 0;

            this.dealer = dealer;
            this.dealer.Cards = new List<PlayingCard>();
            this.dealer.Bust = false;
            this.dealer.BlackJack = false;
            this.dealer.NaturalBlackJack = false;
            this.dealer.WinnerOfRound = false;

            foreach (var player in Players)
            {
                player.Cards = new List<PlayingCard>();
                player.Bust = false;
                player.BlackJack = false;
                player.NaturalBlackJack = false;
                player.WinnerOfRound = false;
                player.Points = 0;

                if (player.BankRoll > 0 || player.CurrentBetValue > 0)
                {
                    this.dealCard(player, false);
                    this.dealCard(player, false);
                }
            }

            this.dealCard(this.dealer, true);
        }

        public void dealCard(Player player, bool isForDealer)
        {
            player.Cards.Add(this.extractCardFromPack());
            this.computePoints(player, isForDealer);
        }

        public void playerStands(Player player)
        {
            player.Standing = true;
            this.dealerAutomaticPlay();
        }

        public void dealerAutomaticPlay()
        {
            bool dealerHasToPlay = false;

            foreach (var player in Players)
            {
                if (!player.Bust && player.Points > 22)
                {
                    if (player.Points > this.PlayerHighestPoints)
                    {
                        this.PlayerHighestPoints = player.Points;
                    }
                }

                if (!player.Bust && !player.Standing && !player.BlackJack && (player.BankRoll > 0 || player.CurrentBetValue > 0))
                {
                    dealerHasToPlay = false;
                    break;
                }
                dealerHasToPlay = true;
            }

            if (dealerHasToPlay)
            {
                this.dealCard(this.dealer, true);
                this.dealerAutomaticPlayAI();
                this.findWinners();
            }
        }

        private void dealerAutomaticPlayAI()
        {
            if (this.dealer.Bust || this.dealer.BlackJack)
            {
                return;
            }

            if (this.dealer.Points > this.PlayerHighestPoints)
            {
                this.dealer.WinnerOfRound = true;
            }
            else
            {
                this.dealCard(this.dealer, true);
                this.dealerAutomaticPlayAI();
            }
        }

        private void findWinners()
        {
            foreach (var player in Players)
            {
                if (player.BankRoll == 0 && player.CurrentBetValue == 0)
                {
                    continue;
                }

                if (player.Bust)
                {
                    continue;
                }
                else if (player.NaturalBlackJack && !this.dealer.NaturalBlackJack)
                {
                    player.WinnerOfRound = true;
                    player.AmountWon = (player.CurrentBetValue * 2) + (player.CurrentBetValue / 2);
                    player.BankRoll += player.AmountWon;
                }
                else if (player.BlackJack && this.dealer.BlackJack)
                {
                    player.BankRoll += player.CurrentBetValue;
                    player.AmountWon = player.CurrentBetValue;
                    player.WinnerOfRound = true;
                }
                else if (player.Points < this.PlayerHighestPoints)
                {
                    player.Bust = true;
                }
                else if (player.Points > this.dealer.Points)
                {
                    player.WinnerOfRound = true;
                    player.AmountWon = player.CurrentBetValue * 2;
                    player.BankRoll += player.AmountWon;

                }
                else if (this.dealer.Bust)
                {
                    player.WinnerOfRound = true;
                    player.AmountWon = player.CurrentBetValue * 2;
                    player.BankRoll += player.AmountWon;
                }
                else if (player.Points < this.dealer.Points)
                {
                    player.Bust = true;
                }
                else if (player.Points == this.dealer.Points)
                {
                    player.BankRoll += player.CurrentBetValue;
                    player.AmountWon = player.CurrentBetValue;
                    player.WinnerOfRound = true;
                }
                else if (player.Points == this.PlayerHighestPoints)
                {
                    player.WinnerOfRound = true;
                    player.AmountWon = player.CurrentBetValue * 2;
                    player.BankRoll += player.AmountWon;
                }
            }
        }

        private PlayingCard extractCardFromPack()
        {
            Random random = new Random();
            int randomCardIndex = random.Next(this.CardsDeck.Count + 1) + 0;
            var cardToreturn = this.CardsDeck[randomCardIndex];

            if (cardToreturn.Equals(""))
            {
                cardToreturn = this.extractCardFromPack();
            }

            this.CardsDeck.RemoveAt(randomCardIndex);
            return cardToreturn;
        }

        private void computePoints(Player player, bool isForDealer)
        {
            List<PlayingCard> tempAces = new List<PlayingCard>();
            player.Points = 0;

            foreach (var card in player.Cards)
            {
                if (card.IsAce)
                {
                    tempAces.Add(card);
                }
                else if (card.BlackJackValue.Equals(0))
                {
                    player.Points += card.BlackJackValue;
                }
                else
                {
                    player.Points += card.ClassicValue;
                }
            }

            if (tempAces.Count < 21 && player.Points < 21)
            {
                foreach (var aceCard in tempAces)
                {
                    player.Points += 11;
                    if (player.Points > 21)
                    {
                        player.Points -= 10;
                    }
                    if (player.Points > 21)
                    {
                        break;
                    }
                }
            }
            if (player.Points > 21)
            {
                player.Bust = true;
                if (!isForDealer)
                {
                    this.dealerAutomaticPlay();
                }
            }
            else if (player.Points == 21)
            {
                if (player.Cards.Count == 2)
                {
                    player.NaturalBlackJack = true;
                }
                player.BlackJack = true;
                if (!isForDealer)
                {
                    this.dealerAutomaticPlay();
                }
            }
        }
    }
}