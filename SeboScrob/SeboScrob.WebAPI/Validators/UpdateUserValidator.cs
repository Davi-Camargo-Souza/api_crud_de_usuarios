using FluentValidation;
using SeboScrob.WebAPI.DTOs.Requests.User;

namespace SeboScrob.WebAPI.UseCases.User.UpdateUser
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator()
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

            RuleFor(x => x.CPF).MinimumLength(11).MaximumLength(11).WithMessage("O CPF deve ter 11 caracteres.");

            RuleFor(x => x.CEP).MinimumLength(8).MaximumLength(9).WithMessage("O CEP deve conter no mínimo 8 algarismos.");

            RuleFor(x => x.CNPJ).MinimumLength(14).WithMessage("O CNPJ deve conter no mínimo 14 dígitos.");

            RuleFor(x => x.Telefone).MinimumLength(11).WithMessage("O telefone deve conter no mínimo 11 dígitos.");
        }
    }
}
