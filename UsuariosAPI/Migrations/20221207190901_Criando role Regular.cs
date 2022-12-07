using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class CriandoroleRegular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "93d11a35-29b3-4402-917f-a756fe4f8c91");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "bb8090a7-8262-41a2-935e-ae92dc40e9bd", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d301541c-7939-4bcc-874c-d1286cccfe59", "AQAAAAEAACcQAAAAECRKmWOR3wyn6qpXlE+Js6ZI4UQukwDKQUvJo1Bmsha6CQYX3OeEHEn6TMrkz/KPQQ==", "609a3608-ae53-4143-9cd2-a45ab356425b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "c5de1dcd-4478-422f-a5bc-0e4945fc150c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbd78fb9-4502-4e99-aac7-31a121791eec", "AQAAAAEAACcQAAAAEEHqF6ELV3SwkhxwI0rF8ETsachO23W1bY/lbAyFOhej+ZoAZvUZ3onL7Ek81SeKMQ==", "54cbfbb0-4251-4d16-b36b-96a47c689ec7" });
        }
    }
}
