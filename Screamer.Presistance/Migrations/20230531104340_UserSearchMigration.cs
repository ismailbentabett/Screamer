using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class UserSearchMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ObjectID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "ObjectID", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cda5a23f-7552-4f16-887a-20779cd63ed7", null, "AQAAAAIAAYagAAAAEN/tecLPFLf34xwW0PN++5m4840MyRONWMEs7WXeB0L9TqpyDIHei3g/M3nT5RfMig==", "270b1b14-7010-4a32-bb48-d08817da2357" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "ObjectID", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60f850ef-d26d-410e-b96e-ca0459a4d672", null, "AQAAAAIAAYagAAAAEIiTYjAkWXfwDy6fCeY2cUPixjxdICCloNzh51uBJ71zFcxeuQ3Eki0QQ8+ZFHjG2Q==", "0a2e65d6-845a-4815-a9e4-f9c23fc0c95d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "ObjectID", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6ffe85b-902d-4fb3-ac7f-b30315055898", null, "AQAAAAIAAYagAAAAENUvDvKxgkdNIu21wgJoXr/42iGPHxCJ3tZXj+hfTBiJlDZ8Yr47vNOfz1nsDsu4Gg==", "1e5059af-88d4-43c7-99b5-1385db4df133" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObjectID",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8571051c-8173-4b3b-95c8-81783be682e5", "AQAAAAIAAYagAAAAEPssPmGkUMKocMa5CS7+HGDuzvvp7Rw2YvfsT7l20V4TsgiZwufAkLpIqtYccnBYDw==", "f76300e1-5579-4337-ab9e-752193cd2998" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b0a06e5-688c-4587-ad80-bc5b6172bcd5", "AQAAAAIAAYagAAAAEGXKflmDUU6V59c5knPegkWBrE+DgFV7cCwSP2eV4LENC+ksla1Tf1wNRh2e/8RLOA==", "19735c34-5ac8-47b1-a78a-31e6263b5967" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "951a9bde-0f28-4594-b0cb-c4a8e66f069e", "AQAAAAIAAYagAAAAEG0SpUztpect45DjmbriNIcpv4vadqcPgR6sNR/QtHbZOsBVl1Ph6iG9LUq1bTV1iA==", "1e492965-c999-480f-8eb5-9be370257a20" });
        }
    }
}
