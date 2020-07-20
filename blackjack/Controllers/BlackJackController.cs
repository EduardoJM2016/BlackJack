using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using blackjack.Models;
using blackjack;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace blackjack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlackJackController : ControllerBase
    {
        private readonly DataBaseContext _context;
        public BlackJackController(DataBaseContext context)
        {
            _context = context;
        }

        //Método GET de el Eduardo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayingCard>>> GetCards()
        {
            return await _context.PlayingCards.ToListAsync();
        }

        //Método POST de el Eduardo
        /*[HttpPost]
        public async Task<ActionResult<PlayingCard>> generateCardDeck()
        {
            await this._context.SaveChangesAsync();
        }*/
    }
}