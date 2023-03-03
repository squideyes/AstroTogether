using AstroTogether.Common;
using Microsoft.EntityFrameworkCore;

namespace AstroTogether.BackEnd.DB;

public partial class AstroTogetherContext : DbContext
{
    public AstroTogetherContext()
    {
    }

    public AstroTogetherContext(DbContextOptions<AstroTogetherContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }
    public virtual DbSet<Attendee> Attendees { get; set; }
    public virtual DbSet<Club> Clubs { get; set; }
    public virtual DbSet<Meet> Meets { get; set; }
    public virtual DbSet<Member> Members { get; set; }
    public virtual DbSet<Site> Sites { get; set; }
    public virtual DbSet<Crew> Crews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AstroTogether");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.ToTable("Actor");

            entity.HasIndex(e => e.Email, "IX_Actor_Email")
                .IsUnique();

            entity.HasIndex(e => new { e.LastName, e.FirstName, e.Initial },
                "IX_Actor_LastName_FirstName_Initial");

            entity.Property(e => e.ActorId)
                .ValueGeneratedNever();

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasConversion(v => v.AsString(), v => EmailAddress.From(v));

            entity.Property(e => e.FirstName)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.Property(e => e.Initial)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Attendee>(entity =>
        {
            entity.ToTable("Attendee");

            entity.HasIndex(e => new { e.MeetId, e.MemberId },
                "IX_Attendee_MeetId_MemberId").IsUnique();

            entity.Property(e => e.AttendeeId)
                .ValueGeneratedNever();

            entity.HasOne(d => d.Meet).WithMany(p => p.Attendees)
                .HasForeignKey(d => d.MeetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendee_Meet");

            entity.HasOne(d => d.Member).WithMany(p => p.Attendees)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendee_Member");
        });

        modelBuilder.Entity<Club>(entity =>
        {
            entity.ToTable("Club");

            entity.HasIndex(e => e.Name, "IX_Club_Name")
                .IsUnique();

            entity.Property(e => e.ClubId)
                .ValueGeneratedNever();

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Meet>(entity =>
        {
            entity.ToTable("Meet");

            entity.HasIndex(e => new { e.SiteId, e.CrewId, e.Date },
                "IX_Meet_SiteId_CrewId_Date").IsUnique();

            entity.Property(e => e.MeetId)
                .ValueGeneratedNever();

            entity.Property(e => e.Date)
                .HasColumnType("date");

            entity.OwnsOne(e => e.Details, b => b.ToJson());

            entity.HasOne(d => d.Site).WithMany(p => p.Meets)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Meet_Site");

            entity.HasOne(d => d.Crew).WithMany(p => p.Meets)
                .HasForeignKey(d => d.CrewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Meet_Crew");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.ToTable("Member");

            entity.HasIndex(e => new { e.ClubId, e.ActorId },
                "IX_Member_ClubId_ActorId").IsUnique();

            entity.Property(e => e.MemberId).ValueGeneratedNever();

            entity.HasOne(d => d.Actor).WithMany(p => p.Members)
                .HasForeignKey(d => d.ActorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Member_Actor");

            entity.HasOne(d => d.Club).WithMany(p => p.Members)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Member_Club");
        });

        modelBuilder.Entity<Site>(entity =>
        {
            entity.ToTable("Site");

            entity.HasIndex(e => new { e.ClubId, e.Name },
                "IX_Site_ClubId_Name").IsUnique();

            entity.HasIndex(e => e.Name, "IX_Site_Name")
                .IsUnique();

            entity.OwnsOne(e => e.Details, b => b.ToJson());

            entity.Property(e => e.SiteId)
                .ValueGeneratedNever();

            entity.Property(e => e.Blurb)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Club).WithMany(p => p.Sites)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Site_Club");
        });

        modelBuilder.Entity<Crew>(entity =>
        {
            entity.ToTable("Crew");

            entity.HasIndex(e => new { e.ClubId, e.Name },
                "IX_Crew_ClubId_Name");

            entity.Property(e => e.CrewId)
                .ValueGeneratedNever();

            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.OwnsOne(e => e.Policy, b => b.ToJson());

            entity.HasOne(d => d.Admin).WithMany(p => p.Crews)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Crew_Member");

            entity.HasOne(d => d.Club).WithMany(p => p.Crews)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Crew_Club");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
