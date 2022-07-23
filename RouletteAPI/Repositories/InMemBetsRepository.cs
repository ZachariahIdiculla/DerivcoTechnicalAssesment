using System;
using System.Collections.Generic;
using System.Linq;
using RouletteAPI.Models;

namespace RouletteAPI.Repositories{

    public class InMemBetsRepository : IBetsRepository
    {
        private readonly List<Bet> bets = new(){
            new Bet {Id = Guid.NewGuid(), BetType = "Black", BetAmount = 10, CreatedDate = DateTimeOffset.UtcNow},
            new Bet {Id = Guid.NewGuid(), BetType = "Red", BetAmount = 20, CreatedDate = DateTimeOffset.UtcNow}
        };

        public IEnumerable<Bet> GetBets()
        {
            return bets;
        }

        public Bet GetBet(Guid id)
        {
            return bets.Where(Bet => Bet.Id == id).SingleOrDefault();
        }
    }
}