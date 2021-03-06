using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using blackjack.Models;
using Microsoft.AspNetCore.Cors;

namespace blackjack.Controllers
{
    [EnableCors("MyPolicy")]
    public class DeckController : Controller
    {

        private readonly DataBaseContext _context;

        public DeckController(DataBaseContext context)
        {

            _context = context;
        }
        [HttpGet]
        [Route("api/deck")]
        public async Task<ActionResult<IEnumerable<Deck>>> GetCard([FromQuery] int deck_count)
        {
            Console.WriteLine(deck_count);
            var deck = new Deck();
            deck.deck_id = Guid.NewGuid();
            deck.success = true;
            deck.remaining = 52;
            _context.Decks.Add(deck);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDeck", new { id = deck.deck_id }, deck);
        }
        [HttpPut]
        [Route("api/deck/{id}/shuffle")]
        public async Task<ActionResult<IEnumerable<Deck>>> shuffled([FromBody] Deck deck)
        {
            var id = Guid.Parse((string)RouteData.Values["id"]);
            var result = _context.Decks.SingleOrDefault(b => b.deck_id == id);
            if (result != null)
            {
                result.shuffled = deck.shuffled;
                await _context.SaveChangesAsync();
            }
            else
            {
                return Json("No se pudieron revolver las cartas");
            }

            return CreatedAtAction("Cartas revueltas", new { id = result.deck_id }, result);
        }

    }
}
