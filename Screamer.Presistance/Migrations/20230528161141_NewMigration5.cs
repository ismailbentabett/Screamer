using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
