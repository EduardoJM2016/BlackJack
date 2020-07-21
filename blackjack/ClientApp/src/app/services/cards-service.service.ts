import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Deck } from '../classes/Deck';
import { Card } from '../classes/Card';

const baseUrl = 'http://localhost:5000/api/';

// https://deckofcardsapi.com/api/deck/<<deck_id>>/draw/?count=2

@Injectable({
  providedIn: 'root'
})
export class CardsServiceService {

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Deck>(`${baseUrl}deck`);
  }

  getCards(deck_id: String) {
    return this.http.get<Card[]>(`${baseUrl}deck/${deck_id}/draw/?count=52`);
  }

}
