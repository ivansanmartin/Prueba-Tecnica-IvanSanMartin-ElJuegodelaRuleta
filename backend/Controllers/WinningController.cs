using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers.Dtos;
using backend.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/winning")]
    [ApiController]
    public class WinningController : ControllerBase
    {
        private readonly IGameService _gameService;

        public WinningController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public IActionResult GetWinningResult([FromBody] WinDto winDto)
        {
            if (!winDto.Winning) {
                LoseResponseDto loseResponseDto = _gameService.CalculateLoseAmount(winDto);
                return Ok(new {
                    amount_lost = loseResponseDto.AmountLost,
                    message = loseResponseDto.Message
                });
            }

            WinResponseDto winResponseDto = _gameService.CalculateWinAmount(winDto);

            return Ok(new {
                amount_won = winResponseDto.AmountWon,
                message = winResponseDto.Message
            });
        }

        
    }
}