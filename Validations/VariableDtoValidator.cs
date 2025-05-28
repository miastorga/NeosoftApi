using FluentValidation;
using NeosoftApi.DTOs;

namespace NeosoftApi.Validations;

public class VariableDtoValidator:AbstractValidator<CreateVariablesDto>
{
    private readonly string[] _allowedTipos = { "texto", "numerico", "booleano" };

    public VariableDtoValidator()
    {
        RuleFor(variable => variable.Nombre)
            .NotEmpty().WithMessage("El nombre de la variable es obligatorio.")
            .MaximumLength(100).WithMessage("El nombre de la variable no puede exceder los 100 caracteres.");

        RuleFor(variable => variable.Valor)
            .NotEmpty().WithMessage("El valor de la variable es obligatorio.")
            .MaximumLength(100).WithMessage("El valor de la variable no puede exceder los 100 caracteres.");

        RuleFor(variable => variable.Tipo)
            .NotEmpty().WithMessage("El tipo de la variable es obligatorio.")
            .Must(tipo => _allowedTipos.Contains(tipo.ToLowerInvariant()))
            .WithMessage($"El tipo de la variable debe ser uno de los siguientes: {string.Join(", ", _allowedTipos)}.");
    }
}