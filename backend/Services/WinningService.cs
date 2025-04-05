using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers.Dtos;
using backend.enums;
using backend.Interfaces;

namespace backend.Services
{
    public class WinningService : iWinningService
    {
        
        public WinResponseDto calculateWinAmount(WinDto winDto)
        {
            int amountWin = calculateMountWinByBetType(winDto.BetType);

            var newWinResponse = new WinResponseDto 
            {
                AmountWon = amountWin,
                Message = $"Haz recibido {amountWin} de ganancia, ¡felicidades!"
            };

            return newWinResponse;

        }

        public int calculateMountWinByBetType(BetType betType)
        {
            switch (betType)
            {
                case BetType.Color:
                    break;
                case BetType.ColorAndNumber:
                    break;
                
                case BetType.ColorAndParity:
                    break;
                
                default:
                    break;
            }

            return 1;
        }

    }
}