using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NeosoftApi.DTOs;
using NeosoftApi.Models;
using NeosoftApi.Services.Interfaces;

namespace NeosoftApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController:ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleDto>>> GetAllRoles()
    {
        try
        {
            var roles = await _roleService.GetAllAsync();
            return Ok(roles);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoleDto>> GetRoleById([FromRoute] int id)
    {
        try
        {
            var role = await _roleService.GetByIdAsync(id);
            return Ok(new RoleDto
            {
                Id = role.Id,
                Nombre = role.Nombre
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
    public async Task<ActionResult<RoleDto>> CreateRole([FromBody] CreateRolDto role)
    {
        var createRole = await _roleService.CreateAsync(role);
        return Ok(new RoleDto
        {
            Id = createRole.Id,
            Nombre = createRole.Nombre
        });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRole([FromRoute] int id)
    {
        try
        {
            await _roleService.DeleteAsync(id);
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
    public async Task<ActionResult<RoleDto>> UpdateRole([FromRoute] int id, [FromBody] CreateRolDto role)
    {
        try
        {
            var updateRole = await _roleService.UpdateAsync(id, role);
            return Ok(updateRole);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno al intentar actualizar la variable.");
        }
    }
}