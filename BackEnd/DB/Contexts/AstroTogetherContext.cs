// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

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

    public virtual DbSet<Attendee> Attendees { get; set; }
    public virtual DbSet<Club> Clubs { get; set; }
    public virtual DbSet<Crew> Crews { get; set; }
    public virtual DbSet<Meet> Meets { get; set; }
    public virtual DbSet<Member> Members { get; set; }
    public virtual DbSet<Person> People { get; set; }
    public virtual DbSet<Site> Sites { get; set; }
    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AstroTogether");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendee>(entity =>
        {
            entity.ToTable("Attendee");

            entity.HasIndex(e => new { e.MeetId, e.MemberId }, 
                "IX_Attendee_MeetId_MemberId").IsUnique();

            entity.HasIndex(e => new { e.MeetId, e.PersonId }, 
                "IX_Attendee_MeetId_PersonId");

            entity.Property(e => e.AttendeeId)
                .ValueGeneratedNever();

            entity.HasOne(d => d.Meet).WithMany(p => p.Attendees)
                .HasForeignKey(d => d.MeetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendee_Meet");

            entity.HasOne(d => d.Member).WithMany(p => p.Attendees)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Attendee_Member");

            entity.HasOne(d => d.Person).WithMany(p => p.Attendees)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_Attendee_Person");
        });

        modelBuilder.Entity<Club>(entity =>
        {
            entity.ToTable("Club");

            entity.HasIndex(e => new { e.Country, e.Region, e.City }, 
                "IX_Club_Country_Region_City");

            entity.HasIndex(e => e.Name, "IX_Club_Name")
                .IsUnique();

            entity.Property(e => e.ClubId)
                .ValueGeneratedNever(); 

            entity.Property(e => e.City)
                .HasMaxLength(25)
                .IsUnicode(false);
            
            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            
            entity.Property(e => e.Region)
                .HasMaxLength(25)
                .IsUnicode(false);
            
            entity.Property(e => e.Website)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Crew>(entity =>
        {
            entity.ToTable("Crew");

            entity.Property(e => e.CrewId)
                .ValueGeneratedNever();

            entity.HasOne(d => d.Member).WithMany(p => p.Crews)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Crew_Member");

            entity.HasOne(d => d.Team).WithMany(p => p.Crews)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Crew_Team");
        });

        modelBuilder.Entity<Meet>(entity =>
        {
            entity.ToTable("Meet");

            entity.HasIndex(e => new { e.SiteId, e.Date },
                "IX_Meet_SiteId_Date");

            entity.Property(e => e.MeetId)
                .ValueGeneratedNever();
            
            entity.Property(e => e.Date)
                .HasColumnType("date");

            entity.OwnsOne(e => e.Details, b => b.ToJson());

            entity.HasOne(d => d.Site).WithMany(p => p.Meets)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Meet_Site");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.ToTable("Member");

            entity.HasIndex(e => new { e.ClubId, e.PersonId },
                "IX_Member_ClubId_PersonId").IsUnique();

            entity.Property(e => e.MemberId)
                .ValueGeneratedNever();

            entity.HasOne(d => d.Club).WithMany(p => p.Members)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Member_Club");

            entity.HasOne(d => d.Person).WithMany(p => p.Members)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Member_Person");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");

            entity.HasIndex(e => e.Email, "IX_Person_Email").IsUnique();

            entity.HasIndex(e => new { e.LastName, e.FirstName, e.Initial }, "IX_Person_LastName_FirstName_Initial");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever();

            entity.Property(e => e.CellPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasConversion(v => v.AsString(), v => PhoneNumber.From(v));
            
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

        modelBuilder.Entity<Site>(entity =>
        {
            entity.ToTable("Site");

            entity.HasIndex(e => new { e.ClubId, e.Name }, 
                "IX_Site_ClubId_Name").IsUnique();

            entity.HasIndex(e => e.Name, 
                "IX_Site_Name").IsUnique();

            entity.Property(e => e.SiteId)
                .ValueGeneratedNever();

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.OwnsOne(e => e.Details, b => b.ToJson());

            entity.HasOne(d => d.Club).WithMany(p => p.Sites)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Site_Club");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.ToTable("Team");

            entity.HasIndex(e => new { e.ClubId, e.Name }, 
                "IX_Team_ClubId_Name");

            entity.Property(e => e.TeamId)
                .ValueGeneratedNever();

            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.OwnsOne(e => e.Policy, b => b.ToJson());

            entity.HasOne(d => d.Club).WithMany(p => p.Teams)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Team_Club");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}