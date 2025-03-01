using ASbackend.Domain.Entities;
using FluentValidation;

namespace ASbackend.Validators
{
    public class RegisterValidator : AbstractValidator<User>
    {
        public RegisterValidator() 
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email não pode ser vazio")
                .EmailAddress().WithMessage("Email inválido");
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Senha não pode ser vazia");
            RuleFor(u => u.fullname)
                .Length(3, 100)
                .WithMessage("Nome deve ter entre 3 e 100 caracteres");
            RuleFor(u => u.cpf)
                .Length(11)
                .WithMessage("CPF deve ter 11 caracteres");
            RuleFor(u => u.age)
                .InclusiveBetween(0, 100)
                .WithMessage("Idade inválida");
            RuleFor(u => u.numberphone).Length(11)
                .WithMessage("Número de telefone inválido");
            RuleFor(u => u.adress)
                .Length(3, 150)
                .WithMessage("Endereço deve ter entre 3 e 100 caracteres");
            RuleFor(u => u.duedate).MinimumLength(4)
                .WithMessage("Data de vencimento inválida");
            RuleFor(u => u.injuryhistory).Length(3, 300)
                .WithMessage("Histórico de lesões deve ter entre 3 e 300 caracteres");
            RuleFor(u => u.numberemergency).Length(11)
                .WithMessage("Número de emergência inválido");
        }
    }
}
