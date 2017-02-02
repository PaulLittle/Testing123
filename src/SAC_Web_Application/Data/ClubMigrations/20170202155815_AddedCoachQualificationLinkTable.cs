using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SAC_Web_Application.Data.ClubMigrations
{
    public partial class AddedCoachQualificationLinkTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    CoachID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    GardaVetExpDate = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.CoachID);
                });

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    QualID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QualName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.QualID);
                });

            migrationBuilder.CreateTable(
                name: "CoachQualifications",
                columns: table => new
                {
                    CoachID = table.Column<int>(nullable: false),
                    QualID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachQualifications", x => new { x.CoachID, x.QualID });
                    table.ForeignKey(
                        name: "FK_CoachQualifications_Coaches_CoachID",
                        column: x => x.CoachID,
                        principalTable: "Coaches",
                        principalColumn: "CoachID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoachQualifications_Qualifications_QualID",
                        column: x => x.QualID,
                        principalTable: "Qualifications",
                        principalColumn: "QualID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AlterColumn<DateTime>(
                name: "DOB",
                table: "Member",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_CoachQualifications_CoachID",
                table: "CoachQualifications",
                column: "CoachID");

            migrationBuilder.CreateIndex(
                name: "IX_CoachQualifications_QualID",
                table: "CoachQualifications",
                column: "QualID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoachQualifications");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DOB",
                table: "Member",
                type: "date",
                nullable: false);
        }
    }
}
