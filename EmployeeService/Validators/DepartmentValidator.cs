using EmployeeService.DTOs;
using EmployeeService.Queries;
using FluentValidation;

namespace EmployeeService.Validators
{
    public class DepartmentCreateDtoValidator : AbstractValidator<DepartmentCreateDto>
    {
        public DepartmentCreateDtoValidator(IDepartmentQueries departmentQueries)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("пустое значение недопустимо");
            RuleFor(x => x.Name).MaximumLength(40).WithMessage("Слишком длинное название");
            RuleFor(x => x.Name).MinimumLength(1).WithMessage("Слишком короткое название");
            RuleFor(x => x.Name).Must(input => !departmentQueries.IsExistsByName(input)).WithMessage("элемент с таким именем уже существует");
        }
    }

    public class DepartmentEditDtoValidator : AbstractValidator<DepartmentEditDto>
    {
        public DepartmentEditDtoValidator(IDepartmentQueries departmentQueries)
        {
            RuleFor(x => x.Id).Must(input => departmentQueries.IsExistsId(input)).WithMessage("элемента не существует");
            RuleFor(x => x).Must(input => !departmentQueries.IsExistsByName(input.Id, input.Name)).WithName("Name").WithMessage("элемент с таким именем уже существует");
            RuleFor(x => x.Name).NotEmpty().WithMessage("пустое значение недопустимо");
            RuleFor(x => x.Name).MaximumLength(40).WithMessage("Слишком длинное название");
            RuleFor(x => x.Name).MinimumLength(1).WithMessage("Слишком короткое название");
        }
    }

    public class DepartmentGetDtoValidator : AbstractValidator<DepartmentGetDto>
    {
        public DepartmentGetDtoValidator(IDepartmentQueries departmentQueries)
        {
            RuleFor(x => x.Id).Must(input => departmentQueries.IsExistsId(input)).WithMessage("элемента не существует");
        }
    }
}
