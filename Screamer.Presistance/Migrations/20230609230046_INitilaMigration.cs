using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class INitilaMigration : Migration
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
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, null, null, null, "04641b55-ea95-4a86-9382-d45858bbe318", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", null, "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", null, null, "AQAAAAIAAYagAAAAEFsMl4So1JfhP6quDKJuQZMIH19TNZFASEI/fcs2GqRuOZ2B+u5PoGQNoZfUAnA0Rw==", null, null, false, "84783640-4cdf-467d-b429-dfd41c706f68", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", null },
                    { "9e224968-33e4-4652-b7b7-8574d048cdb9", 0, null, null, null, "d5750050-c2bc-47bf-8400-bdb8c369cbd8", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", null, "User", false, null, "USER@LOCALHOST.COM", "USER", null, null, "AQAAAAIAAYagAAAAEFqKU/MTXftGQhDMwNSL85v+GqLJxtsGZf8V0LHkJ7ptuzTUAfdEVR64GggZ/flLCg==", null, null, false, "da52b73b-2e1a-4ae8-957e-7f67597949db", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user", null },
                    { "9e224968-33e4-4652-b7b7-agfddsr", 0, null, null, null, "f9d36dd1-ef5a-4b12-8b63-dc24789ed85b", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod@localhost.com", true, "System", null, "Mod", false, null, "MOD@LOCALHOST.COM", "MOD", null, null, "AQAAAAIAAYagAAAAEIMjXG+hmDQ6JDeRXB5wbhNf+aP92YaKvrOgvtVx8HQ2LObpGmeSDo+jfgqp3MUqsg==", null, null, false, "b1ffea62-c760-408d-b989-ad92b905c893", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod", null },
                    { "9e224968-33e4-4652-b7b7-ismailbentabett", 0, null, null, null, "3ef12f31-9eab-4f71-8e55-4e201b300659", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett@gmail.com", false, "Ismail", null, "Bentabet", false, null, "ISMAILBENTABETT@GMAIL.COM", "ISMAILBENTABETT", null, null, "AQAAAAIAAYagAAAAEAVeU1bzcc+i8M7FvI/DonP55b7wvZcKWG+R/zSDLbLt0kYOBU9CyvD65fQqWuowVw==", null, null, false, "44a37edb-6ced-484c-b6c2-77172634856a", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3394), "News", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3418) },
                    { 2, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3476), "Politics", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3477) },
                    { 3, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3478), "Science", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3479) },
                    { 4, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3480), "Technology", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3480) },
                    { 5, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3481), "Gaming", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3481) },
                    { 6, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3484), "Sports", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3484) },
                    { 7, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3485), "Music", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3485) },
                    { 8, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3486), "Movies", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3486) },
                    { 9, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3487), "Television", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3488) },
                    { 10, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3489), "Books", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3490) },
                    { 11, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3491), "Art", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3491) },
                    { 12, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3492), "Food", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3492) },
                    { 13, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3493), "Travel", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3493) },
                    { 14, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3501), "Fitness", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3501) },
                    { 15, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3503), "Health", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3508) },
                    { 16, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3522), "Fashion", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3522) },
                    { 17, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3523), "Relationships", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3523) },
                    { 18, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3525), "Advice", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3526) },
                    { 19, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3526), "Writing", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3527) },
                    { 20, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3528), "Photography", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3528) },
                    { 21, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3529), "DIY (Do-It-Yourself)", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3529) },
                    { 22, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3530), "Nature", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3530) },
                    { 23, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3532), "Animals", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3532) },
                    { 24, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3533), "Memes", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3533) },
                    { 25, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3534), "Funny", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3534) },
                    { 26, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3535), "Jokes", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3536) },
                    { 27, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3536), "History", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3537) },
                    { 28, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3538), "Philosophy", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3538) },
                    { 29, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3539), "Psychology", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3539) },
                    { 30, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3540), "Education", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3540) },
                    { 31, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3541), "Career", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3541) },
                    { 32, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3542), "Personal Finance", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3542) },
                    { 33, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3543), "Entrepreneurship", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3544) },
                    { 34, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3545), "Parenting", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3545) },
                    { 35, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3546), "Relationships", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3547) },
                    { 36, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3547), "Technology News", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3548) },
                    { 37, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3549), "Programming", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3549) },
                    { 38, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3550), "Web Development", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3550) },
                    { 39, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3551), "Data Science", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3551) },
                    { 40, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3552), "Cryptocurrency", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3552) },
                    { 41, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3553), "Design", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3554) },
                    { 42, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3555), "Gaming News", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3555) },
                    { 43, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3556), "PC Gaming", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3556) },
                    { 44, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3557), "Console Gaming", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3557) },
                    { 45, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3558), "Mobile Gaming", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3558) },
                    { 46, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3559), "Esports", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3559) },
                    { 47, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3565), "Music News", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3565) },
                    { 48, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3566), "Hip-Hop", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3566) },
                    { 49, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3567), "Rock", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3567) },
                    { 50, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3568), "Pop Culture", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3568) },
                    { 51, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3569), "Fitness Motivation", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3570) },
                    { 52, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3570), "Nutrition", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3571) },
                    { 53, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3572), "Weightlifting", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3572) },
                    { 54, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3573), "Yoga", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3573) },
                    { 55, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3574), "Running", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3574) },
                    { 56, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3575), "Cycling", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3575) },
                    { 57, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3576), "CrossFit", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3576) },
                    { 58, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3577), "Bodybuilding", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3578) },
                    { 59, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3578), "Productivity", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3579) },
                    { 60, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3580), "Self-improvement", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3580) },
                    { 61, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3581), "Meditation", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3581) },
                    { 62, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3582), "Mindfulness", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3582) },
                    { 63, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3583), "Motivation", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3583) },
                    { 64, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3584), "Self-care", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3584) },
                    { 65, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3585), "Cooking", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3585) },
                    { 66, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3587), "Baking", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3587) },
                    { 67, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3588), "Grilling", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3589) },
                    { 68, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3589), "Veganism", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3590) },
                    { 69, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3590), "Vegetarianism", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3591) },
                    { 70, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3592), "Meal Prep", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3592) },
                    { 71, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3633), "Gardening", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3634) },
                    { 72, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3635), "Home Improvement", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3635) },
                    { 73, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3636), "Interior Design", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3636) },
                    { 74, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3637), "Real Estate", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3638) },
                    { 75, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3639), "Personal Finance Tips", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3639) },
                    { 76, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3640), "Investing", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3640) },
                    { 77, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3641), "Stock Market", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3641) },
                    { 78, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3642), "Cryptocurrency Trading", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3643) },
                    { 79, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3644), "Entrepreneur Stories", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3644) },
                    { 80, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3645), "Startups", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3645) },
                    { 81, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3646), "Small Business", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3646) },
                    { 82, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3647), "Marketing", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3647) },
                    { 83, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3648), "Social Media", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3648) },
                    { 84, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3649), "Podcasts", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3650) },
                    { 85, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3651), "Writing Prompts", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3652) },
                    { 86, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3653), "Fantasy", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3653) },
                    { 87, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3654), "Science Fiction", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3654) },
                    { 88, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3655), "Horror", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3655) },
                    { 89, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3656), "Thrillers", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3656) },
                    { 90, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3657), "True Crime", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3657) },
                    { 91, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3658), "Paranormal", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3659) },
                    { 92, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3659), "Comics", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3660) },
                    { 93, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3661), "Anime", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3661) },
                    { 94, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3662), "Manga", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3662) },
                    { 95, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3663), "Board Games", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3663) },
                    { 96, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3664), "Card Games", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3664) },
                    { 97, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3665), "Tabletop RPGs", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3665) },
                    { 98, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3666), "Travel Photography", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3667) },
                    { 99, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3667), "Outdoor Adventures", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3668) },
                    { 100, new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3669), "Celebrities", new DateTime(2023, 6, 10, 0, 0, 45, 567, DateTimeKind.Local).AddTicks(3669) }
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
