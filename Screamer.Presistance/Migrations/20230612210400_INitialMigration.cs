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
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, null, null, null, "eda86826-8f1b-4b6d-8017-a1ba15bcc4c5", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", null, "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", null, null, "AQAAAAIAAYagAAAAEC9IJYaGa0HAXJBxGRFlY/gPmbNsbCowVw4yAJUiJfdLZT3mtlYe7wQ+D2luBcS0Fg==", null, null, false, "130f4174-c871-4631-a3b7-188cf2f846ed", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", null },
                    { "9e224968-33e4-4652-b7b7-8574d048cdb9", 0, null, null, null, "48561fbb-06dd-41d0-b368-4be03f82d4d0", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", null, "User", false, null, "USER@LOCALHOST.COM", "USER", null, null, "AQAAAAIAAYagAAAAEERfAJKt1WrVRXbtJLfL7WHK2qrq09gmEw+uG7xeVhWSNYnKAIvAI20Icl5f1JsSaA==", null, null, false, "672cc3ea-179a-4d7c-8d24-8d75c8ed736e", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user", null },
                    { "9e224968-33e4-4652-b7b7-agfddsr", 0, null, null, null, "ee251eb4-b769-405f-924f-59a414f6e870", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod@localhost.com", true, "System", null, "Mod", false, null, "MOD@LOCALHOST.COM", "MOD", null, null, "AQAAAAIAAYagAAAAELDVHDzAAmUr5ECjDMWHgZBZHSefjBqrOVqN52qpCoTn40kPjAeuAIh5m3rIisi03g==", null, null, false, "864d0f46-92ad-4e1f-853f-7d17bc2b6f18", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod", null },
                    { "9e224968-33e4-4652-b7b7-ismailbentabett", 0, null, null, null, "53c0dcc1-45eb-4e51-9bd9-48d612aeb18d", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett@gmail.com", false, "Ismail", null, "Bentabet", false, null, "ISMAILBENTABETT@GMAIL.COM", "ISMAILBENTABETT", null, null, "AQAAAAIAAYagAAAAEMHOl9+/+K9jtqELNpD9RWbSqj81Ki6A21lsMLmx/OZ8w7GxmEjZORcMTikrcMPPrA==", null, null, false, "65f215fb-abae-4ba3-85e7-b8cb1c4a4984", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1660), "News", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1679) },
                    { 2, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1683), "Politics", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1683) },
                    { 3, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1685), "Science", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1685) },
                    { 4, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1686), "Technology", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1687) },
                    { 5, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1688), "Gaming", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1688) },
                    { 6, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1690), "Sports", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1691) },
                    { 7, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1692), "Music", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1692) },
                    { 8, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1693), "Movies", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1693) },
                    { 9, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1695), "Television", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1695) },
                    { 10, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1697), "Books", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1697) },
                    { 11, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1698), "Art", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1699) },
                    { 12, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1699), "Food", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1700) },
                    { 13, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1701), "Travel", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1701) },
                    { 14, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1708), "Fitness", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1708) },
                    { 15, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1709), "Health", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1749) },
                    { 16, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1768), "Fashion", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1769) },
                    { 17, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1770), "Relationships", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1770) },
                    { 18, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1772), "Advice", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1773) },
                    { 19, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1774), "Writing", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1775) },
                    { 20, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1775), "Photography", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1776) },
                    { 21, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1777), "DIY (Do-It-Yourself)", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1777) },
                    { 22, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1778), "Nature", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1778) },
                    { 23, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1779), "Animals", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1779) },
                    { 24, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1780), "Memes", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1780) },
                    { 25, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1781), "Funny", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1782) },
                    { 26, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1782), "Jokes", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1783) },
                    { 27, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1784), "History", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1784) },
                    { 28, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1785), "Philosophy", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1785) },
                    { 29, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1786), "Psychology", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1786) },
                    { 30, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1787), "Education", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1787) },
                    { 31, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1788), "Career", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1789) },
                    { 32, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1789), "Personal Finance", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1790) },
                    { 33, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1790), "Entrepreneurship", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1791) },
                    { 34, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1793), "Parenting", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1793) },
                    { 35, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1794), "Relationships", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1794) },
                    { 36, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1795), "Technology News", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1795) },
                    { 37, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1796), "Programming", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1796) },
                    { 38, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1797), "Web Development", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1798) },
                    { 39, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1799), "Data Science", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1799) },
                    { 40, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1800), "Cryptocurrency", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1800) },
                    { 41, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1801), "Design", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1801) },
                    { 42, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1802), "Gaming News", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1802) },
                    { 43, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1803), "PC Gaming", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1803) },
                    { 44, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1804), "Console Gaming", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1805) },
                    { 45, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1806), "Mobile Gaming", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1806) },
                    { 46, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1807), "Esports", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1807) },
                    { 47, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1809), "Music News", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1809) },
                    { 48, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1810), "Hip-Hop", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1811) },
                    { 49, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1811), "Rock", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1812) },
                    { 50, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1813), "Pop Culture", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1813) },
                    { 51, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1814), "Fitness Motivation", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1814) },
                    { 52, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1815), "Nutrition", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1815) },
                    { 53, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1816), "Weightlifting", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1816) },
                    { 54, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1817), "Yoga", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1818) },
                    { 55, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1818), "Running", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1819) },
                    { 56, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1847), "Cycling", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1848) },
                    { 57, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1849), "CrossFit", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1849) },
                    { 58, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1850), "Bodybuilding", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1850) },
                    { 59, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1851), "Productivity", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1852) },
                    { 60, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1852), "Self-improvement", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1853) },
                    { 61, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1854), "Meditation", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1854) },
                    { 62, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1855), "Mindfulness", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1855) },
                    { 63, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1856), "Motivation", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1857) },
                    { 64, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1858), "Self-care", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1858) },
                    { 65, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1859), "Cooking", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1859) },
                    { 66, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1861), "Baking", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1861) },
                    { 67, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1862), "Grilling", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1862) },
                    { 68, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1863), "Veganism", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1863) },
                    { 69, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1864), "Vegetarianism", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1864) },
                    { 70, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1865), "Meal Prep", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1866) },
                    { 71, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1867), "Gardening", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1867) },
                    { 72, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1868), "Home Improvement", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1868) },
                    { 73, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1869), "Interior Design", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1869) },
                    { 74, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1870), "Real Estate", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1871) },
                    { 75, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1871), "Personal Finance Tips", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1872) },
                    { 76, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1873), "Investing", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1873) },
                    { 77, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1874), "Stock Market", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1874) },
                    { 78, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1875), "Cryptocurrency Trading", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1875) },
                    { 79, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1876), "Entrepreneur Stories", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1876) },
                    { 80, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1877), "Startups", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1878) },
                    { 81, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1878), "Small Business", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1879) },
                    { 82, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1880), "Marketing", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1880) },
                    { 83, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1881), "Social Media", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1881) },
                    { 84, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1882), "Podcasts", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1882) },
                    { 85, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1884), "Writing Prompts", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1885) },
                    { 86, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1886), "Fantasy", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1886) },
                    { 87, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1887), "Science Fiction", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1887) },
                    { 88, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1888), "Horror", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1888) },
                    { 89, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1889), "Thrillers", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1889) },
                    { 90, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1890), "True Crime", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1891) },
                    { 91, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1891), "Paranormal", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1892) },
                    { 92, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1893), "Comics", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1893) },
                    { 93, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1894), "Anime", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1894) },
                    { 94, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1895), "Manga", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1895) },
                    { 95, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1896), "Board Games", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1897) },
                    { 96, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1898), "Card Games", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1898) },
                    { 97, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1899), "Tabletop RPGs", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1899) },
                    { 98, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1900), "Travel Photography", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1900) },
                    { 99, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1901), "Outdoor Adventures", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1901) },
                    { 100, new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1902), "Celebrities", new DateTime(2023, 6, 12, 22, 4, 0, 256, DateTimeKind.Local).AddTicks(1902) }
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
