namespace UniversityDatabase.ViewModels.Student
{
    public class StudentChangePhotoViewModel
    {
        public int StudentId { get; set; } = new();
        public IFormFile? Photo { get; set; }
    }
}
