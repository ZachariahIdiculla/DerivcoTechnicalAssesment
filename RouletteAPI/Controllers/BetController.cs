using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RouletteAPI.Dtos;
using RouletteAPI.Models;
using RouletteAPI.Repositories;

namespace RouletteAPI.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class BetsController : ControllerBase{

        private readonly IBetsRepository repository;

        public BetsController(IBetsRepository repository){
            this.repository = repository;
        }

        [HttpGet]
        
        public IEnumerable<BetDto> GetBets(){
            var bets = repository.GetBets().Select(bet => bet.AsDto());
            return bets;
        }

        [HttpGet("{id}")]
        public ActionResult<BetDto> GetBet(Guid id){
            var bet = repository.GetBet(id);

            if (bet is null){
                return NotFound();
            }

            return bet.AsDto();
        }

        [HttpPost]
        public ActionResult<BetDto> CreateBet(CreateBetDto betDto){
            Bet bet = new(){
                Id = Guid.NewGuid(),
                BetAmount = betDto.BetAmount,
                BetType = betDto.BetType,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateBet(bet);

            return CreatedAtAction(nameof(GetBet), new {id = bet.Id}, bet.AsDto());
        }

    }
}