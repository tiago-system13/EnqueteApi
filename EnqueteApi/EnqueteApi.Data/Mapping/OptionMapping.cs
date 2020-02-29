using EnqueteApi.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnqueteApi.Data.Mapping
{
    public class OptionMapping : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable("Options", "EnqueteApi");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                 .HasColumnName("id");

            builder.Property(x => x.PollId)
               .HasColumnName("poll_id")
               .IsRequired();

            builder.Property(x => x.OptionDescription)
                .HasColumnName("option_description")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Count)
                .HasColumnName("option_cout");

            builder.HasOne(x => x.Poll)
             .WithMany(o => o.Options)
             .HasForeignKey(x => x.PollId);
        }
    }
}
