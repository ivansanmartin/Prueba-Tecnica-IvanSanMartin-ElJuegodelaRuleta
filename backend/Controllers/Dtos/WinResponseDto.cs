using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers.Dtos
{
    public class WinResponseDto
    {
        public int AmountWon { get; set; } 
        public string Message { get; set; } = string.Empty;
    }
}