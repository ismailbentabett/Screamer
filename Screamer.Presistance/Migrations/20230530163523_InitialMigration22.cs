using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ObjectID",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObjectID",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1182fb1f-71ce-475b-b651-9d3193d697d3", "AQAAAAIAAYagAAAAEIt3tjkjQCJdje0dUTskQ2MHFxuQ6K+uO6c03F80hXAUfLjXFm1PtzAq8lUPzzgIjA==", "56b74f25-9797-4129-ae58-4d0e43edb983" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40c7939f-3fbc-4e29-9c68-364d96f456dd", "AQAAAAIAAYagAAAAEKbuwulqsKdm2Fch46vZVapuETPULEyXX/niH5Hsx7lTPabrs/Rk0ETmSGQF1cZseg==", "b3ba9825-c5de-4cb4-89c3-361c60872451" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3695f653-8a32-4f1b-97cc-7c431e9a4a63", "AQAAAAIAAYagAAAAEBckGjtZBmQ5NNIY4T5zp0njZEk3lWkBusBz5Zg0azdJhxT4ygc6FEtACD3Sj8ryNg==", "579f1454-213f-49b9-90d9-2cfa0dbcc1fe" });
        }
    }
}
