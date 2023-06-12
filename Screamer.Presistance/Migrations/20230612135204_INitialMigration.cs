using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class INitialMigration : Migration
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
                name: "Stories",
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
                    table.PrimaryKey("PK_Stories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stories_AspNetUsers_UserId",
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
                        name: "FK_StoryImage_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, null, null, null, "e899973b-9f53-423d-a183-da9f0b804efa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", null, "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", null, null, "AQAAAAIAAYagAAAAELJbLCjWm1/aIJO0lK3UaECqy4+3YADThzmfwS/q8M+3D+yGuaCvG1j1zj6AJzs8yQ==", null, null, false, "8aa028c3-3957-446c-afc3-713ebbe70903", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", null },
                    { "9e224968-33e4-4652-b7b7-8574d048cdb9", 0, null, null, null, "00db6956-a7f0-4c3e-a028-35171f0f2836", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", null, "User", false, null, "USER@LOCALHOST.COM", "USER", null, null, "AQAAAAIAAYagAAAAEJqjXYiQa2TIbhC9fuILq33sG3TN3WVq+/5kKTIRta1lg67num62KAo6ca7eJbhLdA==", null, null, false, "60563916-70c8-46b5-822e-e670f042725f", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user", null },
                    { "9e224968-33e4-4652-b7b7-agfddsr", 0, null, null, null, "1df9e6e3-ca87-4907-8a52-78704ffdd569", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod@localhost.com", true, "System", null, "Mod", false, null, "MOD@LOCALHOST.COM", "MOD", null, null, "AQAAAAIAAYagAAAAEIw0JycTAbrOJyxO16SMhy9HOwWvWQzFrP31zZJvrgAs972KrWRZDkvMj5a6pGtikg==", null, null, false, "a5cd4b4c-dbf4-47c8-b42c-8fe5b3773e9d", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod", null },
                    { "9e224968-33e4-4652-b7b7-ismailbentabett", 0, null, null, null, "8a609d9c-969a-470b-9fe2-f8f10f224f36", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett@gmail.com", false, "Ismail", null, "Bentabet", false, null, "ISMAILBENTABETT@GMAIL.COM", "ISMAILBENTABETT", null, null, "AQAAAAIAAYagAAAAEATi4VfYbpERhdijIKkq53qufngWYKyVH2mNJBzXJsEKrFDq6epr2dBtFxK+bjiw6Q==", null, null, false, "290ca8d8-4bfd-4209-b542-085612e8a714", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7561), "News", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7581) },
                    { 2, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7588), "Politics", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7589) },
                    { 3, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7592), "Science", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7592) },
                    { 4, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7594), "Technology", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7595) },
                    { 5, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7597), "Gaming", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7597) },
                    { 6, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7602), "Sports", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7603) },
                    { 7, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7605), "Music", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7605) },
                    { 8, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7607), "Movies", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7608) },
                    { 9, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7609), "Television", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7610) },
                    { 10, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7614), "Books", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7614) },
                    { 11, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7616), "Art", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7617) },
                    { 12, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7619), "Food", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7620) },
                    { 13, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7621), "Travel", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7622) },
                    { 14, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7633), "Fitness", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7634) },
                    { 15, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7636), "Health", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7643) },
                    { 16, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7669), "Fashion", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7670) },
                    { 17, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7672), "Relationships", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7673) },
                    { 18, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7676), "Advice", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7677) },
                    { 19, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7679), "Writing", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7679) },
                    { 20, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7681), "Photography", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7682) },
                    { 21, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7684), "DIY (Do-It-Yourself)", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7684) },
                    { 22, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7686), "Nature", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7686) },
                    { 23, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7688), "Animals", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7689) },
                    { 24, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7691), "Memes", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7692) },
                    { 25, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7694), "Funny", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7694) },
                    { 26, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7697), "Jokes", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7698) },
                    { 27, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7700), "History", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7700) },
                    { 28, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7702), "Philosophy", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7703) },
                    { 29, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7704), "Psychology", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7705) },
                    { 30, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7708), "Education", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7709) },
                    { 31, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7711), "Career", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7712) },
                    { 32, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7713), "Personal Finance", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7714) },
                    { 33, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7716), "Entrepreneurship", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7716) },
                    { 34, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7720), "Parenting", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7720) },
                    { 35, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7722), "Relationships", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7723) },
                    { 36, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7725), "Technology News", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7726) },
                    { 37, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7728), "Programming", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7729) },
                    { 38, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7730), "Web Development", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7731) },
                    { 39, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7733), "Data Science", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7734) },
                    { 40, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7735), "Cryptocurrency", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7736) },
                    { 41, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7738), "Design", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7739) },
                    { 42, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7740), "Gaming News", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7741) },
                    { 43, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7743), "PC Gaming", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7743) },
                    { 44, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7745), "Console Gaming", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7746) },
                    { 45, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7748), "Mobile Gaming", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7748) },
                    { 46, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7750), "Esports", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7751) },
                    { 47, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7753), "Music News", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7753) },
                    { 48, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7755), "Hip-Hop", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7756) },
                    { 49, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7757), "Rock", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7758) },
                    { 50, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7760), "Pop Culture", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7761) },
                    { 51, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7762), "Fitness Motivation", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7763) },
                    { 52, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7765), "Nutrition", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7765) },
                    { 53, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7768), "Weightlifting", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7769) },
                    { 54, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7770), "Yoga", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7771) },
                    { 55, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7773), "Running", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7773) },
                    { 56, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7775), "Cycling", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7776) },
                    { 57, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7778), "CrossFit", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7778) },
                    { 58, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7780), "Bodybuilding", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7781) },
                    { 59, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7783), "Productivity", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7783) },
                    { 60, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7785), "Self-improvement", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7786) },
                    { 61, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7788), "Meditation", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7789) },
                    { 62, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7790), "Mindfulness", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7791) },
                    { 63, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7793), "Motivation", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7794) },
                    { 64, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7841), "Self-care", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7841) },
                    { 65, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7843), "Cooking", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7844) },
                    { 66, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7848), "Baking", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7849) },
                    { 67, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7850), "Grilling", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7851) },
                    { 68, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7853), "Veganism", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7854) },
                    { 69, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7856), "Vegetarianism", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7857) },
                    { 70, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7859), "Meal Prep", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7860) },
                    { 71, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7862), "Gardening", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7863) },
                    { 72, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7865), "Home Improvement", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7865) },
                    { 73, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7867), "Interior Design", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7868) },
                    { 74, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7870), "Real Estate", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7871) },
                    { 75, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7873), "Personal Finance Tips", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7874) },
                    { 76, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7876), "Investing", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7876) },
                    { 77, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7879), "Stock Market", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7879) },
                    { 78, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7881), "Cryptocurrency Trading", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7882) },
                    { 79, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7884), "Entrepreneur Stories", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7885) },
                    { 80, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7887), "Startups", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7887) },
                    { 81, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7889), "Small Business", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7890) },
                    { 82, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7892), "Marketing", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7893) },
                    { 83, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7895), "Social Media", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7896) },
                    { 84, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7898), "Podcasts", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7898) },
                    { 85, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7901), "Writing Prompts", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7901) },
                    { 86, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7903), "Fantasy", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7904) },
                    { 87, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7906), "Science Fiction", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7907) },
                    { 88, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7909), "Horror", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7910) },
                    { 89, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7912), "Thrillers", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7913) },
                    { 90, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7914), "True Crime", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7915) },
                    { 91, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7917), "Paranormal", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7918) },
                    { 92, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7919), "Comics", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7920) },
                    { 93, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7922), "Anime", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7923) },
                    { 94, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7925), "Manga", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7926) },
                    { 95, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7928), "Board Games", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7928) },
                    { 96, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7930), "Card Games", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7931) },
                    { 97, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7933), "Tabletop RPGs", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7934) },
                    { 98, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7936), "Travel Photography", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7936) },
                    { 99, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7938), "Outdoor Adventures", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7939) },
                    { 100, new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7941), "Celebrities", new DateTime(2023, 6, 12, 14, 52, 3, 815, DateTimeKind.Local).AddTicks(7942) }
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
                name: "IX_Stories_UserId",
                table: "Stories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryImage_StoryId",
                table: "StoryImage",
                column: "StoryId");

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
                name: "Stories");

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
