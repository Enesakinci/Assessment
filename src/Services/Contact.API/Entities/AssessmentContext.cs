using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Contact.API.Entities
{
    public partial class AssessmentContext : DbContext
    {
        public AssessmentContext()
        {
        }

        public AssessmentContext(DbContextOptions<AssessmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Assessment;User Id=postgres;Password=asdqwe123;Integrated Security=true;Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_Turkey.1254");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Contact");

                entity.HasComment("for person informations");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IsActive).HasDefaultValueSql("true");

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasDefaultValueSql("gen_random_uuid()");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
