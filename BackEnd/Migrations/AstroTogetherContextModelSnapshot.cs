﻿// <auto-generated />
using System;
using AstroTogether.BackEnd.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AstroTogether.BackEnd.Migrations
{
    [DbContext(typeof(AstroTogetherContext))]
    partial class AstroTogetherContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Attendee", b =>
                {
                    b.Property<Guid>("AttendeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("MeetAdmin")
                        .HasColumnType("bit");

                    b.Property<Guid>("MeetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("AttendeeId");

                    b.HasIndex("MemberId");

                    b.HasIndex("PersonId");

                    b.HasIndex(new[] { "MeetId", "MemberId" }, "IX_Attendee_MeetId_MemberId")
                        .IsUnique()
                        .HasFilter("[MemberId] IS NOT NULL");

                    b.HasIndex(new[] { "MeetId", "PersonId" }, "IX_Attendee_MeetId_PersonId");

                    b.ToTable("Attendee", (string)null);
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Club", b =>
                {
                    b.Property<Guid>("ClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("char(2)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ClubId");

                    b.HasIndex(new[] { "Country", "Region", "City" }, "IX_Club_Country_Region_City");

                    b.HasIndex(new[] { "Name" }, "IX_Club_Name")
                        .IsUnique();

                    b.ToTable("Club", (string)null);
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Crew", b =>
                {
                    b.Property<Guid>("CrewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<bool>("TeamAdmin")
                        .HasColumnType("bit");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CrewId");

                    b.HasIndex("MemberId");

                    b.HasIndex("TeamId");

                    b.ToTable("Crew", (string)null);
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Meet", b =>
                {
                    b.Property<Guid>("MeetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("MeetId");

                    b.HasIndex(new[] { "SiteId", "Date" }, "IX_Meet_SiteId_Date");

                    b.ToTable("Meet", (string)null);
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Member", b =>
                {
                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ClubAdmin")
                        .HasColumnType("bit");

                    b.Property<Guid>("ClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("MemberId");

                    b.HasIndex("PersonId");

                    b.HasIndex(new[] { "ClubId", "PersonId" }, "IX_Member_ClubId_PersonId")
                        .IsUnique();

                    b.ToTable("Member", (string)null);
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Person", b =>
                {
                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Initial")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.HasIndex(new[] { "Email" }, "IX_Person_Email")
                        .IsUnique();

                    b.HasIndex(new[] { "LastName", "FirstName", "Initial" }, "IX_Person_LastName_FirstName_Initial");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Site", b =>
                {
                    b.Property<Guid>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("SiteId");

                    b.HasIndex(new[] { "ClubId", "Name" }, "IX_Site_ClubId_Name")
                        .IsUnique();

                    b.HasIndex(new[] { "Name" }, "IX_Site_Name")
                        .IsUnique();

                    b.ToTable("Site", (string)null);
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Team", b =>
                {
                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("TeamId");

                    b.HasIndex(new[] { "ClubId", "Name" }, "IX_Team_ClubId_Name");

                    b.ToTable("Team", (string)null);
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Attendee", b =>
                {
                    b.HasOne("AstroTogether.BackEnd.DB.Meet", "Meet")
                        .WithMany("Attendees")
                        .HasForeignKey("MeetId")
                        .IsRequired()
                        .HasConstraintName("FK_Attendee_Meet");

                    b.HasOne("AstroTogether.BackEnd.DB.Member", "Member")
                        .WithMany("Attendees")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK_Attendee_Member");

                    b.HasOne("AstroTogether.BackEnd.DB.Person", "Person")
                        .WithMany("Attendees")
                        .HasForeignKey("PersonId")
                        .HasConstraintName("FK_Attendee_Person");

                    b.Navigation("Meet");

                    b.Navigation("Member");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Crew", b =>
                {
                    b.HasOne("AstroTogether.BackEnd.DB.Member", "Member")
                        .WithMany("Crews")
                        .HasForeignKey("MemberId")
                        .IsRequired()
                        .HasConstraintName("FK_Crew_Member");

                    b.HasOne("AstroTogether.BackEnd.DB.Team", "Team")
                        .WithMany("Crews")
                        .HasForeignKey("TeamId")
                        .IsRequired()
                        .HasConstraintName("FK_Crew_Team");

                    b.Navigation("Member");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Meet", b =>
                {
                    b.HasOne("AstroTogether.BackEnd.DB.Site", "Site")
                        .WithMany("Meets")
                        .HasForeignKey("SiteId")
                        .IsRequired()
                        .HasConstraintName("FK_Meet_Site");

                    b.OwnsOne("AstroTogether.BackEnd.DB.MeetDetails", "Details", b1 =>
                        {
                            b1.Property<Guid>("MeetId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("EndOn")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("StartOn")
                                .HasColumnType("datetime2");

                            b1.HasKey("MeetId");

                            b1.ToTable("Meet");

                            b1.ToJson("Details");

                            b1.WithOwner()
                                .HasForeignKey("MeetId");
                        });

                    b.Navigation("Details")
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Member", b =>
                {
                    b.HasOne("AstroTogether.BackEnd.DB.Club", "Club")
                        .WithMany("Members")
                        .HasForeignKey("ClubId")
                        .IsRequired()
                        .HasConstraintName("FK_Member_Club");

                    b.HasOne("AstroTogether.BackEnd.DB.Person", "Person")
                        .WithMany("Members")
                        .HasForeignKey("PersonId")
                        .IsRequired()
                        .HasConstraintName("FK_Member_Person");

                    b.Navigation("Club");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Site", b =>
                {
                    b.HasOne("AstroTogether.BackEnd.DB.Club", "Club")
                        .WithMany("Sites")
                        .HasForeignKey("ClubId")
                        .IsRequired()
                        .HasConstraintName("FK_Site_Club");

                    b.OwnsOne("AstroTogether.BackEnd.DB.SiteDetails", "Details", b1 =>
                        {
                            b1.Property<Guid>("SiteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float");

                            b1.HasKey("SiteId");

                            b1.ToTable("Site");

                            b1.ToJson("Details");

                            b1.WithOwner()
                                .HasForeignKey("SiteId");
                        });

                    b.Navigation("Club");

                    b.Navigation("Details")
                        .IsRequired();
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Team", b =>
                {
                    b.HasOne("AstroTogether.BackEnd.DB.Club", "Club")
                        .WithMany("Teams")
                        .HasForeignKey("ClubId")
                        .IsRequired()
                        .HasConstraintName("FK_Team_Club");

                    b.OwnsOne("AstroTogether.BackEnd.DB.TeamPolicy", "Policy", b1 =>
                        {
                            b1.Property<Guid>("TeamId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("AutoAttend")
                                .HasColumnType("bit");

                            b1.HasKey("TeamId");

                            b1.ToTable("Team");

                            b1.ToJson("Policy");

                            b1.WithOwner()
                                .HasForeignKey("TeamId");
                        });

                    b.Navigation("Club");

                    b.Navigation("Policy")
                        .IsRequired();
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Club", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Sites");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Meet", b =>
                {
                    b.Navigation("Attendees");
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Member", b =>
                {
                    b.Navigation("Attendees");

                    b.Navigation("Crews");
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Person", b =>
                {
                    b.Navigation("Attendees");

                    b.Navigation("Members");
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Site", b =>
                {
                    b.Navigation("Meets");
                });

            modelBuilder.Entity("AstroTogether.BackEnd.DB.Team", b =>
                {
                    b.Navigation("Crews");
                });
#pragma warning restore 612, 618
        }
    }
}