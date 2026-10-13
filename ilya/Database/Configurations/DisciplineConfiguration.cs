
using ilya.Database.Helpers;
using ilya.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ilya.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "cd_discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(p => p.DisciplineId)
                   .HasName($"pk_{TableName}_discipline_id");

            builder.Property(p => p.DisciplineId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("discipline_id")
                   .HasComment("Идентификатор дисциплины");

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasColumnName("c_discipline_name")
                   .HasColumnType($"{ColumnType.String}(150)")
                   .HasComment("Название дисциплины");

            builder.Property(p => p.IsDeleted)
                   .IsRequired()
                   .HasColumnName("is_deleted")
                   .HasDefaultValue(false)
                   .HasComment("Статус удаления дисциплины");
        }
    }
}
