using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using blackjack.Models;
using blackjack.Services;

namespace blackjack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly DataBaseContext _context;
        public BlackJackService service;

        public GameController(DataBaseContext context)
        {
            //_context = context;
            /*this.service.resetDealer();
            this.service.GetPlayers();*/
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayingCard>>> generateCardDeck()
        {
            service = new BlackJackService();
            return service.generateCardDeck();
        }

        // GET by ID action

        // POST action

        // PUT action

        // DELETE action
    }
}