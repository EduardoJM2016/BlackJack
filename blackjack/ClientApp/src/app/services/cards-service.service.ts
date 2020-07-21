import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Deck } from '../classes/Deck';
import { Card } from '../classes/Card';

const baseUrl = 'https://localhost:5001/api/';

@Injectable({
  providedIn: 'root'
})
export class CardsServiceService {

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Deck>(`${baseUrl}deck`);
  }

  getCards(deck_id: String) {
    return this.http.get<any>(`${baseUrl}deck/${deck_id}/draw/?count=2`);
  }

  getCard(deck_id: String) {
    return this.http.get<any>(`${baseUrl}deck/${deck_id}/draw/?count=1`);
  }

}
