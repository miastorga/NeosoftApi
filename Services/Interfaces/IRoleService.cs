using NeosoftApi.DTOs;
using NeosoftApi.Models;

namespace NeosoftApi.Services.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<RoleDto>> GetAllAsync();
    Task<Role> GetByIdAsync(int id);
    Task<Role> CreateAsync(CreateRolDto role);
    Task<Role> UpdateAsync(int id, CreateRolDto role);
    Task DeleteAsync(int id);
}