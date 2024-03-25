using FluentValidation;

namespace BSI_Info_APIService_BLL.DTOs.Validation
{
     public class TasksCreateDTOValidator : AbstractValidator<TasksCreateDTO>
    {
        public TasksCreateDTOValidator()
        {
            RuleFor(x => x.event_id).NotEmpty().WithMessage("Nama Events harus diisi");
            RuleFor(x => x.description).NotEmpty().WithMessage("Description harus diisi");
            RuleFor(x => x.deadline).NotEmpty().WithMessage("Deadline harus diisi");
            RuleFor(x => x.status).NotEmpty().WithMessage("Status harus diisi");
        }
    }
}
