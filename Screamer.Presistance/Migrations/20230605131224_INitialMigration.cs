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
                name: "CommentHashtag",
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
                    table.PrimaryKey("PK_CommentHashtag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentHashtag_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentHashtag_Hashtags_HashtagId",
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
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, null, null, null, "36694bb3-2fdd-4d9d-9add-4d7731dcaeb1", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", null, "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", null, null, "AQAAAAIAAYagAAAAEJVJB0jAsbPvRGTAwZdK5lcNKgEjJzng2GU0Vo2qGXwxRb/i6hWxO5ZiscO/nmxH3g==", null, null, false, "15348b44-20b7-48ec-abc9-9b7883d50450", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", null },
                    { "9e224968-33e4-4652-b7b7-8574d048cdb9", 0, null, null, null, "4f5a5691-0a51-465f-abab-2cbe0b2de990", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", null, "User", false, null, "USER@LOCALHOST.COM", "USER", null, null, "AQAAAAIAAYagAAAAEA3Fq8OnRPqEoLnXTEVEiQp1DD6o2UVad5CXiGQHVhm8e/4M7B/0iQHgIVWmEBOovQ==", null, null, false, "8ea9682f-dcef-46a7-8471-48058c11b18b", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user", null },
                    { "9e224968-33e4-4652-b7b7-agfddsr", 0, null, null, null, "75249d73-c391-4470-9f9e-b25ee6dc8424", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod@localhost.com", true, "System", null, "Mod", false, null, "MOD@LOCALHOST.COM", "MOD", null, null, "AQAAAAIAAYagAAAAEAwyTwjCcwFdXdMWNvSbBryNQoqWx6OH/Rj8OdqjYw308Eln9pMb+9N4/Olb2KQamA==", null, null, false, "622bad2b-ad6e-4fbb-abc4-014534e8ef8e", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod", null },
                    { "9e224968-33e4-4652-b7b7-ismailbentabett", 0, null, null, null, "8d46cf8f-7e80-40ad-9a06-88ef39eeffab", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett@gmail.com", true, "Ismail", null, "Bentabet", false, null, "ISMAILBENTABETT@GMAIL.COM", "ISMAILBENTABETT", null, null, "AQAAAAIAAYagAAAAEP4V6Xt4osxmzUytSRu5DinDKCAKXFxBsQyPdPD2/JQK+aCIuE9vVvFoEEfBaIaJ6g==", null, null, false, "37eb6a0b-e1bd-42fa-83d0-687bea0a5a54", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(3978), "News", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(3992) },
                    { 2, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(3996), "Politics", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(3997) },
                    { 3, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(3998), "Science", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(3998) },
                    { 4, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(3999), "Technology", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(3999) },
                    { 5, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4000), "Gaming", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4001) },
                    { 6, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4006), "Sports", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4007) },
                    { 7, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4007), "Music", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4008) },
                    { 8, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4009), "Movies", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4010) },
                    { 9, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4010), "Television", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4011) },
                    { 10, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4012), "Books", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4013) },
                    { 11, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4015), "Art", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4015) },
                    { 12, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4016), "Food", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4016) },
                    { 13, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4017), "Travel", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4018) },
                    { 14, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4019), "Fitness", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4019) },
                    { 15, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4020), "Health", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4020) },
                    { 16, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4021), "Fashion", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4021) },
                    { 17, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4022), "Relationships", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4022) },
                    { 18, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4024), "Advice", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4024) },
                    { 19, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4025), "Writing", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4025) },
                    { 20, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4026), "Photography", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4026) },
                    { 21, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4027), "DIY (Do-It-Yourself)", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4027) },
                    { 22, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4028), "Nature", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4028) },
                    { 23, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4029), "Animals", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4029) },
                    { 24, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4030), "Memes", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4030) },
                    { 25, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4031), "Funny", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4031) },
                    { 26, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4032), "Jokes", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4033) },
                    { 27, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4033), "History", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4034) },
                    { 28, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4034), "Philosophy", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4035) },
                    { 29, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4036), "Psychology", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4036) },
                    { 30, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4037), "Education", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4037) },
                    { 31, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4038), "Career", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4038) },
                    { 32, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4039), "Personal Finance", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4039) },
                    { 33, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4040), "Entrepreneurship", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4040) },
                    { 34, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4042), "Parenting", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4042) },
                    { 35, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4043), "Relationships", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4043) },
                    { 36, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4044), "Technology News", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4044) },
                    { 37, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4045), "Programming", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4045) },
                    { 38, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4046), "Web Development", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4046) },
                    { 39, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4047), "Data Science", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4047) },
                    { 40, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4048), "Cryptocurrency", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4048) },
                    { 41, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4077), "Design", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4077) },
                    { 42, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4078), "Gaming News", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4079) },
                    { 43, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4080), "PC Gaming", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4080) },
                    { 44, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4081), "Console Gaming", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4081) },
                    { 45, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4082), "Mobile Gaming", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4082) },
                    { 46, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4083), "Esports", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4083) },
                    { 47, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4084), "Music News", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4084) },
                    { 48, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4086), "Hip-Hop", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4087) },
                    { 49, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4088), "Rock", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4088) },
                    { 50, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4089), "Pop Culture", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4089) },
                    { 51, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4090), "Fitness Motivation", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4090) },
                    { 52, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4091), "Nutrition", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4091) },
                    { 53, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4092), "Weightlifting", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4092) },
                    { 54, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4093), "Yoga", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4093) },
                    { 55, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4094), "Running", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4094) },
                    { 56, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4095), "Cycling", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4095) },
                    { 57, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4096), "CrossFit", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4096) },
                    { 58, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4097), "Bodybuilding", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4097) },
                    { 59, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4098), "Productivity", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4098) },
                    { 60, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4099), "Self-improvement", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4100) },
                    { 61, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4100), "Meditation", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4101) },
                    { 62, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4101), "Mindfulness", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4102) },
                    { 63, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4103), "Motivation", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4103) },
                    { 64, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4104), "Self-care", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4104) },
                    { 65, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4105), "Cooking", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4105) },
                    { 66, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4106), "Baking", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4107) },
                    { 67, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4107), "Grilling", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4108) },
                    { 68, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4109), "Veganism", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4109) },
                    { 69, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4110), "Vegetarianism", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4110) },
                    { 70, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4111), "Meal Prep", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4111) },
                    { 71, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4112), "Gardening", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4112) },
                    { 72, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4113), "Home Improvement", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4113) },
                    { 73, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4114), "Interior Design", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4114) },
                    { 74, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4115), "Real Estate", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4115) },
                    { 75, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4116), "Personal Finance Tips", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4116) },
                    { 76, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4117), "Investing", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4118) },
                    { 77, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4118), "Stock Market", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4119) },
                    { 78, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4119), "Cryptocurrency Trading", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4120) },
                    { 79, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4120), "Entrepreneur Stories", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4121) },
                    { 80, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4122), "Startups", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4122) },
                    { 81, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4123), "Small Business", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4123) },
                    { 82, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4124), "Marketing", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4124) },
                    { 83, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4125), "Social Media", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4125) },
                    { 84, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4126), "Podcasts", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4126) },
                    { 85, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4127), "Writing Prompts", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4127) },
                    { 86, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4129), "Fantasy", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4129) },
                    { 87, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4130), "Science Fiction", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4130) },
                    { 88, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4131), "Horror", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4131) },
                    { 89, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4132), "Thrillers", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4132) },
                    { 90, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4133), "True Crime", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4133) },
                    { 91, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4134), "Paranormal", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4134) },
                    { 92, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4135), "Comics", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4135) },
                    { 93, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4136), "Anime", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4136) },
                    { 94, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4137), "Manga", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4137) },
                    { 95, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4138), "Board Games", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4138) },
                    { 96, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4139), "Card Games", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4139) },
                    { 97, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4140), "Tabletop RPGs", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4140) },
                    { 98, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4141), "Travel Photography", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4142) },
                    { 99, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4142), "Outdoor Adventures", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4143) },
                    { 100, new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4143), "Celebrities", new DateTime(2023, 6, 5, 14, 12, 23, 639, DateTimeKind.Local).AddTicks(4144) }
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
                name: "IX_CommentHashtag_CommentId",
                table: "CommentHashtag",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentHashtag_HashtagId",
                table: "CommentHashtag",
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
                name: "CommentHashtag");

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
