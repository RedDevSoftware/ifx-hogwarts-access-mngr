using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ifx.Services.hogwartsAccess.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_STUDENT",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_STUDENT", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ADMISSION",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    identification = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    age = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    houseRequest = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    status = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ADMISSION", x => x.id);
                    table.ForeignKey(
                        name: "FK_STUDENT_ADMISSION",
                        column: x => x.identification,
                        principalTable: "TBL_STUDENT",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TBL_STUDENT",
                columns: new[] { "id", "lastName", "name" },
                values: new object[] { "1121931225", "Cardenas", "Pedro" });

            migrationBuilder.InsertData(
                table: "TBL_ADMISSION",
                columns: new[] { "id", "age", "houseRequest", "identification", "status" },
                values: new object[] { new Guid("b47e669d-b685-499a-a6b8-5bf0f694bdaa"), "16", 3, "1121931225", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ADMISSION_identification",
                table: "TBL_ADMISSION",
                column: "identification");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_ADMISSION");

            migrationBuilder.DropTable(
                name: "TBL_STUDENT");
        }
    }
}
