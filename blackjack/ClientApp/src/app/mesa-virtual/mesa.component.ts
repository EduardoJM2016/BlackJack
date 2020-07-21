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

    getCards() {

        this.cardsServiceService.getCards(this.deck.deck_id).subscribe(
            response => {
                this.cards = response;
                console.log(this.cards);
            } 
        )
    }
}
