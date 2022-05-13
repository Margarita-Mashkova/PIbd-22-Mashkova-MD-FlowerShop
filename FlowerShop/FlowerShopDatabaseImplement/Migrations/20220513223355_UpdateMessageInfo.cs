using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerShopDatabaseImplement.Migrations
{
    public partial class UpdateMessageInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "MessagesInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Reply",
                table: "MessagesInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "MessagesInfo");

            migrationBuilder.DropColumn(
                name: "Reply",
                table: "MessagesInfo");
        }
    }
}
