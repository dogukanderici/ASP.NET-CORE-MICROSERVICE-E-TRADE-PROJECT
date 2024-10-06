using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.Cargo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_05102024_1505 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelivered",
                table: "CargoOperations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "CargoDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelivered",
                table: "CargoOperations");

            migrationBuilder.AlterColumn<int>(
                name: "Barcode",
                table: "CargoDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
