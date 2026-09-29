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
        }
    }
}
