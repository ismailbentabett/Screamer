using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class INitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db3ea301-8852-467a-b6fc-eb871f767afa", "AQAAAAIAAYagAAAAEHFOydoGLYWbDdiED5tub3/nhRpTwi71CWrc6e41VFXxpgLXXz2zRbuzjW83ZGVaUg==", "3d86d341-b12c-4381-969d-a21f0bc026e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca674ecf-b5d2-45c1-aad2-f6ee18607803", "AQAAAAIAAYagAAAAENSldE5QMlV6bN03diD+dZI/mz2Di2omuM2uoz0WMkDW5W+nmXLWFiwSdQC/cZHh+A==", "05955e15-5a9a-4a59-84b9-34713d1b7b80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05d92fba-41ff-4d7b-a41e-1277d36faddc", "AQAAAAIAAYagAAAAECX2GxR44CFS6/F/n7c4TFq7YSPZAfAUeq54MnnWioQADmkr8/M04xfiTpAuVM2gfA==", "8a1a224f-74e3-4366-8535-294a38c1479f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da00af08-e532-4bf6-b08e-0f871e26fc37", "AQAAAAIAAYagAAAAEPfXmU4uIpBvHq5ERBSPVpowf1lDsTs5UGVtQ/L+ayEi6sW2zx6SFlgaDmcRlX0z1g==", "9199ed5f-3c2b-422b-aa0d-a41cc94a9a2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c809bb78-48ad-4072-b7e2-9c8fb8986447", "AQAAAAIAAYagAAAAEDy/MkSErF5rHYcOQsMh6NHCSoiUfDvFfG0WwezpXWYLOvPrmb54kgBikR3vW7rDIQ==", "2814e9f2-0474-49b9-a4fa-500265939b0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c198a046-7fb0-4dc4-9bec-ad396c98ded9", "AQAAAAIAAYagAAAAEI3L7hRIOUOAuFFYdGzQmbr/a1ZUyBsIf7UyGGDv76stiQFg2xZMHYDcIJuw0vO/4g==", "67b396c6-ab9e-4f74-b727-a50c14e87503" });
        }
    }
}
