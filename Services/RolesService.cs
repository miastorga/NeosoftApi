using Microsoft.EntityFrameworkCore;
using NeosoftApi.Data;
using NeosoftApi.DTOs;
using NeosoftApi.Models;
using NeosoftApi.Services.Interfaces;

namespace NeosoftApi.Services;

public class RolesService : IRoleService
{

    private readonly ApplicationDbContext _db;

    public RolesService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<RoleDto>> GetAllAsync()
    {
        var roles = await _db.Roles
            .Select(r => new RoleDto
            {
                Id = r.Id,
                Nombre = r.Nombre
            })
            .ToListAsync();
        return roles;
    }

    public async Task<Role> GetByIdAsync(int id)
    {
        var role = await _db.Roles
            .FirstOrDefaultAsync(r => r.Id == id);
        if (role is null)
        {
            throw new KeyNotFoundException($"No se encontro el role con el id {id}.");
        }
        return role;
    }

    public async Task<Role> CreateAsync(CreateRolDto role)
    {
        var createRole = new Role
        {
            Nombre = role.Nombre
        };
        await _db.Roles.AddAsync(createRole);
        await _db.SaveChangesAsync();
        return createRole;
    }

    public async Task<Role> UpdateAsync(int id, CreateRolDto role)
    {
        var roleById = await GetByIdAsync(id);
        _db.Entry(roleById).CurrentValues.SetValues(role);
        await _db.SaveChangesAsync(); 
        return roleById;
    }

    public async Task DeleteAsync(int id)
    {
        var roleById = await GetByIdAsync(id);
        _db.Roles.Remove(roleById);
        await _db.SaveChangesAsync();
    }
}