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
                name: "Actor",
                columns: table => new
                {
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Initial = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    LastName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CanAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Member_Actor",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "ActorId");
                    table.ForeignKey(
                        name: "FK_Member_Club",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "ClubId");
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Blurb = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
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
                name: "Crew",
                columns: table => new
                {
                    CrewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Policy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.CrewId);
                    table.ForeignKey(
                        name: "FK_Crew_Club",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "ClubId");
                    table.ForeignKey(
                        name: "FK_Crew_Member",
                        column: x => x.AdminId,
                        principalTable: "Member",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "Meet",
                columns: table => new
                {
                    MeetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CrewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meet", x => x.MeetId);
                    table.ForeignKey(
                        name: "FK_Meet_Crew",
                        column: x => x.CrewId,
                        principalTable: "Crew",
                        principalColumn: "CrewId");
                    table.ForeignKey(
                        name: "FK_Meet_Site",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "SiteId");
                });

            migrationBuilder.CreateTable(
                name: "Attendee",
                columns: table => new
                {
                    AttendeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MeetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actor_Email",
                table: "Actor",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actor_LastName_FirstName_Initial",
                table: "Actor",
                columns: new[] { "LastName", "FirstName", "Initial" });

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_MeetId_MemberId",
                table: "Attendee",
                columns: new[] { "MeetId", "MemberId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_MemberId",
                table: "Attendee",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Club_Name",
                table: "Club",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crew_AdminId",
                table: "Crew",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_ClubId_Name",
                table: "Crew",
                columns: new[] { "ClubId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Meet_CrewId",
                table: "Meet",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Meet_SiteId_CrewId_Date",
                table: "Meet",
                columns: new[] { "SiteId", "CrewId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_ActorId",
                table: "Member",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_ClubId_ActorId",
                table: "Member",
                columns: new[] { "ClubId", "ActorId" },
                unique: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendee");

            migrationBuilder.DropTable(
                name: "Meet");

            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Club");
        }
    }
}
