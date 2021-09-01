namespace Ifx.Services.hogwartsAccess.Application.Admissions.Commands.Create
{
    using System;
    using FluentValidation;
    using Ifx.Services.hogwartsAccess.Domain.Enums;

    public class CreateAdmissionValidator : AbstractValidator<CreateAdmissionCommand>
    {
        public CreateAdmissionValidator()
        {
            RuleFor(x => x.Identification).NotEmpty().MaximumLength(13);
            RuleFor(x => x.Age).NotEmpty().MaximumLength(3);
            RuleFor(x => x.HouseRequest).NotEmpty().Must(BeAValidHouseRequest).WithMessage("Please specify a valid hogwarts house.");
        }

        private bool BeAValidHouseRequest(HogwartsHouses hogwartsHouses)
        {
            return Enum.IsDefined(typeof(HogwartsHouses), hogwartsHouses);
        }

    }
}
