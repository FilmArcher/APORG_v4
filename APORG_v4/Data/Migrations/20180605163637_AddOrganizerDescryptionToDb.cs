using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace APORG_v4.Data.Migrations
{
    public partial class AddOrganizerDescryptionToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Organizers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Organizers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Organizers");
        }
    }
}
