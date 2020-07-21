using System.ComponentModel.DataAnnotations;
using System;

namespace blackjack.Models

{
    public class Card
    {
        public Card(){

        }
         public Guid Id { get; set;}
         public string image { get; set; }
         public string value { get; set;}
         public string suit { get; set;}

         public string code { get; set;}       
    }

    
    
}