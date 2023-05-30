using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7913bbba-5161-42f1-9104-3a9f357e0a3b", "AQAAAAIAAYagAAAAEKjOCQduPhW0CtEo5YZI3rSBBAXOa8kpM7uLxiyOUPHPrv6F6S4QW9MZEiJhmfXLPQ==", "6cd4b651-4ae2-41f2-929a-43f7ae2efa76" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0916eae6-bc44-473f-a963-5eb1430db870", "AQAAAAIAAYagAAAAEMlDNarzPzpLUWUUEyq08vw4OpnW2/dPmtWswUofbvBFJuCIOxivEnBZxS+RPcpqGg==", "07ca602f-dae1-4466-8802-f60a63f620fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0073ee93-a7ed-4514-82ed-a9e4bf3e05db", "AQAAAAIAAYagAAAAEODPWRzRHueH0jXID782+G8n6gvxP6IbGgmtLQvDTI+eVxAjp5oyqbFR2eXnDpHIqA==", "e9804969-ca69-4edb-a1eb-e1f5f9eb9998" });
        }
    }
}
