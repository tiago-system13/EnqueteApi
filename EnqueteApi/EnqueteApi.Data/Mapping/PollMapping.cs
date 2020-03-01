using EnqueteApi.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnqueteApi.Data.Mapping
{
    public class PollMapping : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.ToTable("Poll", "EnqueteApi");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                 .HasColumnName("id");

            builder.Property(x => x.PollDescription)
                .HasColumnName("poll_description")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.CountViews)
                .HasColumnName("poll_count_views");
                
        }

    }
}
