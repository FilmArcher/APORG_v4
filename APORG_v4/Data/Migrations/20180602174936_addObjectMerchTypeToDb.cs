using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace APORG_v4.Data.Migrations
{
    public partial class addObjectMerchTypeToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectMerchTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Availability = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ObjectId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectMerchTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectMerchTypes_Objects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "Objects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);

                });


            migrationBuilder.CreateIndex(
                name: "IX_ObjectMerchTypes_ObjectId",
                table: "ObjectMerchTypes",
                column: "ObjectId");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "ObjectMerchTypes");

        }
    }
}
