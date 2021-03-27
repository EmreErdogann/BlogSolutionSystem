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
                name: "AspNetUsers",
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
                    Picture = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AspNetRoleClaims",
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
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                        name: "FK_Articles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                    { 1, "cbf28225-1514-4fd6-95d9-1a4d484e7094", "Admin", "ADMIN" },
                    { 2, "818078f8-5159-4615-9a5b-e8ba3da3df95", "Editor", "EDITOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "177a63fd-de90-49a0-9b8b-d0e6cb1e19a3", "adminuser@gmail.com", true, false, null, "ADMINUSER@GMAIL.COM", "ADMINUSER", "AQAAAAEAACcQAAAAEK4jBT5alSfeTJOjLyiMhWSyqf9l1Qb8riUFq+0KctEnjRqoCXXWutNb1Lrfs3OZCQ==", "05375715692", true, "defaultUser.png", "9ac71734-8594-4187-9557-7f8f77345755", false, "adminuser" },
                    { 2, 0, "f865b079-b72f-4ae3-809a-4dff54618ccf", "editoruser@gmail.com", true, false, null, "EDITORUSER@GMAIL.COM", "EDITORUSER", "AQAAAAEAACcQAAAAEMYv94mqCV50VtxttXwaWaeV+RVzzjrpOOSXrMcjELZTY2/aExnnK239ev0oLvQ0Wg==", "+905555555555", true, "defaultUser.png", "e50e2fec-3c12-45ed-91e9-496ec8741eb1", false, "editoruser" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9396), "C# Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9405), "C#", "C# Blog Kategorisi" },
                    { 2, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9435), "C++ Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9436), "C++", "C++ Blog Kategorisi" },
                    { 3, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9439), "JavaScript Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9440), "JavaScript", "JavaScript Blog Kategorisi" },
                    { 4, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9442), "TypeScript Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9443), "TypeScript", "TypeScript Blog Kategorisi" },
                    { 5, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9444), "Java Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9446), "Java", "Java Blog Kategorisi" },
                    { 6, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9448), "Python Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9449), "Python", "Python Blog Kategorisi" },
                    { 7, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9450), "Php Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9452), "Php", "Php Blog Kategorisi" },
                    { 8, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9453), "Kotlin Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9454), "Kotlin", "Kotlin Blog Kategorisi" },
                    { 9, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9456), "Swift Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9457), "Swift", "Swift Blog Kategorisi" },
                    { 10, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9460), "Ruby Programlama Dili ile İlgili En Güncel Bilgiler", false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 777, DateTimeKind.Local).AddTicks(9461), "Ruby", "Ruby Blog Kategorisi" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { 1, 1, 1, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(5320), new DateTime(2021, 3, 27, 14, 35, 50, 773, DateTimeKind.Local).AddTicks(4459), false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(6209), "C# 9.0 ve .NET 5 Yenilikleri", "Emre Erdoğan", "C# 9.0 ve .NET 5 Yenilikleri", "C#, C# 9, .NET5, .NET Framework, .NET Core", "Default.jpg", "C# 9.0 ve .NET 5 Yenilikleri", 1, 100 },
                    { 2, 2, 1, "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8133), new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8120), false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8135), "C++ 11 ve 19 Yenilikleri", "Emre Erdoğan", "C++ 11 ve 19 Yenilikleri", "C++ 11 ve 19 Yenilikleri", "Default.jpg", "C++ 11 ve 19 Yenilikleri", 1, 295 },
                    { 3, 3, 7, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.", "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8157), new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8156), false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8159), "JavaScript ES2020 ve ES2021 Yenilikleri", "Emre Erdoğan", "JavaScript ES2020 ve ES2021 Yenilikleri", "JavaScript ES2020 ve ES2021 Yenilikleri", "Default.jpg", "JavaScript ES2020 ve ES2021 Yenilikleri", 1, 67 },
                    { 4, 4, 2, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.", "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8162), new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8161), false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8163), "TypeScript ES2020 ve ES2021 Yenilikleri", "Emre Erdoğan", "TypeScript ES2020 ve ES2021 Yenilikleri", "TypeScript ES2020 ve ES2021 Yenilikleri", "Default.jpg", "TypeScript ES2020 ve ES2021 Yenilikleri", 1, 17 },
                    { 5, 5, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.", "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8167), new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8165), false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8168), "Php 7.4 ES2020  Yenilikleri", "Emre Erdoğan", "Php 7.4 ES2020 Yenilikleri", "Php 7.4 ES2020 Yenilikleri", "Default.jpg", "Php 7.4 ES2020 Yenilikleri", 1, 172 },
                    { 6, 6, 8, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.", "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8171), new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8170), false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8172), "React Native  Yenilikleri", "Emre Erdoğan", "React Native Yenilikleri", "Php 7.4 ES2020 Yenilikleri", "Default.jpg", "React Native Yenilikleri", 1, 62 },
                    { 7, 7, 0, "Contrairement à une opinion répandue, le Lorem Ipsum n'est pas simplement du texte aléatoire. Il trouve ses racines dans une oeuvre de la littérature latine classique datant de 45 av. J.-C., le rendant vieux de 2000 ans. Un professeur du Hampden-Sydney College, en Virginie, s'est intéressé à un des mots latins les plus obscurs, consectetur, extrait d'un passage du Lorem Ipsum, et en étudiant tous les usages de ce mot dans la littérature classique, découvrit la source incontestable du Lorem Ipsum. Il provient en fait des sections 1.10.32 et 1.10.33 du 0De Finibus Bonorum et Malorum' (Des Suprêmes Biens et des Suprêmes Maux) de Cicéron. Cet ouvrage, très populaire pendant la Renaissance, est un traité sur la théorie de l'éthique. Les premières lignes du Lorem Ipsum, 'Lorem ipsum dolor sit amet...'', proviennent de la section 1.10.32", "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8175), new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8174), false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8176), "PHP", "Emre Erdoğan", "Php ile API Oluşturma Rehberi", "php, laravel, api, oop", "postImages/defaultThumbnail.jpg", "Php Laravel Başlangıç Rehberi | API", 1, 4818 },
                    { 8, 8, 0, "Plusieurs variations de Lorem Ipsum peuvent être trouvées ici ou là, mais la majeure partie d'entre elles a été altérée par l'addition d'humour ou de mots aléatoires qui ne ressemblent pas une seconde à du texte standard. Si vous voulez utiliser un passage du Lorem Ipsum, vous devez être sûr qu'il n'y a rien d'embarrassant caché dans le texte. Tous les générateurs de Lorem Ipsum sur Internet tendent à reproduire le même extrait sans fin, ce qui fait de lipsum.com le seul vrai générateur de Lorem Ipsum. Iil utilise un dictionnaire de plus de 200 mots latins, en combinaison de plusieurs structures de phrases, pour générer un Lorem Ipsum irréprochable. Le Lorem Ipsum ainsi obtenu ne contient aucune répétition, ni ne contient des mots farfelus, ou des touches d'humour.", "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8179), new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8178), false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8181), "Kotlin", "Emre Erdoğan", "Kotlin ile Mobil Programlama Baştan Sona Adım Adım", "kotlin, android, mobil, programlama", "postImages/defaultThumbnail.jpg", "Kotlin ile Mobil Programlama", 1, 750 },
                    { 9, 9, 0, "Al contrario di quanto si pensi, Lorem Ipsum non è semplicemente una sequenza casuale di caratteri. Risale ad un classico della letteratura latina del 45 AC, cosa che lo rende vecchio di 2000 anni. Richard McClintock, professore di latino al Hampden-Sydney College in Virginia, ha ricercato una delle più oscure parole latine, consectetur, da un passaggio del Lorem Ipsum e ha scoperto tra i vari testi in cui è citata, la fonte da cui è tratto il testo, le sezioni 1.10.32 and 1.10.33 del 'de Finibus Bonorum et Malorum' di Cicerone. Questo testo è un trattato su teorie di etica, molto popolare nel Rinascimento. La prima riga del Lorem Ipsum, 'Lorem ipsum dolor sit amet..'', è tratta da un passaggio della sezione 1.10.32.", "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8184), new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8183), false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8185), "Swift", "Emre Erdoğan", "Swift ile IOS Mobil Programlama Baştan Sona Adım Adım", "IOS, android, mobil, programlama", "postImages/defaultThumbnail.jpg", "Swift ile IOS Programlama", 1, 14900 },
                    { 10, 10, 0, "Esistono innumerevoli variazioni dei passaggi del Lorem Ipsum, ma la maggior parte hanno subito delle variazioni del tempo, a causa dell’inserimento di passaggi ironici, o di sequenze casuali di caratteri palesemente poco verosimili. Se si decide di utilizzare un passaggio del Lorem Ipsum, è bene essere certi che non contenga nulla di imbarazzante. In genere, i generatori di testo segnaposto disponibili su internet tendono a ripetere paragrafi predefiniti, rendendo questo il primo vero generatore automatico su intenet. Infatti utilizza un dizionario di oltre 200 vocaboli latini, combinati con un insieme di modelli di strutture di periodi, per generare passaggi di testo verosimili. Il testo così generato è sempre privo di ripetizioni, parole imbarazzanti o fuori luogo ecc.", "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8188), new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8187), false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 774, DateTimeKind.Local).AddTicks(8189), "Ruby", "Emre Erdoğan", "Ruby, Ruby on Rails Web Programlama, AirBnb Klon", "Ruby on Rails, Ruby, Web Programlama, AirBnb", "postImages/defaultThumbnail.jpg", "Ruby on Rails ile AirBnb Klon Kodlayalım", 1, 26777 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
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
                    { 1, 1, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6805), true, false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6812), "C# Makale Yorumu", "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır." },
                    { 2, 2, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6854), true, false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6856), "C++ Makale Yorumu", "Lorem Ipsum jest tekstem stosowanym jako przykładowy wypełniacz w przemyśle poligraficznym. Został po raz pierwszy użyty w XV w. przez nieznanego drukarza do wypełnienia tekstem próbnej książki. Pięć wieków później zaczął być używany przemyśle elektronicznym, pozostając praktycznie niezmienionym. Spopularyzował się w latach 60. XX w. wraz z publikacją arkuszy Letrasetu, zawierających fragmenty Lorem Ipsum, a ostatnio z zawierającym różne wersje Lorem Ipsum oprogramowaniem przeznaczonym do realizacji druków na komputerach osobistych, jak Aldus PageMaker" },
                    { 3, 3, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6858), true, false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6859), "JavaScript Makale Yorumu", "Ang Lorem Ipsum ay ginagamit na modelo ng industriya ng pagpriprint at pagtytypeset. Ang Lorem Ipsum ang naging regular na modelo simula pa noong 1500s, noong may isang di kilalang manlilimbag and kumuha ng galley ng type at ginulo ang pagkaka-ayos nito upang makagawa ng libro ng mga type specimen. Nalagpasan nito hindi lang limang siglo, kundi nalagpasan din nito ang paglaganap ng electronic typesetting at nanatiling parehas. Sumikat ito noong 1960s kasabay ng pag labas ng Letraset sheets na mayroong mga talata ng Lorem Ipsum, at kamakailan lang sa mga desktop publishing software tulad ng Aldus Pagemaker ginamit ang mga bersyon ng Lorem Ipsum." },
                    { 4, 4, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6861), true, false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6862), "Typescript Makale Yorumu", "Lorem Ipsum er rett og slett dummytekst fra og for trykkeindustrien. Lorem Ipsum har vært bransjens standard for dummytekst helt siden 1500-tallet, da en ukjent boktrykker stokket en mengde bokstaver for å lage et prøveeksemplar av en bok. Lorem Ipsum har tålt tidens tann usedvanlig godt, og har i tillegg til å bestå gjennom fem århundrer også tålt spranget over til elektronisk typografi uten vesentlige endringer. Lorem Ipsum ble gjort allment kjent i 1960-årene ved lanseringen av Letraset-ark med avsnitt fra Lorem Ipsum, og senere med sideombrekkingsprogrammet Aldus PageMaker som tok i bruk nettopp Lorem Ipsum for dummytekst." },
                    { 5, 5, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6864), true, false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6865), "Java Makale Yorumu", "Lorem Ipsum este pur şi simplu o machetă pentru text a industriei tipografice. Lorem Ipsum a fost macheta standard a industriei încă din secolul al XVI-lea, când un tipograf anonim a luat o planşetă de litere şi le-a amestecat pentru a crea o carte demonstrativă pentru literele respective. Nu doar că a supravieţuit timp de cinci secole, dar şi a facut saltul în tipografia electronică practic neschimbată. A fost popularizată în anii '60 odată cu ieşirea colilor Letraset care conţineau pasaje Lorem Ipsum, iar mai recent, prin programele de publicare pentru calculator, ca Aldus PageMaker care includeau versiuni de Lorem Ipsum." },
                    { 6, 6, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6867), true, false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6868), "Python Makale Yorumu", "Lorem Ipsum je jednostavno probni tekst koji se koristi u tiskarskoj i slovoslagarskoj industriji. Lorem Ipsum postoji kao industrijski standard još od 16-og stoljeća, kada je nepoznati tiskar uzeo tiskarsku galiju slova i posložio ih da bi napravio knjigu s uzorkom tiska. Taj je tekst ne samo preživio pet stoljeća, već se i vinuo u svijet elektronskog slovoslagarstva, ostajući u suštini nepromijenjen. Postao je popularan tijekom 1960-ih s pojavom Letraset listova s odlomcima Lorem Ipsum-a, a u skorije vrijeme sa software-om za stolno izdavaštvo kao što je Aldus PageMaker koji također sadrži varijante Lorem Ipsum-a." },
                    { 7, 7, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6870), true, false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6871), "Php Makale Yorumu", "Lorem Ipsum – tas ir teksta salikums, kuru izmanto poligrāfijā un maketēšanas darbos. Lorem Ipsum ir kļuvis par vispārpieņemtu teksta aizvietotāju kopš 16. gadsimta sākuma. Tajā laikā kāds nezināms iespiedējs izveidoja teksta fragmentu, lai nodrukātu grāmatu ar burtu paraugiem. Tas ir ne tikai pārdzīvojis piecus gadsimtus, bet bez ievērojamām izmaiņām saglabājies arī mūsdienās, pārejot uz datorizētu teksta apstrādi. Tā popularizēšanai 60-tajos gados kalpoja Letraset burtu paraugu publicēšana ar Lorem Ipsum teksta fragmentiem un, nesenā pagātnē, tādas maketēšanas programmas kā Aldus PageMaker, kuras šablonu paraugos ir izmantots Lorem Ipsum teksts." },
                    { 8, 8, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6873), true, false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6874), "Kotlin Makale Yorumu", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)." },
                    { 9, 9, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6875), true, false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6877), "Swift Makale Yorumu", "هنالك العديد من الأنواع المتوفرة لنصوص لوريم إيبسوم، ولكن الغالبية تم تعديلها بشكل ما عبر إدخال بعض النوادر أو الكلمات العشوائية إلى النص. إن كنت تريد أن تستخدم نص لوريم إيبسوم ما، عليك أن تتحقق أولاً أن ليس هناك أي كلمات أو عبارات محرجة أو غير لائقة مخبأة في هذا النص. بينما تعمل جميع مولّدات نصوص لوريم إيبسوم على الإنترنت على إعادة تكرار مقاطع من نص لوريم إيبسوم نفسه عدة مرات بما تتطلبه الحاجة، يقوم مولّدنا هذا باستخدام كلمات من قاموس يحوي على أكثر من 200 كلمة لا تينية، مضاف إليها مجموعة من الجمل النموذجية، لتكوين نص لوريم إيبسوم ذو شكل منطقي قريب إلى النص الحقيقي. وبالتالي يكون النص الناتح خالي من التكرار، أو أي كلمات أو عبارات غير لائقة أو ما شابه. وهذا ما يجعله أول مولّد نص لوريم إيبسوم حقيقي على الإنترنت." },
                    { 10, 10, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6878), true, false, "InitialCreate", new DateTime(2021, 3, 27, 14, 35, 50, 780, DateTimeKind.Local).AddTicks(6880), "Ruby Makale Yorumu", "Lorem Ipsum，也称乱数假文或者哑元文本， 是印刷及排版领域所常用的虚拟文字。由于曾经一台匿名的打印机刻意打乱了一盒印刷字体从而造出一本字体样品书，Lorem Ipsum从西元15世纪起就被作为此领域的标准文本使用。它不仅延续了五个世纪，还通过了电子排版的挑战，其雏形却依然保存至今。在1960年代，”Leatraset”公司发布了印刷着Lorem Ipsum段落的纸张，从而广泛普及了它的使用。最近，计算机桌面出版软件”Aldus PageMaker”也通过同样的方式使Lorem Ipsum落入大众的视野。" }
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
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
