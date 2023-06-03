using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class INitialMigrations : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "PostUserMention",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUserMention", x => new { x.PostId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PostUserMention_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUserMention_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostUserTag",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUserTag", x => new { x.PostId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PostUserTag_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUserTag_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, null, null, null, "2f61b71b-fc55-4c5d-af49-77313f802050", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", null, "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", null, null, "AQAAAAIAAYagAAAAEOIzWNW7q5WpAYPpQJWsB/jJiw77sVPeFIJV4xvg1R657Px7uApKICMuB2VwQTHn0g==", null, null, false, "c7ea003f-f527-4d37-8738-c821c25c99a9", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", null },
                    { "9e224968-33e4-4652-b7b7-8574d048cdb9", 0, null, null, null, "3725d21b-e60d-4b83-afae-3082e7147dd1", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", null, "User", false, null, "USER@LOCALHOST.COM", "USER", null, null, "AQAAAAIAAYagAAAAELPPRKVN/ZdqqENcDYrYMiaTrDlsIerGyGYNVRz7ywGOGNnRbofSyaD3BsZPbnWgmA==", null, null, false, "51eb36dd-f8cd-41aa-b95a-2ae69861346b", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user", null },
                    { "9e224968-33e4-4652-b7b7-agfddsr", 0, null, null, null, "a99e7fef-026d-45fa-b8b4-59522b44688a", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod@localhost.com", true, "System", null, "Mod", false, null, "MOD@LOCALHOST.COM", "MOD", null, null, "AQAAAAIAAYagAAAAEC7CPEkJ/frNvn9PPr2nVtHDL0VO3Z6iosNIEkae8rHk4+ap4brE+//xeLhCIj6E5g==", null, null, false, "742460ff-9886-4e9d-9266-3c0894d3b295", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod", null },
                    { "9e224968-33e4-4652-b7b7-ismailbentabett", 0, null, null, null, "06047d83-59d3-416a-9cf9-a77143dc0139", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett@gmail.com", true, "Ismail", null, "Bentabet", false, null, "ISMAILBENTABETT@GMAIL.COM", "ISMAILBENTABETT", null, null, "AQAAAAIAAYagAAAAEOnQxcWsoa9iSMsPfCrCXEijFQb5XyAiyVTnJITAdRyS2ytnmjdE8jGUYkc1EmlzRA==", null, null, false, "2ee0ef92-bad2-4d49-9f7d-4ffa25279b12", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4280), "News", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4293) },
                    { 2, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4298), "Politics", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4298) },
                    { 3, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4300), "Science", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4300) },
                    { 4, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4301), "Technology", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4301) },
                    { 5, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4302), "Gaming", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4303) },
                    { 6, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4305), "Sports", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4305) },
                    { 7, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4306), "Music", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4306) },
                    { 8, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4307), "Movies", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4307) },
                    { 9, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4308), "Television", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4308) },
                    { 10, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4310), "Books", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4310) },
                    { 11, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4311), "Art", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4311) },
                    { 12, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4312), "Food", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4312) },
                    { 13, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4349), "Travel", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4349) },
                    { 14, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4350), "Fitness", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4351) },
                    { 15, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4352), "Health", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4352) },
                    { 16, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4353), "Fashion", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4353) },
                    { 17, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4354), "Relationships", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4354) },
                    { 18, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4356), "Advice", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4356) },
                    { 19, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4357), "Writing", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4357) },
                    { 20, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4358), "Photography", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4358) },
                    { 21, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4359), "DIY (Do-It-Yourself)", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4360) },
                    { 22, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4360), "Nature", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4361) },
                    { 23, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4362), "Animals", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4362) },
                    { 24, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4363), "Memes", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4363) },
                    { 25, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4364), "Funny", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4364) },
                    { 26, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4365), "Jokes", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4365) },
                    { 27, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4366), "History", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4366) },
                    { 28, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4367), "Philosophy", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4367) },
                    { 29, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4368), "Psychology", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4369) },
                    { 30, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4369), "Education", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4370) },
                    { 31, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4371), "Career", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4371) },
                    { 32, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4372), "Personal Finance", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4372) },
                    { 33, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4373), "Entrepreneurship", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4373) },
                    { 34, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4375), "Parenting", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4375) },
                    { 35, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4376), "Relationships", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4376) },
                    { 36, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4377), "Technology News", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4377) },
                    { 37, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4378), "Programming", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4378) },
                    { 38, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4379), "Web Development", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4379) },
                    { 39, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4380), "Data Science", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4381) },
                    { 40, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4381), "Cryptocurrency", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4382) },
                    { 41, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4383), "Design", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4383) },
                    { 42, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4384), "Gaming News", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4384) },
                    { 43, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4385), "PC Gaming", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4385) },
                    { 44, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4386), "Console Gaming", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4386) },
                    { 45, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4387), "Mobile Gaming", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4387) },
                    { 46, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4388), "Esports", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4389) },
                    { 47, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4389), "Music News", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4390) },
                    { 48, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4390), "Hip-Hop", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4391) },
                    { 49, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4392), "Rock", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4392) },
                    { 50, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4393), "Pop Culture", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4393) },
                    { 51, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4395), "Fitness Motivation", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4395) },
                    { 52, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4396), "Nutrition", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4396) },
                    { 53, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4397), "Weightlifting", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4397) },
                    { 54, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4398), "Yoga", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4399) },
                    { 55, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4399), "Running", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4400) },
                    { 56, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4400), "Cycling", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4401) },
                    { 57, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4401), "CrossFit", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4402) },
                    { 58, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4403), "Bodybuilding", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4403) },
                    { 59, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4404), "Productivity", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4404) },
                    { 60, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4405), "Self-improvement", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4405) },
                    { 61, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4406), "Meditation", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4406) },
                    { 62, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4407), "Mindfulness", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4407) },
                    { 63, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4408), "Motivation", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4408) },
                    { 64, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4409), "Self-care", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4409) },
                    { 65, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4410), "Cooking", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4410) },
                    { 66, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4412), "Baking", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4412) },
                    { 67, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4413), "Grilling", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4413) },
                    { 68, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4414), "Veganism", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4415) },
                    { 69, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4415), "Vegetarianism", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4416) },
                    { 70, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4417), "Meal Prep", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4417) },
                    { 71, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4418), "Gardening", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4418) },
                    { 72, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4419), "Home Improvement", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4419) },
                    { 73, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4420), "Interior Design", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4420) },
                    { 74, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4421), "Real Estate", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4421) },
                    { 75, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4422), "Personal Finance Tips", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4422) },
                    { 76, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4423), "Investing", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4424) },
                    { 77, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4424), "Stock Market", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4425) },
                    { 78, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4426), "Cryptocurrency Trading", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4426) },
                    { 79, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4427), "Entrepreneur Stories", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4427) },
                    { 80, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4428), "Startups", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4428) },
                    { 81, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4429), "Small Business", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4429) },
                    { 82, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4430), "Marketing", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4430) },
                    { 83, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4431), "Social Media", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4431) },
                    { 84, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4432), "Podcasts", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4432) },
                    { 85, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4474), "Writing Prompts", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4475) },
                    { 86, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4476), "Fantasy", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4476) },
                    { 87, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4477), "Science Fiction", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4477) },
                    { 88, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4478), "Horror", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4478) },
                    { 89, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4479), "Thrillers", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4479) },
                    { 90, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4480), "True Crime", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4481) },
                    { 91, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4482), "Paranormal", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4482) },
                    { 92, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4483), "Comics", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4483) },
                    { 93, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4484), "Anime", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4484) },
                    { 94, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4485), "Manga", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4485) },
                    { 95, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4486), "Board Games", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4486) },
                    { 96, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4487), "Card Games", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4487) },
                    { 97, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4488), "Tabletop RPGs", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4488) },
                    { 98, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4489), "Travel Photography", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4490) },
                    { 99, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4490), "Outdoor Adventures", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4491) },
                    { 100, new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4491), "Celebrities", new DateTime(2023, 6, 3, 12, 18, 11, 292, DateTimeKind.Local).AddTicks(4492) }
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
                name: "IX_PostUserMention_UserId",
                table: "PostUserMention",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserTag_UserId",
                table: "PostUserTag",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Social_UserId",
                table: "Social",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
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
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "PostHashtags");

            migrationBuilder.DropTable(
                name: "PostImage");

            migrationBuilder.DropTable(
                name: "PostReactions");

            migrationBuilder.DropTable(
                name: "PostUserMention");

            migrationBuilder.DropTable(
                name: "PostUserTag");

            migrationBuilder.DropTable(
                name: "Social");

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
