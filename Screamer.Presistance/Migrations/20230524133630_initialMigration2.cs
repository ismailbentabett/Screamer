using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategories_Categories_CategoryId",
                table: "PostCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PostCategories_Posts_PostId",
                table: "PostCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCategories",
                table: "PostCategories");

            migrationBuilder.RenameTable(
                name: "PostCategories",
                newName: "PostCategory");

            migrationBuilder.RenameIndex(
                name: "IX_PostCategories_CategoryId",
                table: "PostCategory",
                newName: "IX_PostCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCategory",
                table: "PostCategory",
                columns: new[] { "PostId", "CategoryId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ed96493-59f8-4390-a216-015b1f192984", "AQAAAAIAAYagAAAAEPqI356N6nbbtQ9rHkUXqHMJS5Vi5gkWtzhzElh0kMoi2mZe5ML3HINRqqSrgWS0dg==", "af6c3eee-417a-48cf-9267-44e313ea6963" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d2cc93a-e90f-4e24-a662-2e9bf446f865", "AQAAAAIAAYagAAAAEFJb4k3qrRQ/CC79fsZeDI9bL3Bf2TEIHUUJ6Hj+EKrBnhVlUGsNmkCvcFshNT++aQ==", "85fc0006-42db-49c9-b277-54ed72b8cc02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83b48d46-15b8-416c-8b35-22b6f3f87b39", "AQAAAAIAAYagAAAAEDK43EmGuhqRqanRGIaWtSDlvKcEglWcMv0MtTfk9XRynvHNVWAYN5CKudtjyrjvow==", "4a198fb7-3bc6-4be5-951e-531e20d3f3b0" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategory_Categories_CategoryId",
                table: "PostCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategory_Posts_PostId",
                table: "PostCategory",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategory_Categories_CategoryId",
                table: "PostCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_PostCategory_Posts_PostId",
                table: "PostCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCategory",
                table: "PostCategory");

            migrationBuilder.RenameTable(
                name: "PostCategory",
                newName: "PostCategories");

            migrationBuilder.RenameIndex(
                name: "IX_PostCategory_CategoryId",
                table: "PostCategories",
                newName: "IX_PostCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCategories",
                table: "PostCategories",
                columns: new[] { "PostId", "CategoryId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43d62e4e-8b12-40ca-8161-64018f8d88c9", "AQAAAAIAAYagAAAAEDojqOKSBgwyvYAeeMfU3OCDjQpJsBVAZH49jvKIDZeG/OBKCdcy8fM4dX+yq7Rs5g==", "4ef61562-3f70-47a2-9fe5-3589bd83d396" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a50de815-7976-4310-83f0-4083050d0c57", "AQAAAAIAAYagAAAAEL3VDpRpwGQnSavE5dJCYvjuDA5SIDSGAV0Z/TzOTV1v+jvYT//sdscNmxjGiN3/UA==", "0337c66d-e34d-43b1-ba83-8c66884fe6c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a072e827-8136-4ce3-b9e0-c6fc85a13e9c", "AQAAAAIAAYagAAAAEGDn3MSfHPk6LUe2hr/GvsqwPagKFzyTBG9+Kh97UoXp4E37uhMXXR4wE7QuOA/kpQ==", "845db48d-2a42-426b-bccd-412bc1e86d3b" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategories_Categories_CategoryId",
                table: "PostCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategories_Posts_PostId",
                table: "PostCategories",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
