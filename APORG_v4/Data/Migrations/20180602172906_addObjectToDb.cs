using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace APORG_v4.Data.Migrations
{
    public partial class addObjectToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Objects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(nullable: true),
                    Stage_comments = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    acoustics = table.Column<bool>(nullable: false),
                    acoustics_contact = table.Column<string>(nullable: true),
                    backline = table.Column<bool>(nullable: false),
                    backline_description = table.Column<string>(nullable: true),
                    backstage = table.Column<bool>(nullable: false),
                    backstage_description = table.Column<string>(nullable: true),
                    backstage_surface = table.Column<double>(nullable: true),
                    bar = table.Column<bool>(nullable: false),
                    bar_desc = table.Column<string>(nullable: true),
                    cloakroom = table.Column<bool>(nullable: false),
                    country = table.Column<string>(maxLength: 69, nullable: false),
                    cubature = table.Column<int>(nullable: false),
                    frontline = table.Column<bool>(nullable: false),
                    frontline_description = table.Column<string>(nullable: true),
                    garden = table.Column<bool>(nullable: false),
                    lighting_technician = table.Column<bool>(nullable: false),
                    lighting_technician_contact = table.Column<string>(nullable: true),
                    lights = table.Column<bool>(nullable: false),
                    lights_description = table.Column<string>(nullable: true),
                    manager_contact = table.Column<string>(nullable: true),
                    manager_email = table.Column<string>(nullable: true),
                    manager_lastname = table.Column<string>(maxLength: 69, nullable: true),
                    manager_name = table.Column<string>(maxLength: 69, nullable: true),
                    no_building = table.Column<int>(nullable: false),
                    object_desc = table.Column<string>(maxLength: 300, nullable: true),
                    object_name = table.Column<string>(maxLength: 69, nullable: false),
                    object_surface = table.Column<double>(nullable: false),
                    parking = table.Column<bool>(nullable: false),
                    post_code = table.Column<string>(nullable: false),
                    region = table.Column<string>(maxLength: 69, nullable: false),
                    safeguard = table.Column<bool>(nullable: false),
                    stage = table.Column<bool>(nullable: false),
                    stage_surface = table.Column<float>(nullable: true),
                    street = table.Column<string>(maxLength: 69, nullable: false),
                    town = table.Column<string>(maxLength: 69, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objects", x => x.Id);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Objects");

        }
    }
}
