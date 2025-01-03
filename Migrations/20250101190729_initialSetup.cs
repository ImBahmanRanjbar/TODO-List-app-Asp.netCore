using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TODO.Migrations
{
    /// <inheritdoc />
    public partial class initialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    StatusID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "TODOs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TODOs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TODOs_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TODOs_statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "statuses",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { "coding", "Coding" },
                    { "ex ", "Exercise" },
                    { "home ", "Home" },
                    { "shopping ", "Shopping" },
                    { "university ", "university" },
                    { "work ", "Work" }
                });

            migrationBuilder.InsertData(
                table: "statuses",
                columns: new[] { "StatusID", "Name" },
                values: new object[,]
                {
                    { "Closed", "Completed" },
                    { "Open", "Open" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TODOs_CategoryID",
                table: "TODOs",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TODOs_StatusID",
                table: "TODOs",
                column: "StatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TODOs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "statuses");
        }
    }
}
