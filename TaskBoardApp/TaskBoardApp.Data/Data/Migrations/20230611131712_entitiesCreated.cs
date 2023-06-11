using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Data.Migrations
{
    public partial class entitiesCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" },
                    { 4, "Closed" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("3d6c182e-cbe0-4670-b2a9-dd89594a2d46"), 2, new DateTime(2023, 2, 1, 13, 17, 12, 220, DateTimeKind.Utc).AddTicks(9767), "This is so complicated man", "d85e761e-20a2-49fd-bd47-fb31436f4f0a", "What is HTML?" },
                    { new Guid("723e45fd-9358-4b03-ba16-6c3fb6107b30"), 4, new DateTime(2023, 4, 7, 13, 17, 12, 220, DateTimeKind.Utc).AddTicks(9771), "Chickens already sleeping", "d85e761e-20a2-49fd-bd47-fb31436f4f0a", "Time to sleep soon!" },
                    { new Guid("7a7f24e7-51cd-4a77-b1de-6f5fff820fdf"), 3, new DateTime(2023, 6, 6, 13, 17, 12, 220, DateTimeKind.Utc).AddTicks(9769), "I will learn this thing someday...", "ce27f01b-ac6c-4962-915a-fe92495d85ec", "MVC is LITT" },
                    { new Guid("b0885333-0636-47c5-b60f-e44c3a75b798"), 1, new DateTime(2022, 11, 23, 13, 17, 12, 220, DateTimeKind.Utc).AddTicks(9734), "Improve CSS styles of the application", "ce27f01b-ac6c-4962-915a-fe92495d85ec", "Improve CSS styles" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
