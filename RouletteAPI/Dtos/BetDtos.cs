using System;

namespace RouletteAPI.Dtos{
    public record BetDto{
        public Guid Id{get; init;}

        public string BetType{get; init;}

        public decimal BetAmount{get; init;}

        public DateTimeOffset CreatedDate{get; init;}
    }
}