using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers.Dtos;
using backend.enums;
using backend.Interfaces;

namespace backend.Services
{
    public class GameService : IGameService
    {
        
        public WinResponseDto CalculateWinAmount(WinDto winDto)
        {
            int amountWin = CalculateMountWinByBetType(winDto.BetType, winDto.BetAmount);
            string? message = amountWin > 0 ? $"Haz recibido ${amountWin} de ganancia, ¡felicidades!" : "No haz obtenido ganacias :("; 
            var newWinResponse = new WinResponseDto 
            {
                isWinner = winDto.Winning,
                AmountWon = amountWin,
                Message = message
            };

            return newWinResponse;
        }

        public LoseResponseDto CalculateLoseAmount(WinDto winDto)
        {
            var newLostResponse = new LoseResponseDto
                {
                    isWinner = winDto.Winning,
                    AmountLost = winDto.BetAmount,
                    Message = $"Haz perdido ${winDto.BetAmount}"
                };
                
            return newLostResponse;
        }

        public int CalculateMountWinByBetType(BetType betType, int betAmount)
        {
            int amountWin;
            switch (betType)
            {
                case BetType.Color:
                    amountWin = betAmount / 2;
                    break;
                case BetType.ColorAndNumber:
                    amountWin = betAmount * 3;
                    break;
                case BetType.ColorAndParity:
                    amountWin = betAmount;
                    break;
                default:
                    amountWin = 0;
                    break;
            }

            return amountWin;
        }

    }
}