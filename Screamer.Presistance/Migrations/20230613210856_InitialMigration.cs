using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoverUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Hashtags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hashtags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoodType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adress_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avatar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avatar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avatar_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cover",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cover", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cover_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    SourceUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TargetUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => new { x.SourceUserId, x.TargetUserId });
                    table.ForeignKey(
                        name: "FK_Follows_AspNetUsers_SourceUserId",
                        column: x => x.SourceUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Follows_AspNetUsers_TargetUserId",
                        column: x => x.TargetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SenderUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecipientUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRead = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MessageSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecipientDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Social",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Youtube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tiktok = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Snapchat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pinterest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reddit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Linkedin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Github = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Whatsapp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telegram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Viber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Signal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wechat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Onlyfans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patreon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medium = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tumblr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Social", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Social_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Storys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Views = table.Column<int>(type: "int", nullable: false),
                    StoryImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storys_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    ConnectionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_Connections_Groups_GroupName",
                        column: x => x.GroupName,
                        principalTable: "Groups",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Views = table.Column<int>(type: "int", nullable: false),
                    PostImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoodId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Moods_MoodId",
                        column: x => x.MoodId,
                        principalTable: "Moods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LatestMessageId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatRooms_Messages_LatestMessageId",
                        column: x => x.LatestMessageId,
                        principalTable: "Messages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StoryImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoryImage_Storys_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Storys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookMarks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookMarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookMarks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookMarks_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCommentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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

            migrationBuilder.CreateTable(
                name: "PostHashtags",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    HashtagId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostHashtags", x => new { x.PostId, x.HashtagId });
                    table.ForeignKey(
                        name: "FK_PostHashtags_Hashtags_HashtagId",
                        column: x => x.HashtagId,
                        principalTable: "Hashtags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostHashtags_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostImage_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostMentions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostMentions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostMentions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostMentions_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostReactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostReactions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostReactions_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tags_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatRoomUser",
                columns: table => new
                {
                    ChatroomId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoomUser", x => new { x.ChatroomId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ChatRoomUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatRoomUser_ChatRooms_ChatroomId",
                        column: x => x.ChatroomId,
                        principalTable: "ChatRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentHashtags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    HashtagId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentHashtags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentHashtags_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentHashtags_Hashtags_HashtagId",
                        column: x => x.HashtagId,
                        principalTable: "Hashtags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentMentions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentMentions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentMentions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentMentions_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentReactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentReactions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentReactions_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cac43a6e-f7bb-4448-baaf-1add431ccbbf", null, "Moderator", "MODERATOR" },
                    { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", null, "Administrator", "ADMINISTRATOR" },
                    { "dbc43a8e-f7bb-4445-baaf-1999999999", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "Bio", "Birthday", "ConcurrencyStamp", "CoverUrl", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ObjectID", "Password", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName", "Website" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, null, null, null, "af185007-d3fc-4972-b353-9d8f8f728f01", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", null, "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", null, null, "AQAAAAIAAYagAAAAEDZNeTl2DVnTOA8+5/bict6rFWi0hpKDyPXaq+7natLiqxFfnFyxSzEQSwWeKJpq6g==", null, null, false, "65e2ed74-c5c0-4dd7-aee3-362d7d716032", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", null },
                    { "9e224968-33e4-4652-b7b7-8574d048cdb9", 0, null, null, null, "f4da16bc-5f74-456c-9f7c-6c62b90f2215", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", null, "User", false, null, "USER@LOCALHOST.COM", "USER", null, null, "AQAAAAIAAYagAAAAEJ/jl1VD2v1Khm0XAAgjH+JGeHTZaSu+emf+9OV2HP59i7t897sLEXIwuzpR9GgaIw==", null, null, false, "8c2d0087-fff6-40ba-ad51-224d17d8977e", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user", null },
                    { "9e224968-33e4-4652-b7b7-agfddsr", 0, null, null, null, "283413d5-a5eb-4dac-adf2-e729f6d5d19b", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod@localhost.com", true, "System", null, "Mod", false, null, "MOD@LOCALHOST.COM", "MOD", null, null, "AQAAAAIAAYagAAAAEMzVSHMmTM4b1Cr07ArAailTUXE3pz/Ai0xsKDGn8s0kC+n7rTsuW6p8pJJS7YdmfA==", null, null, false, "bbc7f7c2-bee8-4f74-8639-1b63691866f1", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod", null },
                    { "9e224968-33e4-4652-b7b7-ismailbentabett", 0, null, null, null, "5286b8c6-2c4b-4fd7-a3ba-49de4d5fd8c7", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett@gmail.com", false, "Ismail", null, "Bentabet", false, null, "ISMAILBENTABETT@GMAIL.COM", "ISMAILBENTABETT", null, null, "AQAAAAIAAYagAAAAEPvGnQJQmZ1C5li4QpufAh3rDmxOcFaX7sygagKlxN4B0NtxAOp8g+998WOZj3q/Kg==", null, null, false, "b1cf0e4a-2be4-4aec-9f97-e7755c38cc3b", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(600), "News", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(614) },
                    { 2, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(619), "Politics", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(620) },
                    { 3, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(621), "Science", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(621) },
                    { 4, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(623), "Technology", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(623) },
                    { 5, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(624), "Gaming", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(624) },
                    { 6, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(626), "Sports", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(627) },
                    { 7, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(628), "Music", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(628) },
                    { 8, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(629), "Movies", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(630) },
                    { 9, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(631), "Television", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(631) },
                    { 10, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(633), "Books", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(633) },
                    { 11, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(634), "Art", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(634) },
                    { 12, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(635), "Food", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(636) },
                    { 13, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(637), "Travel", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(637) },
                    { 14, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(643), "Fitness", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(643) },
                    { 15, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(644), "Health", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(648) },
                    { 16, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(662), "Fashion", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(662) },
                    { 17, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(663), "Relationships", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(663) },
                    { 18, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(665), "Advice", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(666) },
                    { 19, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(667), "Writing", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(667) },
                    { 20, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(668), "Photography", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(668) },
                    { 21, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(669), "DIY (Do-It-Yourself)", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(670) },
                    { 22, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(671), "Nature", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(671) },
                    { 23, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(672), "Animals", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(672) },
                    { 24, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(673), "Memes", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(674) },
                    { 25, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(675), "Funny", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(675) },
                    { 26, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(676), "Jokes", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(676) },
                    { 27, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(677), "History", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(678) },
                    { 28, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(679), "Philosophy", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(679) },
                    { 29, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(680), "Psychology", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(680) },
                    { 30, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(681), "Education", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(681) },
                    { 31, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(682), "Career", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(683) },
                    { 32, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(684), "Personal Finance", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(684) },
                    { 33, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(685), "Entrepreneurship", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(685) },
                    { 34, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(687), "Parenting", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(687) },
                    { 35, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(688), "Relationships", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(688) },
                    { 36, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(689), "Technology News", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(690) },
                    { 37, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(691), "Programming", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(691) },
                    { 38, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(692), "Web Development", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(692) },
                    { 39, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(693), "Data Science", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(693) },
                    { 40, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(694), "Cryptocurrency", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(695) },
                    { 41, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(695), "Design", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(696) },
                    { 42, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(697), "Gaming News", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(697) },
                    { 43, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(698), "PC Gaming", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(698) },
                    { 44, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(699), "Console Gaming", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(699) },
                    { 45, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(700), "Mobile Gaming", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(701) },
                    { 46, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(702), "Esports", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(702) },
                    { 47, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(704), "Music News", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(704) },
                    { 48, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(705), "Hip-Hop", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(705) },
                    { 49, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(706), "Rock", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(707) },
                    { 50, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(771), "Pop Culture", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(771) },
                    { 51, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(772), "Fitness Motivation", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(773) },
                    { 52, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(774), "Nutrition", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(774) },
                    { 53, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(775), "Weightlifting", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(775) },
                    { 54, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(776), "Yoga", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(777) },
                    { 55, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(778), "Running", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(778) },
                    { 56, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(779), "Cycling", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(779) },
                    { 57, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(780), "CrossFit", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(781) },
                    { 58, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(782), "Bodybuilding", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(782) },
                    { 59, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(783), "Productivity", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(783) },
                    { 60, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(784), "Self-improvement", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(784) },
                    { 61, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(785), "Meditation", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(786) },
                    { 62, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(787), "Mindfulness", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(787) },
                    { 63, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(788), "Motivation", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(788) },
                    { 64, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(789), "Self-care", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(789) },
                    { 65, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(790), "Cooking", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(791) },
                    { 66, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(793), "Baking", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(793) },
                    { 67, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(794), "Grilling", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(794) },
                    { 68, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(795), "Veganism", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(795) },
                    { 69, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(796), "Vegetarianism", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(797) },
                    { 70, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(798), "Meal Prep", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(798) },
                    { 71, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(799), "Gardening", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(799) },
                    { 72, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(800), "Home Improvement", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(800) },
                    { 73, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(801), "Interior Design", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(802) },
                    { 74, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(802), "Real Estate", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(803) },
                    { 75, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(804), "Personal Finance Tips", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(804) },
                    { 76, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(805), "Investing", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(805) },
                    { 77, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(806), "Stock Market", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(807) },
                    { 78, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(808), "Cryptocurrency Trading", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(808) },
                    { 79, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(809), "Entrepreneur Stories", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(809) },
                    { 80, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(810), "Startups", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(810) },
                    { 81, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(811), "Small Business", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(812) },
                    { 82, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(813), "Marketing", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(813) },
                    { 83, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(814), "Social Media", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(814) },
                    { 84, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(815), "Podcasts", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(815) },
                    { 85, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(817), "Writing Prompts", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(818) },
                    { 86, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(819), "Fantasy", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(819) },
                    { 87, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(820), "Science Fiction", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(821) },
                    { 88, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(822), "Horror", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(822) },
                    { 89, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(823), "Thrillers", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(824) },
                    { 90, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(825), "True Crime", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(825) },
                    { 91, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(826), "Paranormal", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(826) },
                    { 92, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(827), "Comics", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(828) },
                    { 93, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(829), "Anime", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(829) },
                    { 94, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(830), "Manga", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(830) },
                    { 95, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(831), "Board Games", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(831) },
                    { 96, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(832), "Card Games", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(833) },
                    { 97, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(834), "Tabletop RPGs", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(834) },
                    { 98, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(835), "Travel Photography", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(835) },
                    { 99, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(836), "Outdoor Adventures", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(836) },
                    { 100, new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(837), "Celebrities", new DateTime(2023, 6, 13, 22, 8, 55, 562, DateTimeKind.Local).AddTicks(838) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "cac43a6e-f7bb-4448-baaf-1add431ccbbf", "9e224968-33e4-4652-b7b7-8574d048cdb9" },
                    { "dbc43a8e-f7bb-4445-baaf-1999999999", "9e224968-33e4-4652-b7b7-agfddsr" },
                    { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", "9e224968-33e4-4652-b7b7-ismailbentabett" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adress_UserId",
                table: "Adress",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Avatar_UserId",
                table: "Avatar",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookMarks_PostId",
                table: "BookMarks",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_BookMarks_UserId",
                table: "BookMarks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRooms_LatestMessageId",
                table: "ChatRooms",
                column: "LatestMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoomUser_UserId",
                table: "ChatRoomUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentHashtags_CommentId",
                table: "CommentHashtags",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentHashtags_HashtagId",
                table: "CommentHashtags",
                column: "HashtagId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentMentions_CommentId",
                table: "CommentMentions",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentMentions_UserId",
                table: "CommentMentions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReactions_CommentId",
                table: "CommentReactions",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReactions_UserId",
                table: "CommentReactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_GroupName",
                table: "Connections",
                column: "GroupName");

            migrationBuilder.CreateIndex(
                name: "IX_Cover_UserId",
                table: "Cover",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_TargetUserId",
                table: "Follows",
                column: "TargetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_CategoryId",
                table: "PostCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostHashtags_HashtagId",
                table: "PostHashtags",
                column: "HashtagId");

            migrationBuilder.CreateIndex(
                name: "IX_PostImage_PostId",
                table: "PostImage",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostMentions_PostId",
                table: "PostMentions",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostMentions_UserId",
                table: "PostMentions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_PostId",
                table: "PostReactions",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_UserId",
                table: "PostReactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_MoodId",
                table: "Posts",
                column: "MoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Social_UserId",
                table: "Social",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StoryImage_StoryId",
                table: "StoryImage",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Storys_UserId",
                table: "Storys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_PostId",
                table: "Tags",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UserId",
                table: "Tags",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Avatar");

            migrationBuilder.DropTable(
                name: "BookMarks");

            migrationBuilder.DropTable(
                name: "ChatRoomUser");

            migrationBuilder.DropTable(
                name: "CommentHashtags");

            migrationBuilder.DropTable(
                name: "CommentMentions");

            migrationBuilder.DropTable(
                name: "CommentReactions");

            migrationBuilder.DropTable(
                name: "Connections");

            migrationBuilder.DropTable(
                name: "Cover");

            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "PostHashtags");

            migrationBuilder.DropTable(
                name: "PostImage");

            migrationBuilder.DropTable(
                name: "PostMentions");

            migrationBuilder.DropTable(
                name: "PostReactions");

            migrationBuilder.DropTable(
                name: "Social");

            migrationBuilder.DropTable(
                name: "StoryImage");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ChatRooms");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Hashtags");

            migrationBuilder.DropTable(
                name: "Storys");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Moods");
        }
    }
}
