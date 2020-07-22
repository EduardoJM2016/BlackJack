import { Component, OnInit } from "@angular/core";
import { CardsServiceService } from "../services/cards-service.service";
import { Deck } from "../classes/Deck";
import { Card } from "../classes/Card";
import { Router } from "@angular/router";


@Component({
  selector: "mesa-app",
  templateUrl: "./mesa.component.html",
  styleUrls: ["./mesa.component.css"],
})
export class MesaComponent implements OnInit {
  deck: Deck;
  cards: Card[];
  playerCards: Card[] = [];
  dealerCards: Card[] = [];
  playerPoints: Number = 0;
  playing: Boolean;
  private limit = 21;

  constructor(private cardsServiceService: CardsServiceService, 
    private router: Router
    ) {}

  ngOnInit() {
    let deck_id;
    this.cardsServiceService.getAll().subscribe((response) => {
      this.deck = response;
      deck_id = response.deck_id;
    });
  }

  getInitialsCards() {
    this.playing = true;
    this.cardsServiceService
      .getCards(this.deck.deck_id)
      .subscribe((response) => {
        this.playerCards.push(response.cards[0]);
        this.playerCards.push(response.cards[1]);
        this.dealerCards.push(response.cards[2]);
        this.dealerCards.push(response.cards[3]);
      });
  }

  getWinner() {
    let playerPoints = 0;

    this.playerCards.forEach((element) => {
      playerPoints += Number(element.value);
    });
    console.log(playerPoints);
    if (playerPoints === this.limit) {
      console.log('Winner player');
    } else if (playerPoints > this.limit) {
      console.log('Player lose');
    } else {
      let dealerPoints = 0;
      this.dealerCards.forEach((element) => {
        dealerPoints += Number(element.value);
      });
      if (dealerPoints === this.playerPoints) {
        console.log('Draw');
      } else if (dealerPoints > playerPoints) {
        console.log('Dealer wins');
      } else {
        console.log('Player wins');
      }
    }

    this.router.navigate(['/']);
  }

  getCard() {
    this.cardsServiceService
      .getCard(this.deck.deck_id)
      .subscribe((response) => {
        this.playerCards.push(response.cards[0]);
        console.log(this.cards);
      });
  }

  // PointsCardPlayer() {
  //     this.playerPoints = this.playerCards.reduce((sum, card) => sum + parseInt(card.value), 0);

  // }
}
