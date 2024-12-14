using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldCountriesDirectoryApiApp.Storage.Migrations
{
    /// <inheritdoc />
    public partial class InitSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Counries",
                table: "Counries");

            migrationBuilder.DropIndex(
                name: "IX_Counries_IsoAlpha2",
                table: "Counries");

            migrationBuilder.RenameTable(
                name: "Counries",
                newName: "Countries");

            migrationBuilder.AlterColumn<string>(
                name: "IsoAlpha2",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Counries");

            migrationBuilder.AlterColumn<string>(
                name: "IsoAlpha2",
                table: "Counries",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Counries",
                table: "Counries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Counries_IsoAlpha2",
                table: "Counries",
                column: "IsoAlpha2",
                unique: true);
        }
    }
}
