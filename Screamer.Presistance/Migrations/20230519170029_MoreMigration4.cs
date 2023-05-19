using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class MoreMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adress_AspNetUsers_UserId",
                table: "Adress");

            migrationBuilder.DropForeignKey(
                name: "FK_Social_AspNetUsers_UserId",
                table: "Social");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Social",
                table: "Social");

            migrationBuilder.DropIndex(
                name: "IX_Social_UserId",
                table: "Social");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adress",
                table: "Adress");

            migrationBuilder.DropIndex(
                name: "IX_Adress_UserId",
                table: "Adress");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Social");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Social");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Social");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Social");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Adress");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Adress");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Adress");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Adress");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d92f1be9-bba4-4c02-bc6e-f15fd284a2aa", "AQAAAAIAAYagAAAAEEIrvkrkLusZXEDXeD6u65xfXEbRXBqhoWSqksETpesJiFYJ/0oxbEDL59ss+4EcpA==", "d4139a58-ffdb-46c9-a91f-84ae02ceecda" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3479f81-a6f7-4989-8195-652eb3879c56", "AQAAAAIAAYagAAAAEKpIgLg6LP0/S9GZNz9yiSnpczEu902BogT/8FuUtEdKB4/+2QHxW7b5fr2pT6cmQA==", "f28d825b-1b24-44ee-a2d5-8640c448a97a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ec93f2f-9b80-42d6-813c-165f1777ae69", "AQAAAAIAAYagAAAAENtAa7JL2jKtYAMzppQ79Z3ivpUhPLFP/jQYLtd5O7+5ge/vNPVEsIGZZH6OqEI9zw==", "32e64642-d182-42ce-b7fd-f11af680f02e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Social",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Social",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Social",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Social",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Adress",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Adress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Adress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Adress",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Social",
                table: "Social",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adress",
                table: "Adress",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1289f117-c664-4e0e-86d6-89b6cc1649ab", "AQAAAAIAAYagAAAAEKHNzZt9lF31v7sD+ei8azdxYu17aRoV5lu3TOIa9AealNzOggT1kI49Ld7BTSINqQ==", "49bb6587-70ac-4468-89fb-ffc0672df8e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8931ce4-7e9b-4226-a951-fb46b508d52c", "AQAAAAIAAYagAAAAEIZXt854r1c6QeL5br3IIeca8jDprV6MvyT70PEyS2qdD3YQ79dHOu8p9Q85ENrsZA==", "1372e8eb-02ac-40fe-96c8-b8c6b5fc9d11" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a694c597-d388-4d75-acc3-897bdb4c4ab1", "AQAAAAIAAYagAAAAEEvX/lNjx5S5DpD2mLYrfeVk4sB0gi7CxFTVOEX3YEjnqFWvK8wMf/8xBk2QIwXIIA==", "ace08f1b-9450-480f-a1b2-b0304c1a02fe" });

            migrationBuilder.CreateIndex(
                name: "IX_Social_UserId",
                table: "Social",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Adress_UserId",
                table: "Adress",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Adress_AspNetUsers_UserId",
                table: "Adress",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Social_AspNetUsers_UserId",
                table: "Social",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
