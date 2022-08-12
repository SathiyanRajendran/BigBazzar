﻿using BigBazzar.Helper;
using BigBazzar.Models;
using BigBazzar.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBazzar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradersController : ControllerBase
    {
        private readonly ITraderRepo _repository;
        public TradersController(ITraderRepo repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Traders>>> GetTraders()
        {
            return await _repository.GetAllTraders();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Traders>> GetTrader(int id)
        {
            return await _repository.GetTraderbyId(id);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Traders>> PutTrader(int id,Traders T)
        {
            Traders c = T;
            var PasswordHash = EncodePassword.GetMd5Hash(c.Password);
            T.Password = PasswordHash;
            T.ConfirmPassword = PasswordHash;
            return await _repository.UpdateTraders(id,T);

        }
        [HttpPost]
        public async Task<ActionResult<Traders>> PostTrader(Traders T)
        {
            Traders c = T;
            var PasswordHash = EncodePassword.GetMd5Hash(c.Password);
            T.Password = PasswordHash;
            T.ConfirmPassword = PasswordHash;
            return await _repository.AddNewTraders(T);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<Traders>> TraderLogin(Traders T)
         {
            //Traders c = T;
            //var PasswordHash = EncodePassword.GetMd5Hash(c.Password);
            //T.Password = PasswordHash;
            //T.ConfirmPassword = PasswordHash;
            Traders c = T;
            var PasswordHash = EncodePassword.GetMd5Hash(c.Password);
            T.Password = PasswordHash;
            T.ConfirmPassword = PasswordHash;
            //return await _repository.TraderLogin(T);

            var traderlogin = await _repository.TraderLogin(T);
            if (traderlogin == null)
            {
                return BadRequest("Invalid Credentials");
            }
            return traderlogin;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrader(int id)
        {
            await _repository.DeleteTraders(id);

            return NoContent();
        }

    }
}
