using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers.Dtos
{
    public class LoseResponseDto
    {
        public bool isWinner { get; set; }
        public int AmountLost { get; set; } 
        public string Message { get; set; } = string.Empty;
    }
}