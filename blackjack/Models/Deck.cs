using System;
using System.ComponentModel.DataAnnotations;

namespace blackjack.Models
{
     public class Deck{
      
       
      
        [Key]
        public Guid deck_id { get; set; }
      
       public  bool success { get; set; }

        public int remaining { get; set; }

        public bool shuffled { get; set;}


       }

    
}