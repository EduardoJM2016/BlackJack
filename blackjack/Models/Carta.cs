namespace blackjack.Models{
    public class Carta
    {
        public long Id {get; set;}
        public CartaTipo Tipo {get; set;}
        public CartaRango Rango {get; set;}

        public Carta(CartaTipo tipo)
        {
            Tipo = tipo;
        }

        public Carta(CartaTipo tipo, CartaRango rango)
        {
            Tipo = tipo;
            Rango = rango;
        }
    }
}