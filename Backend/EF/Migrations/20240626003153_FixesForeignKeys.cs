using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.EF.Migrations
{
    /// <inheritdoc />
    public partial class FixesForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_finances_users_Id",
                table: "finances");

            migrationBuilder.CreateIndex(
                name: "IX_finances_UserId",
                table: "finances",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_finances_users_UserId",
                table: "finances",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_finances_users_UserId",
                table: "finances");

            migrationBuilder.DropIndex(
                name: "IX_finances_UserId",
                table: "finances");

            migrationBuilder.AddForeignKey(
                name: "FK_finances_users_Id",
                table: "finances",
                column: "Id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
