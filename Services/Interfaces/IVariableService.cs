using NeosoftApi.DTOs;
using NeosoftApi.Models;

namespace NeosoftApi.Services.Interfaces;

public interface IVariableService
{
    Task<IEnumerable<VariablesDto>> GetAllAsync();
    Task<Variable> GetByIdAsync(int id);
    Task<Variable> CreateAsync(CreateVariablesDto variable);
    Task<Variable> UpdateAsync(int id, CreateVariablesDto variable);
    Task DeleteAsync(int id);
}