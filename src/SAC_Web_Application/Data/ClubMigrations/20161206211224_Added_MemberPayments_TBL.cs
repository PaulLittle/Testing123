using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAC_Web_Application.Data.ClubMigrations
{
    public partial class Added_MemberPayments_TBL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Member_MemberID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_MemberID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "Payments");

            migrationBuilder.CreateTable(
                name: "MemberPayments",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false),
                    PaymentID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberPayments", x => new { x.MemberID, x.PaymentID });
                    table.ForeignKey(
                        name: "FK_MemberPayments_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberPayments_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberPayments_MemberID",
                table: "MemberPayments",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberPayments_PaymentID",
                table: "MemberPayments",
                column: "PaymentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberPayments");

            migrationBuilder.AddColumn<int>(
                name: "MemberID",
                table: "Payments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MemberID",
                table: "Payments",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Member_MemberID",
                table: "Payments",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
