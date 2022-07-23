using System.Collections.Generic;
using System;
using RouletteAPI.Models;

namespace RouletteAPI.Repositories{
        public interface IBetsRepository
    {
        Bet GetBet(Guid id);
        IEnumerable<Bet> GetBets();
        void CreateBet(Bet bet);
    }

}