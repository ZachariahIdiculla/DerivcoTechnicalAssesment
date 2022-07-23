using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
        
        public IEnumerable<Bet> GetBets(){
            var bets = repository.GetBets();
            return bets;
        }

        [HttpGet("{id}")]
        public ActionResult<Bet> GetBet(Guid id){
            var bet = repository.GetBet(id);

            if (bet is null){
                return NotFound();
            }

            return bet;
        }

    }
}