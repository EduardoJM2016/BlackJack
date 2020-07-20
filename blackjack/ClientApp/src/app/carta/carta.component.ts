import { Component, Input } from '@angular/core';
import { Card } from '../classes/Card';

@Component({
    selector: 'carta',
    templateUrl: './carta.component.html',
    styleUrls: ['./carta.component.css']
})

export class CartaComponent{

    @Input() card: Card;

    placeholder: String = "assets/placeholder.png";
    
}