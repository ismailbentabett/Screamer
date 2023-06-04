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
                name: "Mentions",
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
                    table.PrimaryKey("PK_Mentions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mentions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mentions_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, null, null, null, "513126a1-4d29-4943-8f05-bf7d240d1f41", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", null, "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", null, null, "AQAAAAIAAYagAAAAELmgc++xkDHAz7saRuVjqPYxiLOFKCGPUn+rFPR5UMWGRBF6CjrrVuMo5i5RXNXIbw==", null, null, false, "b868008a-be26-460a-89dc-15e64d029f21", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", null },
                    { "9e224968-33e4-4652-b7b7-8574d048cdb9", 0, null, null, null, "db993a6e-06ea-4f3b-a721-7437c05232a4", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", null, "User", false, null, "USER@LOCALHOST.COM", "USER", null, null, "AQAAAAIAAYagAAAAEM67tfVnRU2E4sPh/xL5w+H1y50GUMeuZ81yrGgxmX5PANbvdIJkqExT+d8+YKdElQ==", null, null, false, "223ff0b9-d538-4d6b-ad8e-c8853cddf2f4", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user", null },
                    { "9e224968-33e4-4652-b7b7-agfddsr", 0, null, null, null, "ca610314-eb99-45c3-a40f-1fc4fddbaae4", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod@localhost.com", true, "System", null, "Mod", false, null, "MOD@LOCALHOST.COM", "MOD", null, null, "AQAAAAIAAYagAAAAEGu3mougPiC2ssGkZQx/CKBwVldCmHXDRwa9N8O54nvPpbTY5T9O0rlVRtNByYmHcQ==", null, null, false, "fc3f215c-97fd-428d-8871-01d3ebf21c47", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod", null },
                    { "9e224968-33e4-4652-b7b7-ismailbentabett", 0, null, null, null, "73361dca-8597-4061-afe7-d2d2707ca225", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett@gmail.com", true, "Ismail", null, "Bentabet", false, null, "ISMAILBENTABETT@GMAIL.COM", "ISMAILBENTABETT", null, null, "AQAAAAIAAYagAAAAELXjxMchxI8mjViIhIkMYXDgSvSxcjN1XdWA/d69chsW7FqUWlDs7uZVIg9NhEFrWg==", null, null, false, "e422304c-01fe-41e1-aedc-0c6567859a33", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3334), "News", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3346) },
                    { 2, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3351), "Politics", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3351) },
                    { 3, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3353), "Science", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3353) },
                    { 4, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3354), "Technology", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3355) },
                    { 5, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3356), "Gaming", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3356) },
                    { 6, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3358), "Sports", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3359) },
                    { 7, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3359), "Music", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3360) },
                    { 8, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3361), "Movies", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3361) },
                    { 9, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3362), "Television", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3362) },
                    { 10, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3364), "Books", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(3364) },
                    { 11, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4566), "Art", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4568) },
                    { 12, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4570), "Food", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4570) },
                    { 13, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4572), "Travel", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4572) },
                    { 14, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4574), "Fitness", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4574) },
                    { 15, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4577), "Health", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4578) },
                    { 16, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4579), "Fashion", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4579) },
                    { 17, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4580), "Relationships", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4580) },
                    { 18, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4583), "Advice", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4584) },
                    { 19, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4585), "Writing", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4585) },
                    { 20, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4586), "Photography", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4586) },
                    { 21, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4587), "DIY (Do-It-Yourself)", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4587) },
                    { 22, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4588), "Nature", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4588) },
                    { 23, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4589), "Animals", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4589) },
                    { 24, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4590), "Memes", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4590) },
                    { 25, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4591), "Funny", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4592) },
                    { 26, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4592), "Jokes", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4593) },
                    { 27, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4593), "History", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4594) },
                    { 28, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4595), "Philosophy", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4595) },
                    { 29, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4596), "Psychology", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4596) },
                    { 30, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4597), "Education", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4597) },
                    { 31, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4598), "Career", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4598) },
                    { 32, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4599), "Personal Finance", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4600) },
                    { 33, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4600), "Entrepreneurship", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4601) },
                    { 34, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4603), "Parenting", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4603) },
                    { 35, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4604), "Relationships", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4604) },
                    { 36, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4605), "Technology News", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4605) },
                    { 37, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4606), "Programming", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4607) },
                    { 38, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4607), "Web Development", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4608) },
                    { 39, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4608), "Data Science", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4609) },
                    { 40, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4610), "Cryptocurrency", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4610) },
                    { 41, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4611), "Design", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4611) },
                    { 42, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4612), "Gaming News", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4612) },
                    { 43, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4613), "PC Gaming", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4613) },
                    { 44, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4614), "Console Gaming", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4614) },
                    { 45, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4615), "Mobile Gaming", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4615) },
                    { 46, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4616), "Esports", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4617) },
                    { 47, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4617), "Music News", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4618) },
                    { 48, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4618), "Hip-Hop", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4619) },
                    { 49, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4620), "Rock", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4620) },
                    { 50, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4621), "Pop Culture", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4621) },
                    { 51, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4622), "Fitness Motivation", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4622) },
                    { 52, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4623), "Nutrition", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4623) },
                    { 53, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4624), "Weightlifting", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4624) },
                    { 54, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4625), "Yoga", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4625) },
                    { 55, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4626), "Running", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4626) },
                    { 56, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4627), "Cycling", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4627) },
                    { 57, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4628), "CrossFit", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4629) },
                    { 58, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4629), "Bodybuilding", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4630) },
                    { 59, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4630), "Productivity", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4631) },
                    { 60, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4632), "Self-improvement", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4632) },
                    { 61, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4633), "Meditation", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4633) },
                    { 62, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4634), "Mindfulness", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4634) },
                    { 63, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4635), "Motivation", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4635) },
                    { 64, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4636), "Self-care", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4636) },
                    { 65, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4637), "Cooking", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4637) },
                    { 66, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4639), "Baking", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4639) },
                    { 67, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4640), "Grilling", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4640) },
                    { 68, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4641), "Veganism", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4641) },
                    { 69, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4643), "Vegetarianism", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4644) },
                    { 70, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4644), "Meal Prep", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4645) },
                    { 71, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4645), "Gardening", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4646) },
                    { 72, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4647), "Home Improvement", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4647) },
                    { 73, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4648), "Interior Design", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4648) },
                    { 74, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4649), "Real Estate", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4649) },
                    { 75, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4653), "Personal Finance Tips", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4654) },
                    { 76, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4654), "Investing", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4655) },
                    { 77, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4655), "Stock Market", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4656) },
                    { 78, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4657), "Cryptocurrency Trading", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4657) },
                    { 79, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4658), "Entrepreneur Stories", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4658) },
                    { 80, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4659), "Startups", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4659) },
                    { 81, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4660), "Small Business", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4660) },
                    { 82, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4661), "Marketing", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(4661) },
                    { 83, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5427), "Social Media", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5429) },
                    { 84, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5431), "Podcasts", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5431) },
                    { 85, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5433), "Writing Prompts", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5433) },
                    { 86, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5500), "Fantasy", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5500) },
                    { 87, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5502), "Science Fiction", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5502) },
                    { 88, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5503), "Horror", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5503) },
                    { 89, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5504), "Thrillers", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5505) },
                    { 90, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5506), "True Crime", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5506) },
                    { 91, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5507), "Paranormal", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5507) },
                    { 92, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5508), "Comics", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5508) },
                    { 93, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5509), "Anime", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5509) },
                    { 94, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5510), "Manga", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5510) },
                    { 95, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5511), "Board Games", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5512) },
                    { 96, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5512), "Card Games", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5513) },
                    { 97, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5513), "Tabletop RPGs", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5514) },
                    { 98, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5515), "Travel Photography", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5515) },
                    { 99, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5516), "Outdoor Adventures", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5516) },
                    { 100, new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5517), "Celebrities", new DateTime(2023, 6, 4, 14, 19, 42, 775, DateTimeKind.Local).AddTicks(5517) }
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
                name: "IX_Mentions_PostId",
                table: "Mentions",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Mentions_UserId",
                table: "Mentions",
                column: "UserId");

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
                name: "CommentReactions");

            migrationBuilder.DropTable(
                name: "Connections");

            migrationBuilder.DropTable(
                name: "Cover");

            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropTable(
                name: "Mentions");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "PostHashtags");

            migrationBuilder.DropTable(
                name: "PostImage");

            migrationBuilder.DropTable(
                name: "PostReactions");

            migrationBuilder.DropTable(
                name: "Social");

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
