using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BeyondQueries.Models.Mapping
{
    public class movieMap : EntityTypeConfiguration<Movie>
    {
        public movieMap()
        {
            // Primary Key
            this.HasKey(t => t.movie_id);

            // Properties
            this.Property(t => t.title)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.subtitle)
                .HasMaxLength(64);

            this.Property(t => t.version)
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("movies");
            this.Property(t => t.movie_id).HasColumnName("movie_id");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.release_date).HasColumnName("release_date");
            this.Property(t => t.subtitle).HasColumnName("subtitle");
            this.Property(t => t.version).HasColumnName("version");
        }
    }
}
