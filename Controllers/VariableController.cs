using Microsoft.AspNetCore.Mvc;
using NeosoftApi.DTOs;
using NeosoftApi.Services.Interfaces;

namespace NeosoftApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VariableController:ControllerBase
{
    private readonly IVariableService _variableService;

    public VariableController(IVariableService variableService)
    {
        _variableService = variableService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VariablesDto>>> GetAllVariables()
    {
        try
        {
            var variables = await _variableService.GetAllAsync();
            return Ok(variables);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<VariablesDto>> GetVariableById([FromRoute] int id)
    {
        try
        {
            var variable = await _variableService.GetByIdAsync(id);
      
            return Ok(new VariablesDto
            {
                Id = variable.Id,
                Nombre = variable.Nombre,
                Tipo = variable.Tipo,
                Valor = variable.Valor
            });

        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<VariablesDto>> CreateVariable([FromBody] CreateVariablesDto variable)
    {
        try
        {
            var createRole = await _variableService.CreateAsync(variable);
            return Ok(new VariablesDto
            {
                Id = createRole.Id,
                Nombre = createRole.Nombre,
                Tipo = createRole.Tipo,
                Valor = createRole.Valor
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteVariable([FromRoute] int id)
    {
        try
        {
            await _variableService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<RoleDto>> UpdateVariable([FromRoute] int id, [FromBody] CreateVariablesDto variable)
    {
        try
        {
            var updateRole = await _variableService.UpdateAsync(id, variable);
            return Ok(updateRole);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message); 
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno al intentar actualizar la variable.");
        }
  
    }
}