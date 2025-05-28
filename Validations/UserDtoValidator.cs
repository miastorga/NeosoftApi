using FluentValidation;
using NeosoftApi.DTOs;

namespace NeosoftApi.Validations;

public class UserDtoValidator: AbstractValidator<CreateUserDto>
{

    public UserDtoValidator()
    {
        RuleFor(user => user.Nombre)
            .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
            .MaximumLength(100).WithMessage("El nombre de usuario no puede exceder los 100 caracteres.");

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
            .EmailAddress().WithMessage("El formato del correo electrónico no es válido.")
            .MaximumLength(200).WithMessage("El correo electrónico no puede exceder los 200 caracteres.");

        RuleFor(user => user.RolId)
            .NotEmpty().WithMessage("El id del rol es obligatorio.");
    }
}