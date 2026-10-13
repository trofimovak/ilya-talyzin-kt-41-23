
using ilya.Database.Helpers;
using ilya.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ilya.Database.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        private const string TableName = "cd_grade";

        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(p => p.GradeId)
                   .HasName($"pk_{TableName}_grade_id");

            builder.Property(p => p.GradeId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("grade_id")
                   .HasComment("Идентификатор оценки");

            builder.Property(p => p.Value)
                   .IsRequired()
                   .HasColumnName("c_value")
                   .HasColumnType(ColumnType.Int)
                   .HasComment("Значение оценки");

            builder.Property(p => p.StudentId)
                   .IsRequired()
                   .HasColumnName("f_student_id")
                   .HasComment("Идентификатор студента");

            builder.Property(p => p.DisciplineId)
                   .IsRequired()
                   .HasColumnName("f_discipline_id")
                   .HasComment("Идентификатор дисциплины");

            builder.HasOne(p => p.Student)
                   .WithMany(p => p.Grades)
                   .HasForeignKey(p => p.StudentId)
                   .HasConstraintName("fk_cd_grade_student")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Discipline)
                   .WithMany(p => p.Grades)
                   .HasForeignKey(p => p.DisciplineId)
                   .HasConstraintName("fk_cd_grade_discipline")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.StudentId)
                   .HasDatabaseName($"idx_{TableName}_fk_student_id");

            builder.HasIndex(p => p.DisciplineId)
                   .HasDatabaseName($"idx_{TableName}_fk_discipline_id");

            builder.Navigation(p => p.Student).AutoInclude();
            builder.Navigation(p => p.Discipline).AutoInclude();
        }
    }
}
