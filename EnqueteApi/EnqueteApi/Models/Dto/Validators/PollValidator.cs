using FluentValidation;

namespace EnqueteApi.Models.Dto.Validators
{
    public class PollValidator : AbstractValidator<PollDto>
    {
        public PollValidator()
        {
            RuleFor(e => e.PollDescription)
                 .NotEmpty().WithMessage("O preenchimento do campo pollDescription é obrigatório");

            RuleFor(e => e.PollDescription).Length(5,40).WithMessage("O campo pollDescription deve conter no mínimo 5 caracteres e no máximo 40 caractes");

            RuleFor(e => e.Options).NotEmpty().WithMessage("Preencha pelo menos uma opção de voto");

            RuleForEach(x => x.Options).NotEmpty()
                                      .Must((option) => !string.IsNullOrWhiteSpace(option.OptionDescription))
                                      .WithMessage(@"O preenchimento do campo OptionDescription é obrigatório")
                                      .Must((option) => !string.IsNullOrWhiteSpace(option.OptionDescription) && option.OptionDescription.Length < 40)
                                      .WithMessage(@"O preenchimento do campo OptionDescription deve conter no máximo 40 caracteres");

        }

    }
}
