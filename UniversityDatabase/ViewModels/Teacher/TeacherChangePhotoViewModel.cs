namespace UniversityDatabase.ViewModels.Teacher
{
    public class TeacherChangePhotoViewModel
    {
        public int TeacherId { get; set; } = new();
        public IFormFile? Photo { get; set; }
    }
}
