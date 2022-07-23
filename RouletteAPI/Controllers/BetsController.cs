using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RouletteAPI.Models;
using RouletteAPI.Repositories;

namespace RouletteAPI.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class BetsController : ControllerBase{

        private readonly InMemBetsRepository repository;

        public BetsController(){
            repository = new InMemBetsRepository();
        }

        [HttpGet]
        
        public IEnumerable<Bets> GetBets(){
            var bets = repository.GetBets();
            return bets;
        }

        [HttpGet("{id}")]
        public ActionResult<Bets> GetBet(Guid id){
            var bet = repository.GetBet(id);

            if (bet is null){
                return NotFound();
            }

            return bet;
        }

    }
}