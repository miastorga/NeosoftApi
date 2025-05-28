using FluentValidation;
using NeosoftApi.DTOs;

namespace NeosoftApi.Validations;

public class RolDtoValidator:AbstractValidator<CreateRolDto>
{
    public RolDtoValidator()
    {
        RuleFor(role => role.Nombre)
            .NotEmpty().WithMessage("El nombre del rol es obligatorio.") 
            .MaximumLength(50).WithMessage("El nombre del rol no puede exceder los 50 caracteres."); 
    }
}