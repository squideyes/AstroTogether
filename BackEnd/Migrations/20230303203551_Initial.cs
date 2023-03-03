using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstroTogether.BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Region = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Country = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    Website = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CellPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Initial = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    LastName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.SiteId);
                    table.ForeignKey(
                        name: "FK_Site_Club",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "ClubId");
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Policy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Team_Club",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "ClubId");
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClubAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Member_Club",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "ClubId");
                    table.ForeignKey(
                        name: "FK_Member_Person",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "Meet",
                columns: table => new
                {
                    MeetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meet", x => x.MeetId);
                    table.ForeignKey(
                        name: "FK_Meet_Site",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "SiteId");
                });

            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    CrewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TeamAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.CrewId);
                    table.ForeignKey(
                        name: "FK_Crew_Member",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId");
                    table.ForeignKey(
                        name: "FK_Crew_Team",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "Attendee",
                columns: table => new
                {
                    AttendeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MeetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MeetAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendee", x => x.AttendeeId);
                    table.ForeignKey(
                        name: "FK_Attendee_Meet",
                        column: x => x.MeetId,
                        principalTable: "Meet",
                        principalColumn: "MeetId");
                    table.ForeignKey(
                        name: "FK_Attendee_Member",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId");
                    table.ForeignKey(
                        name: "FK_Attendee_Person",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_MeetId_MemberId",
                table: "Attendee",
                columns: new[] { "MeetId", "MemberId" },
                unique: true,
                filter: "[MemberId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_MeetId_PersonId",
                table: "Attendee",
                columns: new[] { "MeetId", "PersonId" });

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_MemberId",
                table: "Attendee",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_PersonId",
                table: "Attendee",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Club_Country_Region_City",
                table: "Club",
                columns: new[] { "Country", "Region", "City" });

            migrationBuilder.CreateIndex(
                name: "IX_Club_Name",
                table: "Club",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crew_MemberId",
                table: "Crew",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_TeamId",
                table: "Crew",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Meet_SiteId_Date",
                table: "Meet",
                columns: new[] { "SiteId", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_Member_ClubId_PersonId",
                table: "Member",
                columns: new[] { "ClubId", "PersonId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_PersonId",
                table: "Member",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Email",
                table: "Person",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_LastName_FirstName_Initial",
                table: "Person",
                columns: new[] { "LastName", "FirstName", "Initial" });

            migrationBuilder.CreateIndex(
                name: "IX_Site_ClubId_Name",
                table: "Site",
                columns: new[] { "ClubId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Site_Name",
                table: "Site",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_ClubId_Name",
                table: "Team",
                columns: new[] { "ClubId", "Name" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendee");

            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "Meet");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Club");
        }
    }
}
