using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers.Dtos;

namespace backend.Models
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public int Amount { get; set; }

        public static implicit operator User(UserDto v)
        {
            throw new NotImplementedException();
        }
    }
}