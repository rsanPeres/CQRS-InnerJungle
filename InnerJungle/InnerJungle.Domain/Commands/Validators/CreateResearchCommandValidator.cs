﻿using FluentValidation;
using InnerJungle.Domain.Entities.Validators;

namespace InnerJungle.Domain.Commands.Validators
{
    public class CreateResearchCommandValidator : AbstractValidator<CreateResearchCommand>
    {
        public CreateResearchCommandValidator()
        {
            RuleFor(x => x.Research).NotNull().SetValidator(new ResearchValidator());
        }
    }
}
