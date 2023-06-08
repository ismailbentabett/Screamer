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
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, null, null, null, "374b6b59-b749-4a2d-b608-696919a87feb", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", null, "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", null, null, "AQAAAAIAAYagAAAAEEefgsatj064+k6D5ToFkj1R0LbUlOyO0+4jp/Lx0yBYSV4MeCrpBsKOl0XpkdIZhg==", null, null, false, "bb39156a-e1f1-4e97-aee0-3db3c8c0772d", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", null },
                    { "9e224968-33e4-4652-b7b7-8574d048cdb9", 0, null, null, null, "3a72b8bb-b63d-43aa-9ec8-e78e2e34aa41", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", null, "User", false, null, "USER@LOCALHOST.COM", "USER", null, null, "AQAAAAIAAYagAAAAEJZ6mfPpcRjUIV3XENr/sGLjs02kjfgAZ6vfRZnUasz48ubeYeQkO9Z+EB377T+l5g==", null, null, false, "c78ec6d4-46b4-4a9a-bf1f-01341877d9aa", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user", null },
                    { "9e224968-33e4-4652-b7b7-agfddsr", 0, null, null, null, "845fda30-1147-493c-8f1f-28e66005d980", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod@localhost.com", true, "System", null, "Mod", false, null, "MOD@LOCALHOST.COM", "MOD", null, null, "AQAAAAIAAYagAAAAEL4Phzp4o5/Qc5F69mhRrgI5JTAfUUo4Q+eoUWX/i+QWoR4CN1bUXrPuVtmyvTqSNw==", null, null, false, "8eca483a-60a6-429e-99e7-fe36dad4c92a", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod", null },
                    { "9e224968-33e4-4652-b7b7-ismailbentabett", 0, null, null, null, "18cee4f9-3e79-46b7-9374-ab268bfd642b", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett@gmail.com", true, "Ismail", null, "Bentabet", false, null, "ISMAILBENTABETT@GMAIL.COM", "ISMAILBENTABETT", null, null, "AQAAAAIAAYagAAAAEM3gJIBjm+Fa8pXuidR0hIEpLvyv7qaZzZTfy3mOe9AOrUWEObKs4gdjMeN6DsmQDw==", null, null, false, "c1c7da24-8f97-4497-9c21-49b160ab0333", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7387), "News", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7402) },
                    { 2, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7408), "Politics", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7409) },
                    { 3, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7410), "Science", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7410) },
                    { 4, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7411), "Technology", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7412) },
                    { 5, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7413), "Gaming", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7413) },
                    { 6, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7415), "Sports", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7415) },
                    { 7, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7416), "Music", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7417) },
                    { 8, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7418), "Movies", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7418) },
                    { 9, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7419), "Television", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7420) },
                    { 10, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7422), "Books", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7423) },
                    { 11, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7424), "Art", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7424) },
                    { 12, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7425), "Food", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7425) },
                    { 13, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7426), "Travel", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7426) },
                    { 14, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7432), "Fitness", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7432) },
                    { 15, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7433), "Health", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7437) },
                    { 16, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7447), "Fashion", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7447) },
                    { 17, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7448), "Relationships", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7449) },
                    { 18, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7451), "Advice", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7451) },
                    { 19, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7452), "Writing", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7452) },
                    { 20, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7453), "Photography", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7454) },
                    { 21, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7454), "DIY (Do-It-Yourself)", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7455) },
                    { 22, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7456), "Nature", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7456) },
                    { 23, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7457), "Animals", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7457) },
                    { 24, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7458), "Memes", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7458) },
                    { 25, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7459), "Funny", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7459) },
                    { 26, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7460), "Jokes", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7460) },
                    { 27, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7461), "History", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7461) },
                    { 28, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7462), "Philosophy", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7463) },
                    { 29, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7463), "Psychology", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7464) },
                    { 30, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7465), "Education", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7465) },
                    { 31, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7466), "Career", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7466) },
                    { 32, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7467), "Personal Finance", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7467) },
                    { 33, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7468), "Entrepreneurship", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7468) },
                    { 34, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7470), "Parenting", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7470) },
                    { 35, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7471), "Relationships", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7471) },
                    { 36, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7472), "Technology News", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7473) },
                    { 37, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7473), "Programming", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7474) },
                    { 38, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7474), "Web Development", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7475) },
                    { 39, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7476), "Data Science", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7476) },
                    { 40, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7477), "Cryptocurrency", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7477) },
                    { 41, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7478), "Design", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7478) },
                    { 42, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7511), "Gaming News", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7511) },
                    { 43, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7512), "PC Gaming", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7512) },
                    { 44, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7513), "Console Gaming", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7514) },
                    { 45, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7514), "Mobile Gaming", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7515) },
                    { 46, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7516), "Esports", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7516) },
                    { 47, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7517), "Music News", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7517) },
                    { 48, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7519), "Hip-Hop", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7519) },
                    { 49, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7520), "Rock", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7521) },
                    { 50, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7522), "Pop Culture", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7522) },
                    { 51, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7523), "Fitness Motivation", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7523) },
                    { 52, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7524), "Nutrition", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7524) },
                    { 53, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7525), "Weightlifting", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7525) },
                    { 54, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7526), "Yoga", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7526) },
                    { 55, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7527), "Running", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7527) },
                    { 56, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7528), "Cycling", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7529) },
                    { 57, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7529), "CrossFit", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7530) },
                    { 58, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7531), "Bodybuilding", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7531) },
                    { 59, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7532), "Productivity", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7532) },
                    { 60, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7533), "Self-improvement", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7533) },
                    { 61, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7534), "Meditation", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7534) },
                    { 62, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7535), "Mindfulness", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7535) },
                    { 63, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7536), "Motivation", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7537) },
                    { 64, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7537), "Self-care", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7538) },
                    { 65, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7539), "Cooking", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7539) },
                    { 66, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7540), "Baking", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7541) },
                    { 67, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7542), "Grilling", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7542) },
                    { 68, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7543), "Veganism", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7543) },
                    { 69, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7544), "Vegetarianism", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7544) },
                    { 70, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7545), "Meal Prep", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7545) },
                    { 71, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7546), "Gardening", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7546) },
                    { 72, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7547), "Home Improvement", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7547) },
                    { 73, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7548), "Interior Design", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7549) },
                    { 74, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7549), "Real Estate", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7550) },
                    { 75, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7551), "Personal Finance Tips", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7551) },
                    { 76, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7552), "Investing", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7552) },
                    { 77, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7553), "Stock Market", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7553) },
                    { 78, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7554), "Cryptocurrency Trading", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7554) },
                    { 79, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7555), "Entrepreneur Stories", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7555) },
                    { 80, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7556), "Startups", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7556) },
                    { 81, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7557), "Small Business", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7558) },
                    { 82, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7558), "Marketing", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7559) },
                    { 83, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7560), "Social Media", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7560) },
                    { 84, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7561), "Podcasts", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7561) },
                    { 85, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7562), "Writing Prompts", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7562) },
                    { 86, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7563), "Fantasy", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7563) },
                    { 87, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7564), "Science Fiction", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7564) },
                    { 88, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7565), "Horror", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7565) },
                    { 89, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7566), "Thrillers", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7566) },
                    { 90, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7567), "True Crime", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7568) },
                    { 91, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7568), "Paranormal", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7569) },
                    { 92, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7569), "Comics", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7570) },
                    { 93, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7571), "Anime", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7571) },
                    { 94, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7572), "Manga", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7572) },
                    { 95, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7573), "Board Games", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7573) },
                    { 96, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7574), "Card Games", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7574) },
                    { 97, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7578), "Tabletop RPGs", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7578) },
                    { 98, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7579), "Travel Photography", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7579) },
                    { 99, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7580), "Outdoor Adventures", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7581) },
                    { 100, new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7581), "Celebrities", new DateTime(2023, 6, 8, 13, 20, 46, 528, DateTimeKind.Local).AddTicks(7582) }
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
