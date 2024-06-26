using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.EF.Migrations
{
    /// <inheritdoc />
    public partial class Seeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "IdentificationNumber", "IsActive", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("105b06df-73cc-4a6e-9a14-f6ee4912e8b1"), "denilson@email.com", "09755120050", true, "Denílson", "denilson123" },
                    { new Guid("548dfcc0-a38e-456f-9430-17ad3950ab39"), "craqueneto@email.com", "47420061009", true, "Craque Neto", "netaoBomBeef" },
                    { new Guid("70359af3-ca94-410d-87fb-f909cde413ac"), "neymarjr@email.com", "34546715072", true, "Neymar Jr", "adultoNey123" },
                    { new Guid("7c149996-5bba-4c04-8450-f0ab2f888299"), "renatafan@email.com", "04951619008", true, "Renata Fan", "renatafanJogoAberto" },
                    { new Guid("d5af0c60-f6e5-4b3d-af69-2d992b7ae096"), "alexandrepato@email.com", "39212783090", true, "Alexandre Pato", "patopato123" }
                });

            migrationBuilder.InsertData(
                table: "finances",
                columns: new[] { "Id", "Amount", "Description", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("0f16ba2e-64a1-47a5-bd33-b690ca254a99"), 5548.0, "Clothing", "expense", new Guid("7c149996-5bba-4c04-8450-f0ab2f888299") },
                    { new Guid("10c13555-30f2-4dee-adb0-43ce0b245d7e"), 30000.0, "Salary", "income", new Guid("7c149996-5bba-4c04-8450-f0ab2f888299") },
                    { new Guid("1366e7ad-4e5d-4f0d-b3d4-48832fa7bb8f"), 10000.0, "Salary", "income", new Guid("d5af0c60-f6e5-4b3d-af69-2d992b7ae096") },
                    { new Guid("2b2af71f-0849-437f-81a9-6b370a3ada07"), 1534.0, "Groceries", "expense", new Guid("70359af3-ca94-410d-87fb-f909cde413ac") },
                    { new Guid("4dc02086-add7-4997-ad44-c1c4775b6327"), 250.0, "Clothing", "expense", new Guid("7c149996-5bba-4c04-8450-f0ab2f888299") },
                    { new Guid("52a675e8-c2ab-45e2-89d5-1b04a3d92465"), 2544.0, "Salon", "expense", new Guid("7c149996-5bba-4c04-8450-f0ab2f888299") },
                    { new Guid("58edcbda-81aa-4ceb-b200-7365008ec9b1"), 1000.0, "Clothing", "expense", new Guid("d5af0c60-f6e5-4b3d-af69-2d992b7ae096") },
                    { new Guid("59dab4c4-b698-4d73-9ecb-54cad193fb65"), 1000.0, "Tax Refund", "income", new Guid("105b06df-73cc-4a6e-9a14-f6ee4912e8b1") },
                    { new Guid("5f6fb1ce-55d4-425f-9435-2c23106c6611"), 250.0, "Groceries", "expense", new Guid("d5af0c60-f6e5-4b3d-af69-2d992b7ae096") },
                    { new Guid("74512627-490d-44b6-8882-831010aeeacb"), 999999.0, "Clothing", "expense", new Guid("70359af3-ca94-410d-87fb-f909cde413ac") },
                    { new Guid("83414412-8015-45f6-acae-bfcb70e065f7"), 250215.0, "Party", "expense", new Guid("70359af3-ca94-410d-87fb-f909cde413ac") },
                    { new Guid("8c9737b3-7f9f-4513-94b0-f0c55adf5f76"), 20000.0, "Salary", "income", new Guid("105b06df-73cc-4a6e-9a14-f6ee4912e8b1") },
                    { new Guid("a34f644b-abdd-4100-bbc0-6acd2015440c"), 10000000.0, "Salary", "income", new Guid("70359af3-ca94-410d-87fb-f909cde413ac") },
                    { new Guid("a983e4ad-4958-48d1-9e83-45a97533de4f"), 1000.0, "Fine", "expense", new Guid("70359af3-ca94-410d-87fb-f909cde413ac") },
                    { new Guid("ab85ccfd-8fd8-4f9e-bc89-b2ea558e230e"), 15000.0, "Salary", "income", new Guid("548dfcc0-a38e-456f-9430-17ad3950ab39") },
                    { new Guid("b16e7375-6f47-4885-a29a-4d341abd1c25"), 2400.0, "Hairdresser", "expense", new Guid("7c149996-5bba-4c04-8450-f0ab2f888299") },
                    { new Guid("f9bd5e33-ec28-46d9-8ecf-d24319954002"), 2565.0, "Clothing", "expense", new Guid("70359af3-ca94-410d-87fb-f909cde413ac") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "finances",
                keyColumn: "Id",
                keyValue: new Guid("0f16ba2e-64a1-47a5-bd33-b690ca254a99"));

            migrationBuilder.DeleteData(
                table: "finances",
                keyColumn: "Id",
                keyValue: new Guid("10c13555-30f2-4dee-adb0-43ce0b245d7e"));

            migrationBuilder.DeleteData(
                table: "finances",
                keyColumn: "Id",
                keyValue: new Guid("1366e7ad-4e5d-4f0d-b3d4-48832fa7bb8f"));

            migrationBuilder.DeleteData(
                table: "finances",
                keyColumn: "Id",
                keyValue: new Guid("2b2af71f-0849-437f-81a9-6b370a3ada07"));

            migrationBuilder.DeleteData(
                table: "finances",
                keyColumn: "Id",
                keyValue: new Guid("4dc02086-add7-4997-ad44-c1c4775b6327"));

            migrationBuilder.DeleteData(
                table: "finances",
                keyColumn: "Id",
                keyValue: new Guid("52a675e8-c2ab-45e2-89d5-1b04a3d92465"));

            migrationBuilder.DeleteData(
                table: "finances",
                keyColumn: "Id",
                keyValue: new Guid("58edcbda-81aa-4ceb-b200-7365008ec9b1"));

            migrationBuilder.DeleteData(
                table: "finances",
                keyColumn: "Id",
                keyValue: new Guid("59dab4c4-b698-4d73-9ecb-54cad193fb65"));

            migrationBuilder.DeleteData(
                table: "finances",
                keyColumn: "Id",
                keyValue: new Guid("5f6fb1ce-55d4-425f-9435-2c23106c6611"));

            migrationBuilder.DeleteData(
                table: "finances",
                keyColumn: "Id",
                keyValue: new Guid("74512627-490d-44b6-8882-831010aeeacb"));

            migrationBuilder.DeleteData(
                table: "finances",
                keyColumn: "Id",
                keyValue: new Guid("83414412-8015-45f6-acae-bfcb70e065f7"));

            migrationBuilder.DeleteData(
                table: "finances",
                keyColumn: "Id",
                keyValue: new Guid("8c9737b3-7f9f-4513-94b0-f0c55adf5f76"));

            migrationBuilder.DeleteData(
                table: "finances",
                keyColumn: "Id",
                keyValue: new Guid("a34f644b-abdd-4100-bbc0-6acd2015440c"));

            migrationBuilder.DeleteData(
                table: "finances",
                keyColumn: "Id",
                keyValue: new Guid("a983e4ad-4958-48d1-9e83-45a97533de4f"));

            migrationBuilder.DeleteData(
                table: "finances",
                keyColumn: "Id",
                keyValue: new Guid("ab85ccfd-8fd8-4f9e-bc89-b2ea558e230e"));

            migrationBuilder.DeleteData(
                table: "finances",
                keyColumn: "Id",
                keyValue: new Guid("b16e7375-6f47-4885-a29a-4d341abd1c25"));

            migrationBuilder.DeleteData(
                table: "finances",
                keyColumn: "Id",
                keyValue: new Guid("f9bd5e33-ec28-46d9-8ecf-d24319954002"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("105b06df-73cc-4a6e-9a14-f6ee4912e8b1"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("548dfcc0-a38e-456f-9430-17ad3950ab39"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("70359af3-ca94-410d-87fb-f909cde413ac"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("7c149996-5bba-4c04-8450-f0ab2f888299"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("d5af0c60-f6e5-4b3d-af69-2d992b7ae096"));
        }
    }
}
