using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class VeiculoValidation : AbstractValidator<Veiculo>
    {
        public VeiculoValidation()
        {
            RuleFor(c => c.Placa)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(6, 10).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Modelo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            RuleFor(c => c.Ano)
               .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");        }
    }
}