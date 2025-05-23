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

        public ApiResponse<UserDto> GetByUsername(string username)
        {
            try
            {
                User? user = _context.User.FirstOrDefault(user => user.Username == username);

                if (user != null) {
                    return new ApiResponse<UserDto>
                    {
                        Ok = true,
                        Message = "Usuario encontrado",
                        Data = new UserDto
                        {
                            Username = user.Username,
                            Amount = user.Amount
                        }
                    };

                }

                return new ApiResponse<UserDto>
                {
                    Ok = false,
                    Message = "Usuario no encontrado",
                };
            }
            catch (Exception ex)
            {
                
                return new ApiResponse<UserDto>
                {
                    Ok = false,
                    Message = $"Error al encontrar el usuario: {ex.Message}"
                };
            }

        }

        public async Task<ApiResponse<UserDto>> CreateUser(UserDto userDto)
        {
            try
            {
                User? user = _context.User.FirstOrDefault(user => user.Username == userDto.Username);

                if (user != null) {
                    return new ApiResponse<UserDto>
                    {
                        Ok = false,
                        Message = "El usuario ya existe",
                    };
                }

                var newUser = new User 
                {
                    Username = userDto.Username,
                    Amount = userDto.Amount
                };

                _context.User.Add(newUser);
                await _context.SaveChangesAsync();

                return new ApiResponse<UserDto>
                {
                    Ok = true,
                    Message = "Usuario creado correctamente",
                    Data = userDto
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<UserDto>
                {
                    Ok = false,
                    Message = $"Error al crear usuario: {ex.Message}"
                };
            }

        }
        
        public async Task<ApiResponse<UserDto>> UpdateUser(UserDto userDto)
        {
            try
            {
                var existngUser = _context.User.FirstOrDefault(user => user.Username == userDto.Username);

                if (existngUser != null)
                {
                    existngUser.Amount += userDto.Amount;

                    await _context.SaveChangesAsync();

                    return new ApiResponse<UserDto>
                    {
                        Ok = true,
                        Message = "Usuario actualizado correctamente",
                        Data = new UserDto
                        {
                            Username = existngUser.Username,
                            Amount = existngUser.Amount
                        }
                    };
                }

                return new ApiResponse<UserDto>
                {
                    Ok = false,
                    Message = "No se ha encontrado al usuario"
                };
            }
            catch (Exception ex)
            {
                
                return new ApiResponse<UserDto>
                {
                    Ok = false,
                    Message = $"Error al actualizar el usuario: {ex.Message}"
                };
            }

        }

    }
}