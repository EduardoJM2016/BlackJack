using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using blackjack.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace blackjack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartasController : ControllerBase
    {
        private readonly DataBaseContext _context;
        public CartasController(DataBaseContext context)
        {
            _context = context;
        }

        //Método GET de el Eduardo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carta>>> GetCartas()
        {
            return await _context.Cartas.ToListAsync();
        }

        //Método POST de el Eduardo
        [HttpPost]
        public async Task<ActionResult<Carta>> PostCarta(Carta carta)
        {
            this._context.Cartas.Add(carta);
            await this._context.SaveChangesAsync();

            return CreatedAtAction("", new { id=carta.Id }, carta);
        }
    }
}