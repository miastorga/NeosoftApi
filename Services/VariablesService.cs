using Microsoft.EntityFrameworkCore;
using NeosoftApi.Data;
using NeosoftApi.DTOs;
using NeosoftApi.Models;
using NeosoftApi.Services.Interfaces;

namespace NeosoftApi.Services;

public class VariablesService : IVariableService
{
    private readonly ApplicationDbContext _db;

    public VariablesService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<VariablesDto>> GetAllAsync()
    {
        var variables = await _db.Variables
            .Select(v => new VariablesDto
            {
              Id = v.Id,
              Nombre = v.Nombre,
              Tipo = v.Tipo,
              Valor = v.Valor
            })
            .ToListAsync();
        return variables;
    }

    public async Task<Variable> GetByIdAsync(int id)
    {
        var variable = await _db.Variables
            .FirstOrDefaultAsync(v => v.Id == id);
        if (variable is null)
        {
            throw new KeyNotFoundException($"No se encontro el variable con el id {id}.");
        }

        return variable;
    }

    public async Task<Variable> CreateAsync(CreateVariablesDto variable)
    {
        var createVariable = new Variable
        {
            Nombre = variable.Nombre,
            Tipo = variable.Tipo,
            Valor = variable.Valor
        };
        await _db.Variables.AddAsync(createVariable);
        await _db.SaveChangesAsync();
        return createVariable;
    }

    public async Task<Variable> UpdateAsync(int id, CreateVariablesDto variable)
    {
        var variableById = await GetByIdAsync(id);
        _db.Entry(variableById).CurrentValues.SetValues(variable);
        await _db.SaveChangesAsync(); 
        return variableById;
    }

    public async Task DeleteAsync(int id)
    {
        var variableById = await GetByIdAsync(id);
        _db.Variables.Remove(variableById);
        await _db.SaveChangesAsync();
    }
}