using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "972b7d6a-e2ed-4b16-b8e7-5724e35df839", "AQAAAAIAAYagAAAAEEpDlw7nvcNySPEWKu6n9gIcIAfBUzOowXlqpfy6/vMAW3u4v7bJwO89NfwkrTcKmw==", "94c63149-f074-4f32-9daf-b15b52b1a84f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75c8b0a6-91d6-4171-85d3-f4dc174a35b7", "AQAAAAIAAYagAAAAEKEVc1c2gqTLX/i/ozmtmZp/MprfEzXlHo2pV03cQLhyRpnKArucp4v77oFpkRAT5A==", "2e2b652d-6401-4252-b846-17673b12fbbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec8f6f49-95bd-4970-8fc6-6a1b10bc70bf", "AQAAAAIAAYagAAAAEJQgy5DR8kkGWUhOCS7qXAomVj7QEJeso4pj72Uivj+5WJDu+z0iGNF6lDP5+ExO6A==", "ee98a401-90f7-42be-b15a-53e33a50314c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9567149d-caf5-4839-b007-6dfc572a8749", "AQAAAAIAAYagAAAAEK/YfMD2ByTGahwgBSYQLWjSvJEx8QUxbcaS0MrHaL7dmtTCY4ppWuhLfXuItVyVcw==", "31f84232-5992-4712-b394-cceb639d0ae9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fa47a57-bd2c-4582-b431-741498543d04", "AQAAAAIAAYagAAAAENOK9u46xpFKPGK6ElVfhxk/nPhP3Wk6V0urD+vA+fhoftQsDqPWkBT4t0v3kRXJPw==", "94e2bae2-754c-4b38-a330-00271eea3ea3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ec3f9e4-3713-4c44-aee5-3936adb45cf6", "AQAAAAIAAYagAAAAEMHVtfl4BuNpfWIugAw5xEUFYRw5aIxM71rtyGKjOaT+sWE7RCKtwb2MtUwzAlYeaw==", "18349043-aa86-4e4b-9cf9-1de706b95271" });
        }
    }
}
