using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class CorridaValidation : AbstractValidator<Corrida>
    {
        public CorridaValidation()
        {
            RuleFor(c => c.Descricao)
                //.NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.DataHoraSaida)
                      .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.DataHoraChegada)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.TipoViagem)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
                //.Length().WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres");

            //RuleFor(c => c.PrimeiroMotorista)
            //    .NotEmpty().WithMessage("A campo {PropertyName} precisa ser fornecida");

            //RuleFor(c => c.SegundoMotorista)
            //    .NotEmpty().WithMessage("A campo {PropertyName} precisa ser fornecida");



        }
    }
}