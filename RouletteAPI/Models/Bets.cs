using System;

namespace RouletteAPI.Models{
    public record Bets{
        public Guid Id{get; init;}

        public string BetType{get; init;}

        public decimal BetAmount{get; init;}

        public DateTimeOffset CreatedDate{get; init;}
    }
}