using RouletteAPI.Dtos;
using RouletteAPI.Models;

namespace RouletteAPI{
    public static class Extensions{
        public static BetDto AsDto(this Bet bet){
            return new BetDto{
                Id = bet.Id,
                BetAmount = bet.BetAmount,
                BetType = bet.BetType,
                CreatedDate = bet.CreatedDate
            };
            
        }
    }
}