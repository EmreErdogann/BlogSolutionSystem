using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogSolutionSystem.Data.Migrations
{
    public partial class İnitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedByName = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(maxLength: 50, nullable: false),
                    Note = table.Column<string>(maxLength: 500, nullable: true),
                    Name = table.Column<string>(maxLength: 70, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 100, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Picture = table.Column<string>(maxLength: 250, nullable: false),
                    About = table.Column<string>(maxLength: 1000, nullable: true),
                    FirstName = table.Column<string>(maxLength: 30, nullable: true),
                    LastName = table.Column<string>(maxLength: 30, nullable: true),
                    YoutubeLink = table.Column<string>(maxLength: 250, nullable: true),
                    TwitterLink = table.Column<string>(maxLength: 250, nullable: true),
                    InstagramLink = table.Column<string>(maxLength: 250, nullable: true),
                    FacebookLink = table.Column<string>(maxLength: 250, nullable: true),
                    LinkedInLink = table.Column<string>(maxLength: 250, nullable: true),
                    GitHubLink = table.Column<string>(maxLength: 250, nullable: true),
                    WebsiteLink = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedByName = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(maxLength: 50, nullable: false),
                    Note = table.Column<string>(maxLength: 500, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Thumbnail = table.Column<string>(maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ViewsCount = table.Column<int>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false),
                    SeoAuthor = table.Column<string>(maxLength: 50, nullable: false),
                    SeoDescription = table.Column<string>(maxLength: 150, nullable: false),
                    SeoTags = table.Column<string>(maxLength: 70, nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedByName = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(maxLength: 50, nullable: false),
                    Note = table.Column<string>(maxLength: 500, nullable: true),
                    Text = table.Column<string>(maxLength: 1000, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 7, "e07f7aca-8bc7-44d9-a5e7-d96f7c496c75", "Article.Update", "ARTICLE.UPDATE" },
                    { 10, "18bbaec2-075f-4d62-ab05-4b8b85e870c6", "User.Read", "USER.READ" },
                    { 9, "7957bbdf-4254-4f20-90cd-4d20630b2944", "User.Create", "USER.CREATE" },
                    { 8, "98012cd0-9d79-42f5-92a9-de755a133104", "Article.Delete", "ARTICLE.DELETE" },
                    { 13, "bcd4d4ad-bfcf-424f-accd-78e4fa88b243", "Role.Create", "ROLE.CREATE" },
                    { 6, "171220ac-30a0-4602-ac7e-ccb8f0efc78c", "Article.Read", "ARTICLE.READ" },
                    { 5, "112a4a4c-bd62-4e0c-9336-42954b39c11b", "Article.Create", "ARTICLE.CREATE" },
                    { 4, "edccc700-931a-48e1-b6cc-29c51ceda9e2", "Category.Delete", "CATEGORY.DELETE" },
                    { 3, "fbddc7bb-6616-4a99-9dbc-e004ecfdadac", "Category.Update", "CATEGORY.UPDATE" },
                    { 2, "b1973866-e9e7-4be0-9fe2-df69a01a615a", "Category.Read", "CATEGORY.READ" },
                    { 1, "fbd7d11e-cee2-4aa7-821c-0479f9fbcb90", "Category.Create", "CATEGORY.CREATE" },
                    { 14, "9f31d964-8251-4094-8a67-b78e8adc17ee", "Role.Read", "ROLE.READ" },
                    { 15, "bc310b5e-3a05-41c5-842a-8cc46153251c", "Role.Update", "ROLE.UPDATE" },
                    { 16, "6b731cad-ce19-4ccb-966f-2842b61a862b", "Role.Delete", "ROLE.DELETE" },
                    { 17, "451308f1-ecdb-47ef-a4b0-78c2ee1fb2ec", "Comment.Create", "COMMENT.CREATE" },
                    { 18, "e5a55d0f-1e1c-4026-9e49-c4f94589ea91", "Comment.Read", "COMMENT.READ" },
                    { 19, "f461ee4e-94a5-4703-8a1a-f563794eeb34", "Comment.Update", "COMMENT.UPDATE" },
                    { 20, "cf4a5d78-62b0-44c5-95eb-fb5cf6f260d3", "Comment.Delete", "COMMENT.DELETE" },
                    { 21, "d1c760f4-e303-4d09-a3d5-724f130f66bf", "AdminArea.Home.Read", "ADMINAREA.HOME.READ" },
                    { 22, "4371fc20-4920-41b0-9005-20bef5eae64e", "SuperAdmin", "SUPERADMIN" },
                    { 11, "67b35088-f7e6-4b87-a8dc-f9195dfaa617", "User.Update", "USER.UPDATE" },
                    { 12, "579f500d-7c9f-4de7-886b-15a57b5a028f", "User.Delete", "USER.DELETE" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6856), "C# Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6864), "C#", "C# Blog Kategorisi" },
                    { 10, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6918), "Ruby Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6919), "Ruby", "Ruby Blog Kategorisi" },
                    { 9, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6915), "Swift Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6916), "Swift", "Swift Blog Kategorisi" },
                    { 8, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6912), "Kotlin Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6913), "Kotlin", "Kotlin Blog Kategorisi" },
                    { 7, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6909), "Php Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6910), "Php", "Php Blog Kategorisi" },
                    { 6, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6906), "Python Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6907), "Python", "Python Blog Kategorisi" },
                    { 5, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6904), "Java Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6905), "Java", "Java Blog Kategorisi" },
                    { 4, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6901), "TypeScript Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6902), "TypeScript", "TypeScript Blog Kategorisi" },
                    { 3, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6898), "JavaScript Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6899), "JavaScript", "JavaScript Blog Kategorisi" },
                    { 2, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6894), "C++ Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 787, DateTimeKind.Local).AddTicks(6896), "C++", "C++ Blog Kategorisi" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FacebookLink", "FirstName", "GitHubLink", "InstagramLink", "LastName", "LinkedInLink", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwitterLink", "TwoFactorEnabled", "UserName", "WebsiteLink", "YoutubeLink" },
                values: new object[,]
                {
                    { 1, "Admin User of Blog", 0, "1f3775e3-9493-4f85-a677-a884e795ca2d", "adminuser@gmail.com", true, "https://facebook.com/adminuser", "Admin", "https://github.com/adminuser", "https://instagram.com/adminuser", "User", "https://linkedin.com/adminuser", false, null, "ADMINUSER@GMAIL.COM", "ADMINUSER", "AQAAAAEAACcQAAAAEGgJ2yIyxz3u6nlHwCCNgqch0+Woa7MaoyUsOf+qIyk2TWsmQ1McSHg9HQ7pLkS4vg==", "05375715692", true, "/userImages/defaultUser.png", "0c74de81-2d76-423b-96b7-a6d688ae2435", "https://twitter.com/adminuser", false, "adminuser", "https://programmersblog.com/", "https://youtube.com/adminuser" },
                    { 2, "Editor User of Blog", 0, "e6000efd-35d9-4b0f-9872-0a7b1b077588", "editoruser@gmail.com", true, "https://facebook.com/editoruser", "Editor", "https://github.com/editoruser", "https://instagram.com/editoruser", "User", "https://linkedin.com/editoruser", false, null, "EDITORUSER@GMAIL.COM", "EDITORUSER", "AQAAAAEAACcQAAAAEI2AqYcc9U1AYE9TiFgFBX00ZvF3HhivEsJZ64EznUReXAQZZH/1XO3cidYbA/xT3w==", "+905555555555", true, "/userImages/defaultUser.png", "28249f54-9d7b-4bb7-a826-3d711df74c65", "https://twitter.com/editoruser", false, "editoruser", "https://programmersblog.com/", "https://youtube.com/editoruser" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { 1, 1, 1, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(4084), new DateTime(2021, 3, 29, 15, 23, 45, 783, DateTimeKind.Local).AddTicks(3410), false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(4882), "C# 9.0 ve .NET 5 Yenilikleri", "Emre Erdoğan", "C# 9.0 ve .NET 5 Yenilikleri", "C#, C# 9, .NET5, .NET Framework, .NET Core", "Default.jpg", "C# 9.0 ve .NET 5 Yenilikleri", 1, 100 },
                    { 2, 2, 1, "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6712), new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6701), false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6713), "C++ 11 ve 19 Yenilikleri", "Emre Erdoğan", "C++ 11 ve 19 Yenilikleri", "C++ 11 ve 19 Yenilikleri", "Default.jpg", "C++ 11 ve 19 Yenilikleri", 1, 295 },
                    { 3, 3, 7, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.", "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6737), new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6736), false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6739), "JavaScript ES2020 ve ES2021 Yenilikleri", "Emre Erdoğan", "JavaScript ES2020 ve ES2021 Yenilikleri", "JavaScript ES2020 ve ES2021 Yenilikleri", "Default.jpg", "JavaScript ES2020 ve ES2021 Yenilikleri", 1, 67 },
                    { 4, 4, 2, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.", "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6742), new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6741), false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6743), "TypeScript ES2020 ve ES2021 Yenilikleri", "Emre Erdoğan", "TypeScript ES2020 ve ES2021 Yenilikleri", "TypeScript ES2020 ve ES2021 Yenilikleri", "Default.jpg", "TypeScript ES2020 ve ES2021 Yenilikleri", 1, 17 },
                    { 5, 5, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.", "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6746), new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6745), false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6748), "Php 7.4 ES2020  Yenilikleri", "Emre Erdoğan", "Php 7.4 ES2020 Yenilikleri", "Php 7.4 ES2020 Yenilikleri", "Default.jpg", "Php 7.4 ES2020 Yenilikleri", 1, 172 },
                    { 6, 6, 8, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.", "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6751), new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6750), false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6752), "React Native  Yenilikleri", "Emre Erdoğan", "React Native Yenilikleri", "Php 7.4 ES2020 Yenilikleri", "Default.jpg", "React Native Yenilikleri", 1, 62 },
                    { 7, 7, 0, "Contrairement à une opinion répandue, le Lorem Ipsum n'est pas simplement du texte aléatoire. Il trouve ses racines dans une oeuvre de la littérature latine classique datant de 45 av. J.-C., le rendant vieux de 2000 ans. Un professeur du Hampden-Sydney College, en Virginie, s'est intéressé à un des mots latins les plus obscurs, consectetur, extrait d'un passage du Lorem Ipsum, et en étudiant tous les usages de ce mot dans la littérature classique, découvrit la source incontestable du Lorem Ipsum. Il provient en fait des sections 1.10.32 et 1.10.33 du 0De Finibus Bonorum et Malorum' (Des Suprêmes Biens et des Suprêmes Maux) de Cicéron. Cet ouvrage, très populaire pendant la Renaissance, est un traité sur la théorie de l'éthique. Les premières lignes du Lorem Ipsum, 'Lorem ipsum dolor sit amet...'', proviennent de la section 1.10.32", "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6755), new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6754), false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6756), "PHP", "Emre Erdoğan", "Php ile API Oluşturma Rehberi", "php, laravel, api, oop", "postImages/defaultThumbnail.jpg", "Php Laravel Başlangıç Rehberi | API", 1, 4818 },
                    { 8, 8, 0, "Plusieurs variations de Lorem Ipsum peuvent être trouvées ici ou là, mais la majeure partie d'entre elles a été altérée par l'addition d'humour ou de mots aléatoires qui ne ressemblent pas une seconde à du texte standard. Si vous voulez utiliser un passage du Lorem Ipsum, vous devez être sûr qu'il n'y a rien d'embarrassant caché dans le texte. Tous les générateurs de Lorem Ipsum sur Internet tendent à reproduire le même extrait sans fin, ce qui fait de lipsum.com le seul vrai générateur de Lorem Ipsum. Iil utilise un dictionnaire de plus de 200 mots latins, en combinaison de plusieurs structures de phrases, pour générer un Lorem Ipsum irréprochable. Le Lorem Ipsum ainsi obtenu ne contient aucune répétition, ni ne contient des mots farfelus, ou des touches d'humour.", "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6759), new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6758), false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6761), "Kotlin", "Emre Erdoğan", "Kotlin ile Mobil Programlama Baştan Sona Adım Adım", "kotlin, android, mobil, programlama", "postImages/defaultThumbnail.jpg", "Kotlin ile Mobil Programlama", 1, 750 },
                    { 9, 9, 0, "Al contrario di quanto si pensi, Lorem Ipsum non è semplicemente una sequenza casuale di caratteri. Risale ad un classico della letteratura latina del 45 AC, cosa che lo rende vecchio di 2000 anni. Richard McClintock, professore di latino al Hampden-Sydney College in Virginia, ha ricercato una delle più oscure parole latine, consectetur, da un passaggio del Lorem Ipsum e ha scoperto tra i vari testi in cui è citata, la fonte da cui è tratto il testo, le sezioni 1.10.32 and 1.10.33 del 'de Finibus Bonorum et Malorum' di Cicerone. Questo testo è un trattato su teorie di etica, molto popolare nel Rinascimento. La prima riga del Lorem Ipsum, 'Lorem ipsum dolor sit amet..'', è tratta da un passaggio della sezione 1.10.32.", "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6764), new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6763), false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6765), "Swift", "Emre Erdoğan", "Swift ile IOS Mobil Programlama Baştan Sona Adım Adım", "IOS, android, mobil, programlama", "postImages/defaultThumbnail.jpg", "Swift ile IOS Programlama", 1, 14900 },
                    { 10, 10, 0, "Esistono innumerevoli variazioni dei passaggi del Lorem Ipsum, ma la maggior parte hanno subito delle variazioni del tempo, a causa dell’inserimento di passaggi ironici, o di sequenze casuali di caratteri palesemente poco verosimili. Se si decide di utilizzare un passaggio del Lorem Ipsum, è bene essere certi che non contenga nulla di imbarazzante. In genere, i generatori di testo segnaposto disponibili su internet tendono a ripetere paragrafi predefiniti, rendendo questo il primo vero generatore automatico su intenet. Infatti utilizza un dizionario di oltre 200 vocaboli latini, combinati con un insieme di modelli di strutture di periodi, per generare passaggi di testo verosimili. Il testo così generato è sempre privo di ripetizioni, parole imbarazzanti o fuori luogo ecc.", "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6768), new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6767), false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 784, DateTimeKind.Local).AddTicks(6769), "Ruby", "Emre Erdoğan", "Ruby, Ruby on Rails Web Programlama, AirBnb Klon", "Ruby on Rails, Ruby, Web Programlama, AirBnb", "postImages/defaultThumbnail.jpg", "Ruby on Rails ile AirBnb Klon Kodlayalım", 1, 26777 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[,]
                {
                    { 1, 1, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3354), true, false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3362), "C# Makale Yorumu", "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır." },
                    { 2, 2, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3398), true, false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3399), "C++ Makale Yorumu", "Lorem Ipsum jest tekstem stosowanym jako przykładowy wypełniacz w przemyśle poligraficznym. Został po raz pierwszy użyty w XV w. przez nieznanego drukarza do wypełnienia tekstem próbnej książki. Pięć wieków później zaczął być używany przemyśle elektronicznym, pozostając praktycznie niezmienionym. Spopularyzował się w latach 60. XX w. wraz z publikacją arkuszy Letrasetu, zawierających fragmenty Lorem Ipsum, a ostatnio z zawierającym różne wersje Lorem Ipsum oprogramowaniem przeznaczonym do realizacji druków na komputerach osobistych, jak Aldus PageMaker" },
                    { 3, 3, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3402), true, false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3403), "JavaScript Makale Yorumu", "Ang Lorem Ipsum ay ginagamit na modelo ng industriya ng pagpriprint at pagtytypeset. Ang Lorem Ipsum ang naging regular na modelo simula pa noong 1500s, noong may isang di kilalang manlilimbag and kumuha ng galley ng type at ginulo ang pagkaka-ayos nito upang makagawa ng libro ng mga type specimen. Nalagpasan nito hindi lang limang siglo, kundi nalagpasan din nito ang paglaganap ng electronic typesetting at nanatiling parehas. Sumikat ito noong 1960s kasabay ng pag labas ng Letraset sheets na mayroong mga talata ng Lorem Ipsum, at kamakailan lang sa mga desktop publishing software tulad ng Aldus Pagemaker ginamit ang mga bersyon ng Lorem Ipsum." },
                    { 4, 4, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3405), true, false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3406), "Typescript Makale Yorumu", "Lorem Ipsum er rett og slett dummytekst fra og for trykkeindustrien. Lorem Ipsum har vært bransjens standard for dummytekst helt siden 1500-tallet, da en ukjent boktrykker stokket en mengde bokstaver for å lage et prøveeksemplar av en bok. Lorem Ipsum har tålt tidens tann usedvanlig godt, og har i tillegg til å bestå gjennom fem århundrer også tålt spranget over til elektronisk typografi uten vesentlige endringer. Lorem Ipsum ble gjort allment kjent i 1960-årene ved lanseringen av Letraset-ark med avsnitt fra Lorem Ipsum, og senere med sideombrekkingsprogrammet Aldus PageMaker som tok i bruk nettopp Lorem Ipsum for dummytekst." },
                    { 5, 5, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3408), true, false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3409), "Java Makale Yorumu", "Lorem Ipsum este pur şi simplu o machetă pentru text a industriei tipografice. Lorem Ipsum a fost macheta standard a industriei încă din secolul al XVI-lea, când un tipograf anonim a luat o planşetă de litere şi le-a amestecat pentru a crea o carte demonstrativă pentru literele respective. Nu doar că a supravieţuit timp de cinci secole, dar şi a facut saltul în tipografia electronică practic neschimbată. A fost popularizată în anii '60 odată cu ieşirea colilor Letraset care conţineau pasaje Lorem Ipsum, iar mai recent, prin programele de publicare pentru calculator, ca Aldus PageMaker care includeau versiuni de Lorem Ipsum." },
                    { 6, 6, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3411), true, false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3412), "Python Makale Yorumu", "Lorem Ipsum je jednostavno probni tekst koji se koristi u tiskarskoj i slovoslagarskoj industriji. Lorem Ipsum postoji kao industrijski standard još od 16-og stoljeća, kada je nepoznati tiskar uzeo tiskarsku galiju slova i posložio ih da bi napravio knjigu s uzorkom tiska. Taj je tekst ne samo preživio pet stoljeća, već se i vinuo u svijet elektronskog slovoslagarstva, ostajući u suštini nepromijenjen. Postao je popularan tijekom 1960-ih s pojavom Letraset listova s odlomcima Lorem Ipsum-a, a u skorije vrijeme sa software-om za stolno izdavaštvo kao što je Aldus PageMaker koji također sadrži varijante Lorem Ipsum-a." },
                    { 7, 7, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3413), true, false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3414), "Php Makale Yorumu", "Lorem Ipsum – tas ir teksta salikums, kuru izmanto poligrāfijā un maketēšanas darbos. Lorem Ipsum ir kļuvis par vispārpieņemtu teksta aizvietotāju kopš 16. gadsimta sākuma. Tajā laikā kāds nezināms iespiedējs izveidoja teksta fragmentu, lai nodrukātu grāmatu ar burtu paraugiem. Tas ir ne tikai pārdzīvojis piecus gadsimtus, bet bez ievērojamām izmaiņām saglabājies arī mūsdienās, pārejot uz datorizētu teksta apstrādi. Tā popularizēšanai 60-tajos gados kalpoja Letraset burtu paraugu publicēšana ar Lorem Ipsum teksta fragmentiem un, nesenā pagātnē, tādas maketēšanas programmas kā Aldus PageMaker, kuras šablonu paraugos ir izmantots Lorem Ipsum teksts." },
                    { 8, 8, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3416), true, false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3417), "Kotlin Makale Yorumu", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)." },
                    { 9, 9, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3419), true, false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3420), "Swift Makale Yorumu", "هنالك العديد من الأنواع المتوفرة لنصوص لوريم إيبسوم، ولكن الغالبية تم تعديلها بشكل ما عبر إدخال بعض النوادر أو الكلمات العشوائية إلى النص. إن كنت تريد أن تستخدم نص لوريم إيبسوم ما، عليك أن تتحقق أولاً أن ليس هناك أي كلمات أو عبارات محرجة أو غير لائقة مخبأة في هذا النص. بينما تعمل جميع مولّدات نصوص لوريم إيبسوم على الإنترنت على إعادة تكرار مقاطع من نص لوريم إيبسوم نفسه عدة مرات بما تتطلبه الحاجة، يقوم مولّدنا هذا باستخدام كلمات من قاموس يحوي على أكثر من 200 كلمة لا تينية، مضاف إليها مجموعة من الجمل النموذجية، لتكوين نص لوريم إيبسوم ذو شكل منطقي قريب إلى النص الحقيقي. وبالتالي يكون النص الناتح خالي من التكرار، أو أي كلمات أو عبارات غير لائقة أو ما شابه. وهذا ما يجعله أول مولّد نص لوريم إيبسوم حقيقي على الإنترنت." },
                    { 10, 10, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3422), true, false, "InitialCreate", new DateTime(2021, 3, 29, 15, 23, 45, 790, DateTimeKind.Local).AddTicks(3423), "Ruby Makale Yorumu", "Lorem Ipsum，也称乱数假文或者哑元文本， 是印刷及排版领域所常用的虚拟文字。由于曾经一台匿名的打印机刻意打乱了一盒印刷字体从而造出一本字体样品书，Lorem Ipsum从西元15世纪起就被作为此领域的标准文本使用。它不仅延续了五个世纪，还通过了电子排版的挑战，其雏形却依然保存至今。在1960年代，”Leatraset”公司发布了印刷着Lorem Ipsum段落的纸张，从而广泛普及了它的使用。最近，计算机桌面出版软件”Aldus PageMaker”也通过同样的方式使Lorem Ipsum落入大众的视野。" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
