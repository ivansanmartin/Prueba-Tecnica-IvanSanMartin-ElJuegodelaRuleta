using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers.Dtos;
using backend.enums;

namespace backend.Interfaces
{
    public interface iWinningService
    {

        WinResponseDto calculateWinAmount(WinDto winDto);
        int calculateMountWinByBetType(BetType betType);
        
    }
}