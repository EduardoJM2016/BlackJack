using blackjack.Models;
using System.Collections.Generic;

namespace blackjack.Models{
    public class Jugador
    {
        private List<Carta> mano = new List<Carta>();
        private int puntaje {get; set;}

        public bool pasado {get; set;}

        public Jugador()
        {
            pasado = false;
        }
    }
}