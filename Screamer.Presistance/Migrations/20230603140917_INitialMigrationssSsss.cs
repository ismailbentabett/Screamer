using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Screamer.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class INitialMigrationssSsss : Migration
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_Posts_PostId",
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
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, null, null, null, "4160c1ec-74d2-4671-8d4d-5dff3f9abf92", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", null, "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", null, null, "AQAAAAIAAYagAAAAEMnTPCyQYZkWyKTpf73BtcrKQSfpkanK0BE2uv4turnHcUj7f4VBlnSX9hCA852N5w==", null, null, false, "fdcfcee8-7b06-4317-8837-f01d7e9120b3", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", null },
                    { "9e224968-33e4-4652-b7b7-8574d048cdb9", 0, null, null, null, "6112d31b-74af-4bf4-8137-769079811ca7", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", null, "User", false, null, "USER@LOCALHOST.COM", "USER", null, null, "AQAAAAIAAYagAAAAELsYlgJR23Lk0JTA+GIctEKoKEIPXpP1deeNn5ptlUgIUakBJph9jogCPBo08tn5eg==", null, null, false, "a77421cc-c886-4b61-ace1-4e864e76a123", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user", null },
                    { "9e224968-33e4-4652-b7b7-agfddsr", 0, null, null, null, "61ea465a-700e-44e0-92f8-3d6a36d6ef76", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod@localhost.com", true, "System", null, "Mod", false, null, "MOD@LOCALHOST.COM", "MOD", null, null, "AQAAAAIAAYagAAAAEPOdc6fm61BjtZguGTH7UVCECpfyxzX2jnvK+s3I+Du6jDAbMstI0e+9N8kO3L+5Vw==", null, null, false, "cd7d9e57-bcf9-49a4-b104-1a8289e90c14", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mod", null },
                    { "9e224968-33e4-4652-b7b7-ismailbentabett", 0, null, null, null, "daef0cb7-d6ff-4f35-9627-e81ffe8644a2", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett@gmail.com", true, "Ismail", null, "Bentabet", false, null, "ISMAILBENTABETT@GMAIL.COM", "ISMAILBENTABETT", null, null, "AQAAAAIAAYagAAAAEAX2XDgfF54HVa0FvGWuDXoZPS3DhX+OyaNdn1FaA7jsfj4Ui0DmH413FLnnD4sSWQ==", null, null, false, "260faf45-bc31-4264-a753-f8dca4ea9297", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismailbentabett", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4147), "News", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4162) },
                    { 2, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4178), "Politics", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4178) },
                    { 3, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4180), "Science", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4180) },
                    { 4, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4181), "Technology", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4181) },
                    { 5, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4182), "Gaming", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4183) },
                    { 6, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4184), "Sports", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4185) },
                    { 7, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4186), "Music", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4186) },
                    { 8, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4187), "Movies", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4187) },
                    { 9, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4188), "Television", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4189) },
                    { 10, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4190), "Books", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4191) },
                    { 11, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4192), "Art", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4192) },
                    { 12, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4193), "Food", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4193) },
                    { 13, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4194), "Travel", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4194) },
                    { 14, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4202), "Fitness", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4202) },
                    { 15, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4203), "Health", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4211) },
                    { 16, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4224), "Fashion", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4224) },
                    { 17, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4225), "Relationships", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4225) },
                    { 18, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4227), "Advice", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4227) },
                    { 19, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4228), "Writing", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4229) },
                    { 20, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4229), "Photography", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4230) },
                    { 21, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4231), "DIY (Do-It-Yourself)", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4231) },
                    { 22, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4232), "Nature", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4232) },
                    { 23, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4233), "Animals", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4234) },
                    { 24, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4234), "Memes", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4235) },
                    { 25, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4236), "Funny", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4236) },
                    { 26, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4237), "Jokes", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4237) },
                    { 27, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4273), "History", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4274) },
                    { 28, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4275), "Philosophy", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4275) },
                    { 29, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4276), "Psychology", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4277) },
                    { 30, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4277), "Education", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4278) },
                    { 31, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4279), "Career", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4279) },
                    { 32, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4280), "Personal Finance", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4280) },
                    { 33, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4281), "Entrepreneurship", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4282) },
                    { 34, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4283), "Parenting", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4284) },
                    { 35, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4285), "Relationships", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4285) },
                    { 36, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4286), "Technology News", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4286) },
                    { 37, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4287), "Programming", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4287) },
                    { 38, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4288), "Web Development", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4289) },
                    { 39, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4289), "Data Science", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4290) },
                    { 40, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4291), "Cryptocurrency", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4291) },
                    { 41, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4292), "Design", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4292) },
                    { 42, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4293), "Gaming News", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4293) },
                    { 43, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4294), "PC Gaming", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4295) },
                    { 44, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4296), "Console Gaming", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4296) },
                    { 45, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4297), "Mobile Gaming", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4297) },
                    { 46, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4298), "Esports", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4299) },
                    { 47, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4299), "Music News", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4300) },
                    { 48, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4301), "Hip-Hop", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4301) },
                    { 49, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4302), "Rock", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4302) },
                    { 50, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4303), "Pop Culture", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4303) },
                    { 51, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4304), "Fitness Motivation", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4305) },
                    { 52, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4307), "Nutrition", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4307) },
                    { 53, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4308), "Weightlifting", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4308) },
                    { 54, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4309), "Yoga", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4310) },
                    { 55, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4311), "Running", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4311) },
                    { 56, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4312), "Cycling", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4312) },
                    { 57, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4313), "CrossFit", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4313) },
                    { 58, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4314), "Bodybuilding", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4315) },
                    { 59, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4315), "Productivity", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4316) },
                    { 60, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4317), "Self-improvement", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4317) },
                    { 61, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4318), "Meditation", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4319) },
                    { 62, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4319), "Mindfulness", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4320) },
                    { 63, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4321), "Motivation", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4321) },
                    { 64, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4322), "Self-care", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4322) },
                    { 65, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4323), "Cooking", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4323) },
                    { 66, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4325), "Baking", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4325) },
                    { 67, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4326), "Grilling", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4327) },
                    { 68, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4328), "Veganism", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4328) },
                    { 69, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4329), "Vegetarianism", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4329) },
                    { 70, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4330), "Meal Prep", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4330) },
                    { 71, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4331), "Gardening", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4332) },
                    { 72, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4332), "Home Improvement", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4333) },
                    { 73, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4334), "Interior Design", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4334) },
                    { 74, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4335), "Real Estate", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4335) },
                    { 75, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4336), "Personal Finance Tips", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4337) },
                    { 76, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4337), "Investing", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4338) },
                    { 77, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4339), "Stock Market", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4339) },
                    { 78, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4340), "Cryptocurrency Trading", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4340) },
                    { 79, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4341), "Entrepreneur Stories", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4341) },
                    { 80, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4342), "Startups", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4343) },
                    { 81, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4344), "Small Business", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4344) },
                    { 82, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4345), "Marketing", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4345) },
                    { 83, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4346), "Social Media", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4346) },
                    { 84, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4347), "Podcasts", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4348) },
                    { 85, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4348), "Writing Prompts", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4349) },
                    { 86, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4350), "Fantasy", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4350) },
                    { 87, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4351), "Science Fiction", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4351) },
                    { 88, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4352), "Horror", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4352) },
                    { 89, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4353), "Thrillers", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4354) },
                    { 90, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4355), "True Crime", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4355) },
                    { 91, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4356), "Paranormal", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4356) },
                    { 92, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4357), "Comics", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4357) },
                    { 93, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4358), "Anime", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4359) },
                    { 94, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4359), "Manga", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4360) },
                    { 95, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4361), "Board Games", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4361) },
                    { 96, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4362), "Card Games", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4362) },
                    { 97, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4363), "Tabletop RPGs", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4363) },
                    { 98, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4364), "Travel Photography", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4365) },
                    { 99, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4365), "Outdoor Adventures", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4366) },
                    { 100, new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4367), "Celebrities", new DateTime(2023, 6, 3, 15, 9, 17, 3, DateTimeKind.Local).AddTicks(4367) }
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
