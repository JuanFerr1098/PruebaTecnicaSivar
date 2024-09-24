using FluentValidation;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Command;

namespace PruebaTecnicaSivar.ApplicationDomain.Dto.Validator
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Nombre} no puede exceder los 50 caracteres");
            ;
            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("{LastName} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{LastName} no puede exceder los 50 caracteres");
            ;
        }
    }
}
