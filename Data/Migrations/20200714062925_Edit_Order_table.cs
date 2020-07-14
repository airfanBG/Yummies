using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Edit_Order_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderComment",
                table: "Orders",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderComment",
                table: "Orders");
        }
    }
}
