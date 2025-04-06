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
        ApiResponse<UserDto> GetByUsername(string username);
        Task<ApiResponse<UserDto>> CreateUser(UserDto userDto);
        Task<ApiResponse<UserDto>> UpdateUser(UserDto userDto);
    }
}