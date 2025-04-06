using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using backend.enums;

namespace backend.Controllers.Dtos
{
    public class WinDto
    {
        
        [Required]
        public BetType BetType { get; set; }

        [Required]
        public int BetAmount { get; set; }

        [Required]
        public bool Winning { get; set; }
        
    }
}