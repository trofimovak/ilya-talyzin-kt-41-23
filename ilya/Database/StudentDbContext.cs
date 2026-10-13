
using Microsoft.EntityFrameworkCore;
using ilya.Models;
using ilya.Database.Configurations;

namespace ilya.Database
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Speciality> Specialities { get; set; }

        public DbSet<Discipline> Disciplines { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new SpecialityConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
