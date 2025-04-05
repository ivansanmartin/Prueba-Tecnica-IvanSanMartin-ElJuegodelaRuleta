using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers.Dtos;
using backend.Data;
using backend.Models;

namespace backend.Services
{
    public class UserService : IUserService
    {

        private readonly ApplicationDBContext _context;

        public UserService(ApplicationDBContext context) {
            _context = context;
        }

        public User? GetByUsername(string username)
        {
            return _context.User.FirstOrDefault(user => user.Username == username);
        }

        public async Task<UserDto> CreateUser(UserDto userDto)
        {
            var user = new User {
                Username = userDto.Username,
                Amount = userDto.Amount
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return userDto;
        }

    }
}