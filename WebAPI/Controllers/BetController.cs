using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPI.Model;
using WebAPI.Model.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly EzBetDbContext _ezBetDbContext;

        public BetController(EzBetDbContext ezBetDbContext)
        {
            this._ezBetDbContext = ezBetDbContext;
        }

        // GET api/bet
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<Bet>> Get()
        {
            var bets = _ezBetDbContext.Bets.ToList();
            return bets;
        }

        // GET api/bet/5
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Bet> Get(int id)
        {
            var bet = _ezBetDbContext.Find<Bet>(id);
            if (bet == null)
            {
                return NotFound();
            }
            return bet;
        }

        // POST api/bet
        [HttpPost]
        public void Post([FromBody] Bet value)
        {
        }

        // PUT api/bet/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Bet value)
        {
        }

        // DELETE api/bet/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {

            var betToDelete = _ezBetDbContext.Find<Bet>(id);
            _ezBetDbContext.Remove(betToDelete);
        }
    }
}
