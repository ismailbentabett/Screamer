using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "32804ef4-4ce8-4657-a55e-d9f345f2b506", "ADMIN", "AQAAAAIAAYagAAAAEK2cxX9pWPSsMoDGhM+X4EafgynDI1JU1CkSJDfJ/lWmyVC5p7pLFiUzXuBanvmwwg==", "75f45a24-8c44-4d14-855d-88ca79db08b9", "admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "6d5515b0-8030-46b0-90c1-aada9f032f61", "USER", "AQAAAAIAAYagAAAAEF+BBnitBMbVfqmc/JcgIIpZeaBOvjHevr71+14vWTbPL2dpASSJ5FCQqEWt79yt9g==", "3911dd14-c502-423f-8880-ba499f956cba", "user" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "198c2396-365a-4a25-bd6e-16f7e20a2ad1", "MOD", "AQAAAAIAAYagAAAAEL9ed0WCAm1wSrCEZW16/YZs4RES+ccu4vIrbGO2FOjhdHsqG0biZpPP7kbzNStimg==", "eb8d3112-dd55-436a-a042-1474044d9c92", "mod" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "Bio", "Birthday", "ConcurrencyStamp", "CoverUrl", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ObjectID", "Password", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName", "Website" },
                values: new object[] { "9e224968-33e4-4652-b7b7-ismailbentabett", 0, null, null, null, "dd913ae7-2169-480b-a783-569227b666ff", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett@gmail.com", true, "Ismail", null, "Bentabet", false, null, "ISMAILBENTABETT@GMAIL.COM", "ISMAILBENTABETT", null, null, "AQAAAAIAAYagAAAAEBHTxPiCt7YbWLMNp5WvNUOZrCQl+JVDTHj/9ssmkwFan38XJ4dD91Fdqy/dDGBTIQ==", null, null, false, "98ae6ac2-d9e6-4641-8086-ea82af2f8d0d", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", "9e224968-33e4-4652-b7b7-ismailbentabett" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", "9e224968-33e4-4652-b7b7-ismailbentabett" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-ismailbentabett");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b08897d6-09be-47af-8839-84a02bb081c8", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEMyewGAonAsqI6FtaEl2FBGrbcjmcJ1t028ZOFu7CObfFy+RVbKFESgW38A2G7LxhQ==", "d6288da9-d8ce-45ae-83d4-e873fdba592a", "admin@localhost.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ca187e53-7f84-4aa1-9442-b3f640bd19ce", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEFyUKX7atnS3BQD9qGveduPwdTow0k7ITPFRjYprD/rA74aT4ngU9MjcxmKLLUllJg==", "849ab462-d893-4391-a74a-5ef986538647", "user@localhost.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b3683c44-a248-4d1a-ab68-dacb69fa06ba", "MOD@LOCALHOST.COM", "AQAAAAIAAYagAAAAEPblDC1vZJ2cLs9yOD+kv3BgY4FpLKfCBAOUaa4PmFHRDwfnNmldVLHNXno5Ah1XpQ==", "7eeaec9a-3a59-4b12-85ad-133ce25643b1", "mod@localhost.com" });
        }
    }
}
