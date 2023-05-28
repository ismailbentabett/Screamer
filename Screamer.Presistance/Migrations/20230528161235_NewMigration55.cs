using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration55 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59ffb246-2555-4f05-865a-a48013594102", "AQAAAAIAAYagAAAAEFSzyp9lwhE1rqphvhoLEnv0wH6fLVmSxqHFjzqnM1kEP8hrgszQDjej7K2/U3coIA==", "f343d6dd-bc8c-4bd4-a1a3-e9a4c62c4ed8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d8eeae5-c38e-41cd-b780-17666f7cd08b", "AQAAAAIAAYagAAAAEA6RI24TYND1Q4VvdmOV4q1Vj8OWdE5i9pn0oA4625Vngm8ZhSe6XgcqqmKpEVf+5g==", "47246063-a7c9-4918-b27a-f5d8394cd45b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46056b97-46c1-4730-963a-44dcc797a9b4", "AQAAAAIAAYagAAAAEOYhtC5Cnlk1zUK2BjI1Meb0e6iP9w/3q1PnSMtS5SJilHnGY76hG3AtSiRZSwmkQg==", "789fea86-3221-440e-bd7e-338a0e43d1c9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "811dbafa-051a-42b1-a244-28879f8fbf28", "AQAAAAIAAYagAAAAEFKdsmPppcBrqloSYlgGLCzFrJ0ZfAR4MT414b2MJFtmWVIfc+S9hfo3ID56HLJqKw==", "42abecc2-bff9-40e7-b8d0-6ae55c6fa203" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "621342d5-67a0-4145-9328-5d7a6476d49e", "AQAAAAIAAYagAAAAEE6z3mU4/GDBf6V1ZoY1NYKuogG/c5dkbKb0KSoBVWM1nQUK+WM1FJ+aC6TQJr5keg==", "3eb65954-4333-4901-9a47-b60d1411c2e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7aef78a2-c2b2-4a8b-92b3-758fc532b563", "AQAAAAIAAYagAAAAEHFsJ9ZC9uTwzpy1kQZP+F6wZG78/qAmp8tdhtErDBRhLRgPSm7U77ABAbzHt8itVA==", "74767b5b-37e7-4669-8c6a-a33ce2b88a3e" });
        }
    }
}
