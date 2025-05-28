using Microsoft.EntityFrameworkCore;
using NeosoftApi.Data;
using NeosoftApi.DTOs;
using NeosoftApi.Models;
using NeosoftApi.Services.Interfaces;

namespace NeosoftApi.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _db;

    public UserService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var variables = await _db.Usuarioos
            .Select(u => new UserDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Email = u.Email,
                RolId = u.RoleId,
            })
            .ToListAsync();
        return variables;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _db.Usuarioos
            .FirstOrDefaultAsync(u => u.Id == id);
        if (user is null)
        {
            throw new KeyNotFoundException($"No se encontro el role con el id {id}.");
        }
        return user;
    }

    public async Task<User> CreateAsync(CreateUserDto user)
    {
        var createUser = new User
        {
            Nombre = user.Nombre,
            Email = user.Email,
            RoleId = user.RolId
        };
        await _db.Usuarioos.AddAsync(createUser);
        await _db.SaveChangesAsync();
        return createUser;
    }

    public async Task<User> UpdateAsync(int id, CreateUserDto user)
    {
        var userById = await GetByIdAsync(id);
        if (userById == null)
        {
            throw new KeyNotFoundException($"No se encontró la variable con el id {id} para actualizar.");
        }

        _db.Entry(userById).CurrentValues.SetValues(user);
        await _db.SaveChangesAsync(); 
        return userById;
    }

    public async Task DeleteAsync(int id)
    {
        var userById = await GetByIdAsync(id);
        if (userById is null)
        {
            throw new KeyNotFoundException($"No se encontro el role con el id {id}.");
        }
        _db.Usuarioos.Remove(userById);
        await _db.SaveChangesAsync();
    }
}