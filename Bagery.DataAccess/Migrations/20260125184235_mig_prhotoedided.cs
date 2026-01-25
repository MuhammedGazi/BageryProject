using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bagery.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_prhotoedided : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePublicId",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUrl",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePublicId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                table: "ProductImages");
        }
    }
}
