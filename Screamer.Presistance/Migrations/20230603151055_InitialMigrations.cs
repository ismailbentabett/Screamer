using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
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
                    MoodId = table.Column<int>(type: "int", nullable: true),
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
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, null, null, null, "df2f9169-d313-4792-a7c4-3d9f6d12f42b", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", null, "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", null, null, "AQAAAAIAAYagAAAAEDr5ycnneAxSTIBwkTKQhOEH6AscbSyKNCbP7oHI3AKa+u1TLc8EQQ4PgVsgGPNuvg==", null, null, false, "2e7972a7-0702-4228-b63c-bf14121c116a", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", null },
                    { "9e224968-33e4-4652-b7b7-8574d048cdb9", 0, null, null, null, "8234cbac-2492-44be-8f32-37f5ffdd1aac", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", null, "User", false, null, "USER@LOCALHOST.COM", "USER", null, null, "AQAAAAIAAYagAAAAEND38hB0ggzK5irvV5np0NHC7thjm9QK9S4OZ0FJ3WV9wlRK7F+l4X5uadx6na75HQ==", null, null, false, "a757cb7f-1f44-43fd-a0d9-aee8a0d054ac", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user", null },
                    { "9e224968-33e4-4652-b7b7-agfddsr", 0, null, null, null, "75e2b341-169d-4708-9940-063bace54697", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod@localhost.com", true, "System", null, "Mod", false, null, "MOD@LOCALHOST.COM", "MOD", null, null, "AQAAAAIAAYagAAAAEP2ag3Og/BtFG5WlRjMMoh+GnxHimpXtikSUY2yIi9RS5mu2CrhCLaK8Qhd3iQiYpg==", null, null, false, "eb488147-8d26-4acc-a1f8-30951e65b02d", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod", null },
                    { "9e224968-33e4-4652-b7b7-ismailbentabett", 0, null, null, null, "fc435592-fdee-4d3f-82dc-2b321e326148", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett@gmail.com", true, "Ismail", null, "Bentabet", false, null, "ISMAILBENTABETT@GMAIL.COM", "ISMAILBENTABETT", null, null, "AQAAAAIAAYagAAAAEJ6Mr9gtMhXwjXzli8If58Oflg+yNlsUPHYrVMcpXIzPrVL/e5SdH/zNgw2C6HkNEw==", null, null, false, "0098d806-cbc5-42de-979b-e87f408bece4", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(700), "News", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(738) },
                    { 2, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(826), "Politics", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(826) },
                    { 3, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(827), "Science", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(833) },
                    { 4, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(834), "Technology", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(836) },
                    { 5, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(837), "Gaming", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(856) },
                    { 6, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(867), "Sports", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(867) },
                    { 7, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(868), "Music", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(869) },
                    { 8, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(869), "Movies", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(870) },
                    { 9, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(871), "Television", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(872) },
                    { 10, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(874), "Books", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(874) },
                    { 11, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(875), "Art", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(875) },
                    { 12, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(877), "Food", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(877) },
                    { 13, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(878), "Travel", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(879) },
                    { 14, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1053), "Fitness", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1053) },
                    { 15, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1054), "Health", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1062) },
                    { 16, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1078), "Fashion", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1079) },
                    { 17, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1079), "Relationships", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1080) },
                    { 18, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1082), "Advice", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1082) },
                    { 19, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1083), "Writing", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1083) },
                    { 20, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1084), "Photography", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1084) },
                    { 21, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1085), "DIY (Do-It-Yourself)", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1086) },
                    { 22, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1086), "Nature", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1087) },
                    { 23, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1088), "Animals", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1088) },
                    { 24, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1089), "Memes", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1089) },
                    { 25, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1090), "Funny", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1090) },
                    { 26, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1091), "Jokes", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1092) },
                    { 27, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1092), "History", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1093) },
                    { 28, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1094), "Philosophy", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1094) },
                    { 29, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1095), "Psychology", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1095) },
                    { 30, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1096), "Education", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1096) },
                    { 31, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1097), "Career", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1098) },
                    { 32, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1098), "Personal Finance", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1099) },
                    { 33, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1100), "Entrepreneurship", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1100) },
                    { 34, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1137), "Parenting", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1138) },
                    { 35, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1139), "Relationships", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1139) },
                    { 36, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1140), "Technology News", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1140) },
                    { 37, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1141), "Programming", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1142) },
                    { 38, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1143), "Web Development", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1143) },
                    { 39, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1144), "Data Science", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1144) },
                    { 40, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1145), "Cryptocurrency", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1145) },
                    { 41, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1146), "Design", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1146) },
                    { 42, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1147), "Gaming News", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1148) },
                    { 43, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1149), "PC Gaming", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1149) },
                    { 44, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1150), "Console Gaming", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1150) },
                    { 45, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1151), "Mobile Gaming", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1151) },
                    { 46, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1152), "Esports", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1152) },
                    { 47, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1153), "Music News", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1154) },
                    { 48, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1155), "Hip-Hop", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1155) },
                    { 49, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1156), "Rock", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1156) },
                    { 50, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1158), "Pop Culture", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1158) },
                    { 51, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1159), "Fitness Motivation", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1160) },
                    { 52, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1160), "Nutrition", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1161) },
                    { 53, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1162), "Weightlifting", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1162) },
                    { 54, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1163), "Yoga", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1163) },
                    { 55, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1164), "Running", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1164) },
                    { 56, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1165), "Cycling", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1165) },
                    { 57, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1166), "CrossFit", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1167) },
                    { 58, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1168), "Bodybuilding", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1168) },
                    { 59, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1169), "Productivity", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1169) },
                    { 60, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1170), "Self-improvement", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1170) },
                    { 61, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1171), "Meditation", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1171) },
                    { 62, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1172), "Mindfulness", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1173) },
                    { 63, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1173), "Motivation", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1174) },
                    { 64, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1175), "Self-care", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1175) },
                    { 65, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1176), "Cooking", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1176) },
                    { 66, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1178), "Baking", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1178) },
                    { 67, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1179), "Grilling", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1180) },
                    { 68, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1181), "Veganism", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1181) },
                    { 69, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1182), "Vegetarianism", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1182) },
                    { 70, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1183), "Meal Prep", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1183) },
                    { 71, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1184), "Gardening", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1184) },
                    { 72, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1185), "Home Improvement", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1186) },
                    { 73, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1186), "Interior Design", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1187) },
                    { 74, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1188), "Real Estate", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1188) },
                    { 75, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1189), "Personal Finance Tips", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1189) },
                    { 76, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1190), "Investing", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1190) },
                    { 77, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1191), "Stock Market", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1192) },
                    { 78, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1192), "Cryptocurrency Trading", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1193) },
                    { 79, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1194), "Entrepreneur Stories", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1194) },
                    { 80, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1195), "Startups", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1195) },
                    { 81, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1196), "Small Business", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1196) },
                    { 82, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1197), "Marketing", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1198) },
                    { 83, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1198), "Social Media", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1199) },
                    { 84, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1200), "Podcasts", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1200) },
                    { 85, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1201), "Writing Prompts", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1201) },
                    { 86, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1202), "Fantasy", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1202) },
                    { 87, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1203), "Science Fiction", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1203) },
                    { 88, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1205), "Horror", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1205) },
                    { 89, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1206), "Thrillers", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1207) },
                    { 90, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1208), "True Crime", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1208) },
                    { 91, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1209), "Paranormal", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1209) },
                    { 92, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1210), "Comics", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1210) },
                    { 93, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1211), "Anime", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1211) },
                    { 94, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1212), "Manga", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1212) },
                    { 95, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1213), "Board Games", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1214) },
                    { 96, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1215), "Card Games", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1215) },
                    { 97, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1216), "Tabletop RPGs", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1216) },
                    { 98, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1217), "Travel Photography", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1217) },
                    { 99, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1218), "Outdoor Adventures", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1218) },
                    { 100, new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1219), "Celebrities", new DateTime(2023, 6, 3, 16, 10, 55, 166, DateTimeKind.Local).AddTicks(1219) }
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
