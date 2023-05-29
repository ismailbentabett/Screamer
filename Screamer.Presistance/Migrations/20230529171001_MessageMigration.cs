using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class MessageMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_Messages_LatestMessageId",
                table: "ChatRooms");

            migrationBuilder.AlterColumn<int>(
                name: "LatestMessageId",
                table: "ChatRooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_Messages_LatestMessageId",
                table: "ChatRooms",
                column: "LatestMessageId",
                principalTable: "Messages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_Messages_LatestMessageId",
                table: "ChatRooms");

            migrationBuilder.AlterColumn<int>(
                name: "LatestMessageId",
                table: "ChatRooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfb8e4d8-1698-4853-a8b9-44fd5189acff", "AQAAAAIAAYagAAAAEEEI5/v9AgOELKsf33uoLzsWjvx37ZXgs/YAWuRsP5FHthge3dl76JHbHqhvVI+x8w==", "af22a0f9-5fb9-41f6-b68d-be6ff3aa2e1b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d57d4000-f91b-4f03-8d84-9ec5fdcc7a57", "AQAAAAIAAYagAAAAELBIhURN8oHdD0Fx8sxfKC8MqmFi3PXk188nxvxWeK1U/ILPMarja3l0XxdgscHtCQ==", "82ced35f-e23d-49bb-abd8-ee84566551cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15cea762-b629-46f9-813d-6ed8522baa3e", "AQAAAAIAAYagAAAAEMqYoGIgkTgMvm1FFJ6JQj+rJ7e4t3s3fHfwAYGLaYi736j5RNufjIKgKNQfmhT4fg==", "dff1c81e-1b77-47a4-a08d-0d29fa75504f" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_Messages_LatestMessageId",
                table: "ChatRooms",
                column: "LatestMessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
