using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using blackjack.Models;
using Microsoft.EntityFrameworkCore;

namespace  blackjack.Controllers
{
     public class UserController : Controller
    {
        public readonly DataBaseContext _context;


        public UserController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("api/user")]
        public async Task<ActionResult<User>> PostVehicle([FromBody]User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

    }
    
}