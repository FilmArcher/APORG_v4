using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace APORG_v4.Data.Migrations
{
    public partial class addMusicianToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Biography = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: false),
                    Creation_date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Discography = table.Column<bool>(nullable: false),
                    First_name_manager = table.Column<string>(nullable: false),
                    Genre = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Last_name_manager = table.Column<string>(nullable: false),
                    Manager_contact = table.Column<string>(nullable: false),
                    Merch = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Region = table.Column<string>(nullable: false),
                    Town = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musicians_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musicians_UserId",
                table: "Musicians",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musicians");
        }
    }
}
