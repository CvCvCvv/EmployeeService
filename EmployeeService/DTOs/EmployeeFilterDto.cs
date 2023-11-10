namespace EmployeeService.DTOs
{
    public class EmployeeFilterDto
    {
        public int CountLoaded { get; set; }
        public int CountLoading { get; set; }
        public int JobPostId { get; set; }
        public string SortBy { get; set; } = null!;
        public bool SortDescending { get; set; }
    }
}
