
namespace Ifx.Services.hogwartsAccess.Application.Admissions.Commands.Update
{
    using System;
    using FluentValidation;
    using Ifx.Services.hogwartsAccess.Domain.Enums;

    public class UpdateAdmissionValidator : AbstractValidator<UpdateAdmissionCommand>
    {
        public UpdateAdmissionValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Status).Must(BeAValidStatus).WithMessage("Please specify a valid status.");
        }

        private bool BeAValidStatus(StatusAdmission statusAdmission)
        {
            return Enum.IsDefined(typeof(StatusAdmission), statusAdmission);
        }
    }
}
