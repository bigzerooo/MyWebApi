using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DbContext.SQL.Configurations
{
    public class LogsConfiguration: IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder
                .HasKey(l => l.Id);

            builder
                .Property(l => l.ActionName)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(l => l.ControllerName)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(l => l.ActionType)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
