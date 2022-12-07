using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class Adicionandocustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "c1c07f26-c046-4679-aac1-a19152ada631");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "fdbea438-909f-4f9f-937a-f3eac938aca2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09ee7ed9-d1b3-42af-8460-b055b5755294", "AQAAAAEAACcQAAAAENwBgrjEtOFMKXAAglqfzZSxetJzktzt2yEAifEzxUS3iYnD34pzwxV1sR3l0brKzw==", "ab7562eb-ef2d-4a6e-b2fa-935ebd2911c2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "bb8090a7-8262-41a2-935e-ae92dc40e9bd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "93d11a35-29b3-4402-917f-a756fe4f8c91");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d301541c-7939-4bcc-874c-d1286cccfe59", "AQAAAAEAACcQAAAAECRKmWOR3wyn6qpXlE+Js6ZI4UQukwDKQUvJo1Bmsha6CQYX3OeEHEn6TMrkz/KPQQ==", "609a3608-ae53-4143-9cd2-a45ab356425b" });
        }
    }
}
