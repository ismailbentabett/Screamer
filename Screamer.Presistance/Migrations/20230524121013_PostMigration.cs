using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class PostMigration : Migration
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
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => new { x.PostId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PostCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCategories_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c60c32a7-1b22-4191-91cc-9e301a427cb5", "AQAAAAIAAYagAAAAEP08V6hDfjBdbW5/B8asja+gvzItCX9zd+kqjPltd8+SkFpwSXcdlW9I3ZPnwepljQ==", "1921d0e0-58ee-498a-bc14-e043a536916e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "293e5548-1840-4481-9726-aaaec4f7bae9", "AQAAAAIAAYagAAAAENYaJClPUWII0WuQt0fOagV3IrV1ntyXU4R6j3cMzvgPOfawstTkQCZLCDjG0Tz8+g==", "bf9ce030-7b07-4bf0-a120-353a06afe631" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "221c2fe0-c1be-4fce-9a20-dbf230ef099a", "AQAAAAIAAYagAAAAENKx9riHLt9yAgQXMdfa3zU2KKDdcKPtYS4wSAwwHXI5EqscWsEING0IkEtbtJrF7g==", "75f77a25-116b-472d-ad44-b1723cc314d7" });

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_CategoryId",
                table: "PostCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_Messages_LatestMessageId",
                table: "ChatRooms",
                column: "LatestMessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_Messages_LatestMessageId",
                table: "ChatRooms");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "Categories");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_Messages_LatestMessageId",
                table: "ChatRooms",
                column: "LatestMessageId",
                principalTable: "Messages",
                principalColumn: "Id");
        }
    }
}
