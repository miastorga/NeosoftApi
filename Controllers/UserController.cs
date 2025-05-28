using Microsoft.AspNetCore.Mvc;
using NeosoftApi.DTOs;
using NeosoftApi.Services.Interfaces;

namespace NeosoftApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController:ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
    {
        try
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserById([FromRoute] int id)
    {
        try
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(new UserDto
            {
                Id = user.Id,
                Nombre = user.Nombre,
                Email = user.Email,
                RolId = user.RoleId
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
    public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto variable)
    {
        try
        {
            var createRole = await _userService.CreateAsync(variable);
            return Ok(new UserDto
            {
                Id = createRole.Id,
                Nombre = createRole.Nombre,
                Email = createRole.Email,
                RolId = createRole.RoleId
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] int id)
    {
        try
        {
            await _userService.DeleteAsync(id);
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
    public async Task<ActionResult<RoleDto>> UpdateUser([FromRoute] int id, [FromBody] CreateUserDto role)
    {
        try
        {
            var updateRole = await _userService.UpdateAsync(id, role);
            return Ok(updateRole);
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
}