using System;
using System.Collections.Generic;
using System.Linq;
using RouletteAPI.Models;

namespace RouletteAPI.Repositories{
    public interface IInMemBetsRepository
    {
        Bets GetBet(Guid id);
        IEnumerable<Bets> GetBets();
    }

    public class InMemBetsRepository : IInMemBetsRepository
    {
        private readonly List<Bets> bets = new(){
            new Bets {Id = Guid.NewGuid(), BetType = "Black", BetAmount = 10, CreatedDate = DateTimeOffset.UtcNow},
            new Bets {Id = Guid.NewGuid(), BetType = "Red", BetAmount = 20, CreatedDate = DateTimeOffset.UtcNow}
        };

        public IEnumerable<Bets> GetBets()
        {
            return bets;
        }

        public Bets GetBet(Guid id)
        {
            return bets.Where(Bet => Bet.Id == id).SingleOrDefault();
        }
    }
}