using System.ComponentModel.DataAnnotations;

namespace RouletteAPI.Dtos{
    public record CreateBetDto{

        [Required]
        public string BetType{get; init;}

        [Required]
        public decimal BetAmount{get; init;}

    }
}