using System;
using FluentValidation;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(updateNoteCommand => updateNoteCommand.UserId).NotEqual(Guid.Empty);

            RuleFor(updateNoteCommand => updateNoteCommand.Id).NotEqual(Guid.Empty);

            RuleFor(updateNoteCommand => updateNoteCommand.Title).NotEmpty().MaximumLength(250);
        }
    }
}
