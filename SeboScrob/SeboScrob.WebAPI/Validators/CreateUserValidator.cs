using FluentValidation;
using SeboScrob.WebAPI.DTOs.Requests.User;

namespace SeboScrob.WebAPI.UseCases.User.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Nome).MinimumLength(10).WithMessage("O nome deve ter no mínimo 10 letras.")
                .NotEmpty().WithMessage("O nome não pode estar vazio.");

            RuleFor(x => x.Senha).NotEmpty().WithMessage("A senha é obrigatória.")
                .Matches("[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
                .Matches("[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula.")
                .Matches("[0-9]").WithMessage("A senha deve conter pelo menos um número.")
                .Matches("[^a-zA-Z0-9]").WithMessage("A senha deve conter pelo menos um caractere especial.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("Email inválido.");
        }
    }
}
