using System.Collections.Generic;
using blackjack.Models;

namespace blackjack.Models{
    public class Baraja : List<Carta>
    {
        public Baraja()
        {
            this.Add(new Carta(CartaTipo.Rombos, CartaRango.Ace));
        }
    }
}