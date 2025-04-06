using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers.Dtos;
using backend.enums;

namespace backend.Interfaces
{
    public interface IGameService
    {

        WinResponseDto CalculateWinAmount(WinDto winDto);
        LoseResponseDto CalculateLoseAmount(WinDto win);
        int CalculateMountWinByBetType(BetType betType, int betAmount);
        
    }
}