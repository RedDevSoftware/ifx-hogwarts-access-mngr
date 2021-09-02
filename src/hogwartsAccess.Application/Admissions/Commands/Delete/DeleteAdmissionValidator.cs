namespace Ifx.Services.hogwartsAccess.Application.Admissions.Commands.Delete
{
    using FluentValidation;

    public class DeleteAdmissionValidator : AbstractValidator<DeleteAdmissionCommand>
    {
        public DeleteAdmissionValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
