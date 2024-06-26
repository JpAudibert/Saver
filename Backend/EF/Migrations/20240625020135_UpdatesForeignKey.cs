using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.EF.Migrations
{
    /// <inheritdoc />
    public partial class UpdatesForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_finances_users_UserId",
                table: "finances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_finances",
                table: "finances");

            migrationBuilder.DropIndex(
                name: "IX_finances_UserId",
                table: "finances");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "finances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_finances",
                table: "finances",
                columns: new[] { "Id", "UserId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_finances",
                table: "finances");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "finances",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_finances",
                table: "finances",
                column: "Id");

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
    }
}
