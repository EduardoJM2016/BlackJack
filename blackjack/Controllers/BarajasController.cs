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
    public class BarajasController : ControllerBase
    {
        private readonly DataBaseContext _context;
        public BarajasController(DataBaseContext context)
        {
            _context = context;
        }

        //Método GET de el Eduardo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Baraja>>> GetBarajas()
        {
            return await _context.Barajas.ToListAsync();
        }

        //Método POST de el Eduardo -- Acá se debe crear una nueva baraja
        
    }
}