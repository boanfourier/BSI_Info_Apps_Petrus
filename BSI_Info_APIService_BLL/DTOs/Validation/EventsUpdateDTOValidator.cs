using FluentValidation;

namespace BSI_Info_APIService_BLL.DTOs.Validation
{
    public class EventsUpdateDTOValidator : AbstractValidator<EventsUpdateDTO>
    {
        public EventsUpdateDTOValidator()
        {
            RuleFor(x => x.event_name).NotEmpty().WithMessage("Events Name harus diisi");
            RuleFor(x => x.description).NotEmpty().WithMessage("Description harus diisi");
            RuleFor(x => x.start_date).NotEmpty().WithMessage("Start Date harus diisi");
            RuleFor(x => x.end_date).NotEmpty().WithMessage("End Data harus diisi");
            RuleFor(x => x.location_id).NotEmpty().WithMessage("Location harus diisi");
            RuleFor(x => x.organizer_id).NotEmpty().WithMessage("Organizer harus diisi");
        }
    }
}
