using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationss2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28b8930d-18f5-43c4-9eea-95b20f8c70e5", "AQAAAAIAAYagAAAAEHjd5yV6UYuDCxRvzBHA7aPEd3nP4kjne2RnV1IVQspb02UPHisOKhv5O5uUKhxl5Q==", "ade6f055-ac67-483b-ae5a-23d82ff027a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "057ff207-96c5-48fb-b111-40dff5c22ad5", "AQAAAAIAAYagAAAAEIDx1IbgHWrh1U8LF7j2Q7yTpAmg8pofclQndYzB752CFt73nAMTdEaovcKrfIiMDQ==", "818b9679-3fe6-443c-a9b3-12caeae06f9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a120e46f-cf08-4abd-a14a-b71f2dc9d848", "AQAAAAIAAYagAAAAEMR44Hv5Kgh5zADwP18pfgz3aSkI/Hx34LWTNr8F73446F2W423OoNTBXriNgnU7Tw==", "c245d8b4-fc59-44fc-9b31-262088b3adf7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-ismailbentabett",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3306d94d-a956-4cf5-98e8-3dfce0f97ace", "AQAAAAIAAYagAAAAEG5PQQSNQ8aCmJsSHB9FbUFUDT5qpJ8y35Y48Y7SzC5qdF8EvYG0+7FtffflLWyvag==", "0c40ecb6-d72e-41da-b958-8a2b5a105ca9" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2797), "News", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2818) },
                    { 2, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2823), "Politics", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2824) },
                    { 3, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2825), "Science", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2825) },
                    { 4, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2827), "Technology", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2827) },
                    { 5, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2828), "Gaming", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2828) },
                    { 6, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2865), "Sports", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2866) },
                    { 7, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2867), "Music", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2867) },
                    { 8, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2868), "Movies", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2868) },
                    { 9, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2869), "Television", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2869) },
                    { 10, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2872), "Books", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2872) },
                    { 11, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2873), "Art", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2873) },
                    { 12, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2874), "Food", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2875) },
                    { 13, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2875), "Travel", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2876) },
                    { 14, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2883), "Fitness", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2883) },
                    { 15, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2884), "Health", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2896) },
                    { 16, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2916), "Fashion", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2917) },
                    { 17, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2917), "Relationships", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2918) },
                    { 18, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2920), "Advice", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2920) },
                    { 19, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2921), "Writing", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2921) },
                    { 20, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2922), "Photography", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2922) },
                    { 21, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2923), "DIY (Do-It-Yourself)", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2923) },
                    { 22, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2924), "Nature", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2925) },
                    { 23, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2926), "Animals", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2926) },
                    { 24, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2927), "Memes", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2927) },
                    { 25, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2928), "Funny", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2928) },
                    { 26, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2929), "Jokes", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2929) },
                    { 27, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2930), "History", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2931) },
                    { 28, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2931), "Philosophy", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2932) },
                    { 29, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2933), "Psychology", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2933) },
                    { 30, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2934), "Education", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2934) },
                    { 31, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2935), "Career", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2935) },
                    { 32, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2936), "Personal Finance", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2936) },
                    { 33, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2937), "Entrepreneurship", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2937) },
                    { 34, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2939), "Parenting", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2940) },
                    { 35, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2940), "Relationships", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2941) },
                    { 36, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2942), "Technology News", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2942) },
                    { 37, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2943), "Programming", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2943) },
                    { 38, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2944), "Web Development", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2944) },
                    { 39, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2945), "Data Science", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2945) },
                    { 40, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2946), "Cryptocurrency", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2946) },
                    { 41, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2947), "Design", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2948) },
                    { 42, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2948), "Gaming News", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2949) },
                    { 43, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2950), "PC Gaming", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2950) },
                    { 44, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2951), "Console Gaming", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2951) },
                    { 45, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2952), "Mobile Gaming", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2953) },
                    { 46, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2953), "Esports", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2954) },
                    { 47, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2955), "Music News", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2955) },
                    { 48, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2956), "Hip-Hop", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2956) },
                    { 49, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2957), "Rock", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2957) },
                    { 50, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2958), "Pop Culture", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2958) },
                    { 51, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2959), "Fitness Motivation", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2960) },
                    { 52, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2960), "Nutrition", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2961) },
                    { 53, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2961), "Weightlifting", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2962) },
                    { 54, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2963), "Yoga", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2963) },
                    { 55, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2964), "Running", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2964) },
                    { 56, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2965), "Cycling", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2965) },
                    { 57, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2966), "CrossFit", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2966) },
                    { 58, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2967), "Bodybuilding", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2968) },
                    { 59, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2970), "Productivity", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2970) },
                    { 60, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2971), "Self-improvement", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2971) },
                    { 61, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2972), "Meditation", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2972) },
                    { 62, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2973), "Mindfulness", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2973) },
                    { 63, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2974), "Motivation", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2975) },
                    { 64, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2975), "Self-care", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2976) },
                    { 65, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2977), "Cooking", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2977) },
                    { 66, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2979), "Baking", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2979) },
                    { 67, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2980), "Grilling", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2980) },
                    { 68, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2981), "Veganism", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2981) },
                    { 69, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2982), "Vegetarianism", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2982) },
                    { 70, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2983), "Meal Prep", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2983) },
                    { 71, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2984), "Gardening", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(2985) },
                    { 72, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3026), "Home Improvement", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3026) },
                    { 73, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3234), "Interior Design", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3234) },
                    { 74, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3235), "Real Estate", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3235) },
                    { 75, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3423), "Personal Finance Tips", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3424) },
                    { 76, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3425), "Investing", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3425) },
                    { 77, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3426), "Stock Market", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3426) },
                    { 78, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3427), "Cryptocurrency Trading", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3428) },
                    { 79, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3429), "Entrepreneur Stories", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3429) },
                    { 80, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3430), "Startups", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3430) },
                    { 81, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3431), "Small Business", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3431) },
                    { 82, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3432), "Marketing", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3433) },
                    { 83, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3434), "Social Media", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3435) },
                    { 84, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3436), "Podcasts", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3436) },
                    { 85, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3437), "Writing Prompts", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3437) },
                    { 86, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3438), "Fantasy", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3438) },
                    { 87, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3439), "Science Fiction", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3440) },
                    { 88, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3441), "Horror", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3441) },
                    { 89, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3442), "Thrillers", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3442) },
                    { 90, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3443), "True Crime", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3443) },
                    { 91, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3444), "Paranormal", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3444) },
                    { 92, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3445), "Comics", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3446) },
                    { 93, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3447), "Anime", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3447) },
                    { 94, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3448), "Manga", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3448) },
                    { 95, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3449), "Board Games", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3449) },
                    { 96, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3450), "Card Games", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3450) },
                    { 97, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3452), "Tabletop RPGs", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3452) },
                    { 98, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3453), "Travel Photography", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3453) },
                    { 99, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3454), "Outdoor Adventures", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3455) },
                    { 100, new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3455), "Celebrities", new DateTime(2023, 6, 3, 11, 8, 6, 374, DateTimeKind.Local).AddTicks(3456) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32804ef4-4ce8-4657-a55e-d9f345f2b506", "AQAAAAIAAYagAAAAEK2cxX9pWPSsMoDGhM+X4EafgynDI1JU1CkSJDfJ/lWmyVC5p7pLFiUzXuBanvmwwg==", "75f45a24-8c44-4d14-855d-88ca79db08b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d5515b0-8030-46b0-90c1-aada9f032f61", "AQAAAAIAAYagAAAAEF+BBnitBMbVfqmc/JcgIIpZeaBOvjHevr71+14vWTbPL2dpASSJ5FCQqEWt79yt9g==", "3911dd14-c502-423f-8880-ba499f956cba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-agfddsr",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "198c2396-365a-4a25-bd6e-16f7e20a2ad1", "AQAAAAIAAYagAAAAEL9ed0WCAm1wSrCEZW16/YZs4RES+ccu4vIrbGO2FOjhdHsqG0biZpPP7kbzNStimg==", "eb8d3112-dd55-436a-a042-1474044d9c92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-ismailbentabett",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd913ae7-2169-480b-a783-569227b666ff", "AQAAAAIAAYagAAAAEBHTxPiCt7YbWLMNp5WvNUOZrCQl+JVDTHj/9ssmkwFan38XJ4dD91Fdqy/dDGBTIQ==", "98ae6ac2-d9e6-4641-8086-ea82af2f8d0d" });
        }
    }
}
