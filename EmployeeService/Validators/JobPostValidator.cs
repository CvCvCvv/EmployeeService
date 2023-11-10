using EmployeeService.DTOs;
using EmployeeService.Queries;
using FluentValidation;

namespace EmployeeService.Validators
{
    public class JobPostCreateDtoValidator : AbstractValidator<JobPostCreateDto>
    {
        public JobPostCreateDtoValidator(IJobPostQueries jobPostQueries)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("пустое значение недопустимо");
            RuleFor(x => x.Name).MaximumLength(40).WithMessage("Слишком длинное название");
            RuleFor(x => x.Name).MinimumLength(1).WithMessage("Слишком короткое название");
            RuleFor(x => x.Name).Must(input => jobPostQueries.IsExistsByName(input)!).WithMessage("элемент с таким именем уже существует");
            RuleFor(x => x.SalaryIncrement).Must(input => input > 0).WithMessage("значение вышло за допустимые пределы");
        }
    }

    public class JobPostEditDtoValidator : AbstractValidator<JobPostEditDto>
    {
        public JobPostEditDtoValidator(IJobPostQueries jobPostQueries)
        {
            RuleFor(x => x.Id).Must(input => jobPostQueries.IsExistsId(input)).WithMessage("элемент не существует");
            RuleFor(x => x).Must(input => jobPostQueries.IsExistsByName(input.Id, input.Name)!).WithName("Name").WithMessage("элемент с таким именем уже существует");
            RuleFor(x => x.Name).NotEmpty().WithMessage("пустое значение недопустимо");
            RuleFor(x => x.Name).MaximumLength(40).WithMessage("Слишком длинное название");
            RuleFor(x => x.Name).MinimumLength(1).WithMessage("Слишком короткое название");
            RuleFor(x => x.SalaryIncrement).Must(input => input > 0).WithMessage("значение вышло за допустимые пределы");
        }
    }

    public class JobPostGetDtoValidator : AbstractValidator<JobPostGetDto>
    {
        public JobPostGetDtoValidator(IJobPostQueries jobPostQueries)
        {
            RuleFor(x => x.Id).Must(input => jobPostQueries.IsExistsId(input)).WithMessage("элемент не существует");
        }
    }
}
