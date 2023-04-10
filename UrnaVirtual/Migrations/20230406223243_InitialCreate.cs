using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrnaVirtual.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aspirants",
                columns: table => new
                {
                    AspirantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullNameAspirant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExpeditionDateID = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PoliticParty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<int>(type: "int", nullable: false),
                    Departments = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aspirants", x => x.AspirantId);
                });

            migrationBuilder.CreateTable(
                name: "Voters",
                columns: table => new
                {
                    VoterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullNameVoter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpeditionDateID = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<int>(type: "int", nullable: false),
                    Departments = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voters", x => x.VoterId);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    VoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AspirantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.VoteId);
                    table.ForeignKey(
                        name: "FK_Votes_Aspirants_AspirantId",
                        column: x => x.AspirantId,
                        principalTable: "Aspirants",
                        principalColumn: "AspirantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votes_Voters_VoterId",
                        column: x => x.VoterId,
                        principalTable: "Voters",
                        principalColumn: "VoterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_AspirantId",
                table: "Votes",
                column: "AspirantId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VoterId",
                table: "Votes",
                column: "VoterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Aspirants");

            migrationBuilder.DropTable(
                name: "Voters");
        }
    }
}
