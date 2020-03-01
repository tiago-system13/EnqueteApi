using FluentValidation;

namespace EnqueteApi.Models.Dto.Validators
{

    public class OptionValidator: AbstractValidator<OptionDto>
    {
        public OptionValidator()
        {
            RuleFor(e => e.OptionDescription)
                 .NotEmpty().WithMessage("O preenchimento da descrição é obrigatório");

            RuleFor(e => e.OptionDescription.Length)
                .LessThanOrEqualTo(40).WithMessage("O campo descrição somente suporta 40 caractes");
        }


    }
}
