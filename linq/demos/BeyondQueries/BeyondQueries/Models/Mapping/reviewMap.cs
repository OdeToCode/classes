using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BeyondQueries.Models.Mapping
{
    public class reviewMap : EntityTypeConfiguration<review>
    {
        public reviewMap()
        {
            // Primary Key
            this.HasKey(t => t.review_id);

            // Properties
            this.Property(t => t.summary)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.review1)
                .IsRequired()
                .HasMaxLength(512);

            this.Property(t => t.reviewer)
                .HasMaxLength(64);

            // Table & Column Mappings
            this.ToTable("reviews");
            this.Property(t => t.review_id).HasColumnName("review_id");
            this.Property(t => t.movie_id).HasColumnName("movie_id");
            this.Property(t => t.summary).HasColumnName("summary");
            this.Property(t => t.rating).HasColumnName("rating");
            this.Property(t => t.review1).HasColumnName("review");
            this.Property(t => t.reviewer).HasColumnName("reviewer");

            // Relationships
            this.HasRequired(t => t.movie)
                .WithMany(t => t.reviews)
                .HasForeignKey(d => d.movie_id);

        }
    }
}
