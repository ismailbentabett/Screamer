using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1bbe2d7-6629-45f2-b4f9-364cbccab822", "AQAAAAIAAYagAAAAEPgquxMUj4MAnT2hEuVpKi215JawLMoJKHL+kpifAZK0cpOsvSJ1Hn48VZjYrrA+jQ==", "cd7de913-c210-404f-9e9d-6e42961afb48" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39b35b98-b0e5-49e5-bdb3-a51d7bb2154c", "AQAAAAIAAYagAAAAEA1CyfnYFUMn3g7KeYb+4R3f1E931ji9j+rGNqsojqMs6I6MqCfe9jYLkwcF118zMg==", "07623793-8501-4945-8f39-7ad4d4a198dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd81d6f3-10d5-4908-ad44-062c9df93786", "AQAAAAIAAYagAAAAEK8HbadZyWXnfrwD4TG21cSuSp72rTw5LSu3ucy/EMoTWWMRLk2xxuEEhpaaRgC1Ug==", "b26502c2-b86b-4533-adb0-f396b857b4d2" });
        }
    }
}
