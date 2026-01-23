using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bagery.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_promotioneditted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Decimal",
                table: "Promotions",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Promotions",
                newName: "Decimal");
        }
    }
}
