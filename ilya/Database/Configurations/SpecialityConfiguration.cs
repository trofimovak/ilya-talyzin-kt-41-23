
using ilya.Database.Helpers;
using ilya.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ilya.Database.Configurations
{
    public class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
    {
        private const string TableName = "cd_speciality";

        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(p => p.SpecialityId)
                   .HasName($"pk_{TableName}_speciality_id");

            builder.Property(p => p.SpecialityId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("speciality_id")
                   .HasComment("Идентификатор специальности");

            builder.Property(p => p.Title)
                   .IsRequired()
                   .HasColumnName("c_title")
                   .HasColumnType($"{ColumnType.String}(200)")
                   .HasComment("Название специальности");

            builder.Property(p => p.Code)
                   .IsRequired()
                   .HasColumnName("c_code")
                   .HasColumnType($"{ColumnType.String}(20)")
                   .HasComment("Код специальности");

            builder.HasIndex(p => p.Code)
                   .IsUnique()
                   .HasDatabaseName($"uq_{TableName}_code");

            builder.HasMany(p => p.Groups)
                   .WithOne(p => p.Speciality)
                   .HasForeignKey(p => p.SpecialityId)
                   .HasConstraintName("fk_cd_group_speciality")
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
