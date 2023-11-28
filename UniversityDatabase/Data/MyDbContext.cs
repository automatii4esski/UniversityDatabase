using Microsoft.EntityFrameworkCore;
using UniversityDatabase.Models;

namespace UniversityDatabase.Data
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
    }
}
