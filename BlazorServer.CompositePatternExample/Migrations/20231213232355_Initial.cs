using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer.CompositePatternExample.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsRoot = table.Column<bool>(type: "INTEGER", nullable: false),
                    DirectoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParentDirectoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Directories_Directories_ParentDirectoryId",
                        column: x => x.ParentDirectoryId,
                        principalTable: "Directories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DirectoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Directories_DirectoryId",
                        column: x => x.DirectoryId,
                        principalTable: "Directories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Directories",
                columns: new[] { "Id", "DirectoryId", "IsRoot", "Name", "ParentDirectoryId", "Size" },
                values: new object[] { 1, 0, true, "Root", null, 10 });

            migrationBuilder.InsertData(
                table: "Directories",
                columns: new[] { "Id", "DirectoryId", "IsRoot", "Name", "ParentDirectoryId", "Size" },
                values: new object[] { 2, 1, false, "Documents", null, 10 });

            migrationBuilder.InsertData(
                table: "Directories",
                columns: new[] { "Id", "DirectoryId", "IsRoot", "Name", "ParentDirectoryId", "Size" },
                values: new object[] { 3, 1, false, "Pictures", null, 10 });

            migrationBuilder.InsertData(
                table: "Directories",
                columns: new[] { "Id", "DirectoryId", "IsRoot", "Name", "ParentDirectoryId", "Size" },
                values: new object[] { 4, 3, false, "Snips", null, 10 });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "DirectoryId", "Name", "Size" },
                values: new object[] { 1, 1, "Root File", 256 });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "DirectoryId", "Name", "Size" },
                values: new object[] { 2, 2, "Document File", 512 });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "DirectoryId", "Name", "Size" },
                values: new object[] { 3, 3, "Picture File", 1028 });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "DirectoryId", "Name", "Size" },
                values: new object[] { 4, 4, "Snip File", 1028 });

            migrationBuilder.CreateIndex(
                name: "IX_Directories_ParentDirectoryId",
                table: "Directories",
                column: "ParentDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_DirectoryId",
                table: "Files",
                column: "DirectoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Directories");
        }
    }
}
