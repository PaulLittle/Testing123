using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SAC_Web_Application.Data.ClubMigrations
{
    public partial class Payment_ID_Fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PaymentID",
                table: "Payments",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentID",
                table: "MemberPayments",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PaymentID",
                table: "Payments",
                nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentID",
                table: "MemberPayments",
                nullable: false);
        }
    }
}
