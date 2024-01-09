using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegoShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddConstantIdToOrderStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConstId",
                table: "OrderStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConstId",
                table: "OrderStatuses");
        }
    }
}
