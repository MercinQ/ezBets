using System.Collections.Generic;
using System.Linq;
using ezBet.WebAPI.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using ezBet.WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IBetRepository _betRepository;

        public BetController(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }

        // GET api/bet
        [HttpGet]
        public ActionResult<IEnumerable<Bet>> Get()
        {
            return _betRepository.GetAll().ToList();
        }

        // GET api/bet/5
        [HttpGet("{id}")]
        public ActionResult<Bet> Get(int id)
        {
            var bet = _betRepository.GetById(id);
            if (bet == null)
            {
                return NotFound();
            }
            return bet;
        }

        // POST api/bet
        [HttpPost]
        public void Post([FromBody] Bet bet)
        {
            if (bet.Id == 0)
                _betRepository.Create(bet);
            else
                _betRepository.Update(bet);
        }

        // DELETE api/bet/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _betRepository.Delete(id);
        }
    }
}
