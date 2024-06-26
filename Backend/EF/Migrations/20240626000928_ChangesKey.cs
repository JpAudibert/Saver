using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.EF.Migrations
{
    /// <inheritdoc />
    public partial class ChangesKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
    }
}
