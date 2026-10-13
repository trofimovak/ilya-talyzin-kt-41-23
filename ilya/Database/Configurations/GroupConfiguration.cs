
using ilya.Database.Helpers;
using ilya.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ilya.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        private const string TableName = "cd_group";

        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(p => p.GroupId)
                   .HasName($"pk_{TableName}_group_id");

            builder.Property(p => p.GroupId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("group_id")
                   .HasComment("Идентификатор записи группы");

            builder.Property(p => p.GroupName)
                   .IsRequired()
                   .HasColumnName("c_group_name")
                   .HasColumnType($"{ColumnType.String}(100)")
                   .HasComment("Название группы");

            builder.Property(p => p.Course)
                   .IsRequired()
                   .HasColumnName("c_course")
                   .HasColumnType(ColumnType.Int)
                   .HasComment("Курс обучения");

            builder.Property(p => p.SpecialityId)
                   .IsRequired()
                   .HasColumnName("f_speciality_id")
                   .HasComment("Идентификатор специальности");

            builder.Property(p => p.IsDeleted)
                   .IsRequired()
                   .HasColumnName("is_deleted")
                   .HasDefaultValue(false)
                   .HasComment("Статус удаления группы");

            builder.HasOne(p => p.Speciality)
                   .WithMany(p => p.Groups)
                   .HasForeignKey(p => p.SpecialityId)
                   .HasConstraintName("fk_cd_group_speciality")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.SpecialityId,
                $"idx_{TableName}_fk_speciality_id");

            builder.Navigation(p => p.Speciality).AutoInclude();
        }
    }
}
