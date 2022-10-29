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
        public virtual DbSet<ContactDetail> ContactDetails { get; set; }

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
                entity.HasKey(e => e.Uuid)
                    .HasName("Contact_pkey");

                entity.ToTable("Contact");

                entity.HasComment("for person informations");

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IsActive).HasDefaultValueSql("true");
            });

            modelBuilder.Entity<ContactDetail>(entity =>
            {
                entity.HasKey(e => e.Uuid)
                    .HasName("ContactDetail_pkey");

                entity.ToTable("ContactDetail");

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.ContactUuid).HasColumnName("ContactUUID");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IsActive).HasDefaultValueSql("true");

                entity.HasOne(d => d.ContactUu)
                    .WithMany(p => p.ContactDetails)
                    .HasForeignKey(d => d.ContactUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ContactDetail_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
