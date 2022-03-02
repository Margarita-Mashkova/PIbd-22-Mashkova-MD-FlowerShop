using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerShopDatabaseImplement.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flowers_Orders_FlowerId",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "FlowerId",
                table: "Flowers");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FlowerId",
                table: "Orders",
                column: "FlowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Flowers_FlowerId",
                table: "Orders",
                column: "FlowerId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Flowers_FlowerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FlowerId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "FlowerId",
                table: "Flowers",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Flowers_Orders_FlowerId",
                table: "Flowers",
                column: "FlowerId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
