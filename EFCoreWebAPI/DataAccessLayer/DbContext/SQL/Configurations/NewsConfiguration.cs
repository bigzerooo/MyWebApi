using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.DbContext.SQL.Configurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(45);

            builder
                .Property(x => x.Date)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(5000);
        }
    }
}
