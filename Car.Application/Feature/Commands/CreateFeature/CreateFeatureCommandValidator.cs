using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Feature.Commands.CreateFeature
{
    public class CreateFeatureCommandValidator : AbstractValidator<CreateFeatureCommand>
    {
        public CreateFeatureCommandValidator()
        {
            RuleFor(f => f.Description).NotEmpty().WithMessage("Podaj opis");
            RuleFor(f => f.CarEncodedName).NotEmpty().NotNull();
        }
    }
}
