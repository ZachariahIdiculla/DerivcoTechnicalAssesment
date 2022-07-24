using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
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

            var connectionStringBuilder = new SqliteConnectionStringBuilder();

            //Use DB in project directory.  If it does not exist, create it:
            connectionStringBuilder.DataSource = "C:\\Users\\zacha\\source\\repos\\ZachariahIdiculla\\DerivcoTechnicalAssesment\\DerivcoTechnicalAssesment\\RouletteAPI\\RouletteDB.db";

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                //Seed some data:
                using (var transaction = connection.BeginTransaction())
                {
                    var insertCmd = connection.CreateCommand();

                    insertCmd.CommandText = "INSERT into Bets VALUES (\"" + bet.Id + "\",\"" + bet.BetType + "\"," + bet.BetAmount.ToString() + ")";
                    insertCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }

            return CreatedAtAction(nameof(GetBet), new {id = bet.Id}, bet.AsDto());
        }

        [HttpPut("{id}")]

        public ActionResult UpdateBet(Guid id, UpdateBetDto betDto){
            var existingBet = repository.GetBet(id);

            if (existingBet is null)
            {
                return NotFound();
            }

            Bet updateBet = existingBet with {
                BetAmount = betDto.BetAmount,
                BetType = betDto.BetType
            };

            repository.UpdateBet(updateBet);

            return NoContent();
        }

    }
}