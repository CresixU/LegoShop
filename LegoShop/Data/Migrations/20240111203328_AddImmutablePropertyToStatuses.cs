using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegoShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImmutablePropertyToStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsImmutable",
                table: "OrderStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsImmutable",
                table: "OrderStatuses");
        }
    }
}
