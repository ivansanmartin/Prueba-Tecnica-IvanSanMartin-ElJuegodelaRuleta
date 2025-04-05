using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RouletteController : ControllerBase
    {

        public readonly IRouletteService _rouletteService;

        public RouletteController(IRouletteService rouletteService) {
            _rouletteService = rouletteService;
        }

        [HttpGet("spin-roulette")]
        public IActionResult SpinRoulette()
        {
            var result = _rouletteService.SpinRoulette();
            
            return Ok(new {
                number = result.Number, 
                color = result.Color, 
                parity = result.Parity
                });
        } 

    }
}