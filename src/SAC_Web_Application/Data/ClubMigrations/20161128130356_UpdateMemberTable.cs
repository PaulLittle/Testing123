using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAC_Web_Application.Data.ClubMigrations
{
    public partial class UpdateMemberTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamName",
                table: "Member");

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "Member",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Member",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Member",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Member",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "CountyOfBirth",
                table: "Member",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "County",
                table: "Member",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Member",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Address1",
                table: "Member",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeamName",
                table: "Member",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "Member",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Member",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Member",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Member",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountyOfBirth",
                table: "Member",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "County",
                table: "Member",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Member",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address1",
                table: "Member",
                nullable: true);
        }
    }
}
