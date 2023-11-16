using EmployeeService.DTOs;
using EmployeeService.Queries;
using FluentValidation;

namespace EmployeeService.Validators
{
    public class EmployeeEditDtoValidator : AbstractValidator<EmployeeEditDto>
    {
        public EmployeeEditDtoValidator(IJobPostQueries jobPostQueries, IDepartmentQueries departmentQueries, IEmployeeQueries employeeQueries)
        {
            RuleFor(a => a.Id).Must(input => employeeQueries.IsExistsId(input)).WithMessage("Редактируемого сотрудника не существует");
            RuleFor(a => a.DateOfBirth).NotEmpty().Must(input => input < DateTime.Now).WithMessage("Дата рождения не может быть больше текущей даты");
            RuleFor(a => a).Must(input => input.DateOfBirth < input.DateOfEmployment).WithMessage("Дата начала работы не может не может быть раньше даты рождения");
            RuleFor(a => a.Surname).NotEmpty().NotNull().MaximumLength(40).WithMessage("Поле фамилия не может быть пустым");
            RuleFor(a => a.Surname).MaximumLength(40).WithMessage("Слишком длинная фамилия");
            RuleFor(a => a.Firstname).NotEmpty().NotNull().MaximumLength(40).WithMessage("Поле имя не может быть пустым");
            RuleFor(a => a.Surname).MaximumLength(40).WithMessage("Слишком длинное имя");
            RuleFor(a => a.Patronymic).Must(input => input == null || input.Length < 40).WithMessage("Слишком длинное отчество");
            RuleFor(a => a.JobPostId).Must(input => jobPostQueries.IsExistsId(input)).WithMessage("Выбранной должности не существует");
            RuleFor(a => a.DepartmentId).Must(input => departmentQueries.IsExistsId(input)).WithMessage("Выбранного отдела не существует");
            RuleFor(a => a.Tariff).Must(input => input > 0).WithMessage("Ставка не может быть меньше либо равна нулю");
        }
    }

    public class EmployeeCreateDtoValidator : AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateDtoValidator(IJobPostQueries jobPostQueries, IDepartmentQueries departmentQueries)
        {
            RuleFor(a => a.DateOfBirth).NotEmpty().Must(input => input < DateTime.Now).WithMessage("Дата рождения не может быть больше текущей даты");
            RuleFor(a => a).Must(input => input.DateOfBirth < input.DateOfEmployment).WithMessage("Дата начала работы не может не может быть раньше даты рождения");
            RuleFor(a => a.Surname).NotEmpty().NotNull().MaximumLength(40).WithMessage("Поле фамилия не может быть пустым");
            RuleFor(a => a.Surname).MaximumLength(40).WithMessage("Слишком длинная фамилия");
            RuleFor(a => a.Firstname).NotEmpty().NotNull().MaximumLength(40).WithMessage("Поле имя не может быть пустым");
            RuleFor(a => a.Surname).MaximumLength(40).WithMessage("Слишком длинное имя");
            RuleFor(a => a.Patronymic).Must(input => input != null ? input.Length < 40 : true).WithMessage("Слишком длинное отчество");
            RuleFor(a => a.JobPostId).Must(input => jobPostQueries.IsExistsId(input)).WithMessage("Выбранной должности не существует");
            RuleFor(a => a.DepartmentId).Must(input => departmentQueries.IsExistsId(input)).WithMessage("Выбранного отдела не существует");
            RuleFor(a => a.Tariff).Must(input => input > 0).WithMessage("Ставка не может быть меньше либо равна нулю");
        }
    }

    public class EmployeeGetDtoValidator : AbstractValidator<EmployeeGetDto>
    {
        public EmployeeGetDtoValidator(IEmployeeQueries employeeQueries)
        {
            RuleFor(a => a.Id).Must(input => employeeQueries.IsExistsId(input)).WithMessage("Редактируемого сотрудника не существует");
        }
    }

    public class EmployeeFilterDtoValidator : AbstractValidator<EmployeeFilterDto>
    {
        public EmployeeFilterDtoValidator(IJobPostQueries jobPostQueries)
        {
            RuleFor(a => a.JobPostId).Must(input => input == 0 || jobPostQueries.IsExistsId(input)).WithMessage("выбранной должности не существует");
            RuleFor(a => a.Page).Must(input => input >= 0).WithMessage("страница не может быть меньше ноля");
            RuleFor(a => a.CountLoading).Must(input => input > 0 && input <= 40).WithMessage("число загружаемых элементов вышло за допустимые пределы");
        }
    }
}
