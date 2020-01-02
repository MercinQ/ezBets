using ezBet.WebAPI.Model;
using ezBet.WebAPI.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ezBet.WebAPI.Repository
{
    public class BetRepository : IBetRepository
    {
        private readonly EzBetDbContext _ezBetDbContext;

        public BetRepository(EzBetDbContext ezBetDbContext)
        {
            _ezBetDbContext = ezBetDbContext;
        }

        public IEnumerable<Bet> GetAll()
        {
            return _ezBetDbContext.Bets.ToList();
        }

        public Bet GetById(int Id)
        {
            return _ezBetDbContext.Bets.Find(Id);
        }

        public void Create(Bet entity)
        {
            var dbBet = new Bet();
            dbBet.Name = entity.Name;
            dbBet.Score = entity.Score;
            dbBet.Type = entity.Type;
            dbBet.GameId = entity.GameId;
        }

        public void Update(Bet entity)
        {
            var dbBet = _ezBetDbContext.Bets.Find(entity.Id);
            if (dbBet == null)
                dbBet = new Bet();
            dbBet.Name = entity.Name;
            dbBet.Score = entity.Score;
            dbBet.Type = entity.Type;
            dbBet.GameId = entity.GameId;
        }

        public void Delete(int Id)
        {
            var bet = _ezBetDbContext.Bets.Find(Id);
            _ezBetDbContext.Bets.Remove(bet);
        }
    }
    public interface IBetRepository : IGenericRepository<Bet>
    {
    }
}
