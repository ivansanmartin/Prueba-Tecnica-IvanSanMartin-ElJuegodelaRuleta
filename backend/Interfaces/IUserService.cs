using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers.Dtos;
using backend.Models;

namespace backend.Services
{
    public interface IUserService
    {
        User? GetByUsername(string username);
        Task<UserDto> CreateUser(UserDto userDto);
    }
}