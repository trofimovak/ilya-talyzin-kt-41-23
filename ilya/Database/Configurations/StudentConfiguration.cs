using ilya.Database.Helpers;
using ilya.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ilya.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "cd_student";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(p => p.StudentId)
                   .HasName($"pk_{TableName}_student_id");

            builder.Property(p => p.StudentId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("student_id")
                   .HasComment("Идентификатор записи студента");

            builder.Property(p => p.FirstName)
                   .IsRequired()
                   .HasColumnName("c_student_firstname")
                   .HasColumnType($"{ColumnType.String}(100)")
                   .HasComment("Имя студента");

            builder.Property(p => p.LastName)
                   .IsRequired()
                   .HasColumnName("c_student_lastname")
                   .HasColumnType($"{ColumnType.String}(100)")
                   .HasComment("Фамилия студента");

            builder.Property(p => p.MiddleName)
                   .HasColumnName("c_student_middlename")
                   .HasColumnType($"{ColumnType.String}(100)")
                   .HasComment("Отчество студента");

            builder.Property(p => p.GroupId)
                   .HasColumnName("f_group_id")
                   .HasComment("Идентификатор группы");

            builder.HasOne(p => p.Group)
                   .WithMany()
                   .HasForeignKey(p => p.GroupId)
                   .HasConstraintName("fk_f_group_id")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.GroupId, $"idx_{TableName}_fk_f_group_id");

            builder.Navigation(p => p.Group).AutoInclude();
        }
    }
}
