using NeosoftApi.DTOs;
using NeosoftApi.Models;

namespace NeosoftApi.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task<User> CreateAsync(CreateUserDto user);
    Task<User> UpdateAsync(int id, CreateUserDto user);
    Task DeleteAsync(int id);
}