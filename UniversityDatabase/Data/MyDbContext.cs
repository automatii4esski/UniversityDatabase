using Microsoft.EntityFrameworkCore;
using UniversityDatabase.Models;

namespace UniversityDatabase.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Dean> Deans { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudyGroup> StudyGroups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<TeacherPosition> TeacherPositions { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TypeOfOccupation> TypeOfOccupations { get; set; }
        public DbSet<FormOfControl> FormOfControls { get; set; }
        public DbSet<StudyPlan> StudyPlans { get; set; }
        public DbSet<GradeValue> GradeValues { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }
        public DbSet<Workload> Workloads { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }


    }
}
