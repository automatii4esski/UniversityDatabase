namespace UniversityDatabase.ViewModels.Department
{
    using UniversityDatabase.Models;
    public class DepartmentToShow : Department
    {
        public string FacultyName { get; set; } = "";
        public string DeanName { get; set; } = "";

        public DepartmentToShow(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            Phone = department.Phone;
        }
    }
}
