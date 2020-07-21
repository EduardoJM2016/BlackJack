import { Component, OnInit } from '@angular/core';
import { CardsServiceService } from '../services/cards-service.service';
import { Deck } from '../classes/Deck';
import { Card } from '../classes/Card';

@Component({
    selector: 'mesa-app',
    templateUrl: './mesa.component.html',
    styleUrls: ['./mesa.component.css']
})

export class MesaComponent implements OnInit {
    deck: Deck;
    cards: Card[];
    playerCards: Card[] = [];
    dealerCards: Card[] = [];
    playerPoints: Number = 0;
    playing: Boolean;

    constructor(private cardsServiceService: CardsServiceService) { }

    ngOnInit() {
        let deck_id;
        this.cardsServiceService.getAll().subscribe(
            response => {
                this.deck = response;
                console.log(this.deck);
                deck_id = response.deck_id;
            } 
        )
    }

    getInitialsCards() {
        this.playing = true;
        this.cardsServiceService.getCards(this.deck.deck_id).subscribe(
            response => {
                this.playerCards.push(response.cards[0]);
                this.dealerCards.push(response.cards[1]);
                console.log(response);
            } 
        )
    }

    getCard() {
        this.cardsServiceService.getCard(this.deck.deck_id).subscribe(
            response => {
                this.playerCards.push(response.cards[0]);
                console.log(this.cards);
            } 
        )
    }

    // PointsCardPlayer() {
    //     this.playerPoints = this.playerCards.reduce((sum, card) => sum + parseInt(card.value), 0);

    // }
}
