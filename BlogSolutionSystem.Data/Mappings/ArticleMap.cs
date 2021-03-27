using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSolutionSystem.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSolutionSystem.Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Title).HasMaxLength(100);
            builder.Property(a => a.Title).IsRequired(true);
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(50);
            builder.Property(a => a.SeoDescription).HasMaxLength(150);
            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(70);
            builder.Property(a => a.ViewsCount).IsRequired();
            builder.Property(a => a.CommentCount).IsRequired();
            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(250);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);
            builder.HasOne(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);
            builder.HasOne(a => a.User).WithMany(u => u.Articles).HasForeignKey(a => a.UserId);
            builder.ToTable("Articles");

            builder.HasData(
            new Article
            {
                Id = 1,
                CategoryId = 1,
                Title = "C# 9.0 ve .NET 5 Yenilikleri",
                Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                Thumbnail = "Default.jpg",
                SeoDescription = "C# 9.0 ve .NET 5 Yenilikleri",
                SeoTags = "C#, C# 9, .NET5, .NET Framework, .NET Core",
                SeoAuthor = "Emre Erdoğan",
                Date = DateTime.Now,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C# 9.0 ve .NET 5 Yenilikleri",
                UserId = 1,
                ViewsCount = 100,
                CommentCount = 1
            },
            new Article
            {
                Id = 2,
                CategoryId = 2,
                Title = "C++ 11 ve 19 Yenilikleri",
                Content = "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
                Thumbnail = "Default.jpg",
                SeoDescription = "C++ 11 ve 19 Yenilikleri",
                SeoTags = "C++ 11 ve 19 Yenilikleri",
                SeoAuthor = "Emre Erdoğan",
                Date = DateTime.Now,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C++ 11 ve 19 Yenilikleri",
                UserId = 1,
                ViewsCount = 295,
                CommentCount = 1
            },
            new Article
            {
                Id = 3,
                CategoryId = 3,
                Title = "JavaScript ES2020 ve ES2021 Yenilikleri",
                Content = "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.",
                Thumbnail = "Default.jpg",
                SeoDescription = "JavaScript ES2020 ve ES2021 Yenilikleri",
                SeoTags = "JavaScript ES2020 ve ES2021 Yenilikleri",
                SeoAuthor = "Emre Erdoğan",
                Date = DateTime.Now,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "JavaScript ES2020 ve ES2021 Yenilikleri",
                UserId = 1,
                ViewsCount = 67,
                CommentCount = 7
            },
              new Article
              {
                  Id = 4,
                  CategoryId = 4,
                  Title = "TypeScript ES2020 ve ES2021 Yenilikleri",
                  Content = "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.",
                  Thumbnail = "Default.jpg",
                  SeoDescription = "TypeScript ES2020 ve ES2021 Yenilikleri",
                  SeoTags = "TypeScript ES2020 ve ES2021 Yenilikleri",
                  SeoAuthor = "Emre Erdoğan",
                  Date = DateTime.Now,
                  IsDeleted = false,
                  CreatedByName = "InitialCreate",
                  CreatedDate = DateTime.Now,
                  ModifiedByName = "InitialCreate",
                  ModifiedDate = DateTime.Now,
                  Note = "TypeScript ES2020 ve ES2021 Yenilikleri",
                  UserId = 1,
                  ViewsCount = 17,
                  CommentCount = 2
              },
               new Article
               {
                   Id = 5,
                   CategoryId = 5,
                   Title = "Php 7.4 ES2020 Yenilikleri",
                   Content = "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.",
                   Thumbnail = "Default.jpg",
                   SeoDescription = "Php 7.4 ES2020 Yenilikleri",
                   SeoTags = "Php 7.4 ES2020 Yenilikleri",
                   SeoAuthor = "Emre Erdoğan",
                   Date = DateTime.Now,
                   IsDeleted = false,
                   CreatedByName = "InitialCreate",
                   CreatedDate = DateTime.Now,
                   ModifiedByName = "InitialCreate",
                   ModifiedDate = DateTime.Now,
                   Note = "Php 7.4 ES2020  Yenilikleri",
                   UserId = 1,
                   ViewsCount = 172,
                   CommentCount = 1
               },
                new Article
                {
                    Id = 6,
                    CategoryId = 6,
                    Title = "React Native Yenilikleri",
                    Content = "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "React Native Yenilikleri",
                    SeoTags = "Php 7.4 ES2020 Yenilikleri",
                    SeoAuthor = "Emre Erdoğan",
                    Date = DateTime.Now,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "React Native  Yenilikleri",
                    UserId = 1,
                    ViewsCount = 62,
                    CommentCount = 8
                }
                   ,
                new Article
                {
                    Id = 7,
                    CategoryId = 7,
                    Title = "Php Laravel Başlangıç Rehberi | API",
                    Content =  $"Contrairement à une opinion répandue, le Lorem Ipsum n'est pas simplement du texte aléatoire. Il trouve ses racines dans une oeuvre de la littérature latine classique datant de 45 av. J.-C., le rendant vieux de 2000 ans. Un professeur du Hampden-Sydney College, en Virginie, s'est intéressé à un des mots latins les plus obscurs, consectetur, extrait d'un passage du Lorem Ipsum, et en étudiant tous les usages de ce mot dans la littérature classique, découvrit la source incontestable du Lorem Ipsum. Il provient en fait des sections 1.10.32 et 1.10.33 du 0De Finibus Bonorum et Malorum' (Des Suprêmes Biens et des Suprêmes Maux) de Cicéron. Cet ouvrage, très populaire pendant la Renaissance, est un traité sur la théorie de l'éthique. Les premières lignes du Lorem Ipsum, 'Lorem ipsum dolor sit amet...'', proviennent de la section 1.10.32",
                    Thumbnail = "postImages/defaultThumbnail.jpg",
                    SeoDescription = "Php ile API Oluşturma Rehberi",
                    SeoTags = "php, laravel, api, oop",
                    SeoAuthor = "Emre Erdoğan",
                    Date = DateTime.Now,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "PHP",
                    UserId = 1,
                    ViewsCount = 4818,
                    CommentCount = 0
                }
                ,
                new Article
                {
                    Id = 8,
                    CategoryId = 8,
                    Title = "Kotlin ile Mobil Programlama",
                    Content =   $"Plusieurs variations de Lorem Ipsum peuvent être trouvées ici ou là, mais la majeure partie d'entre elles a été altérée par l'addition d'humour ou de mots aléatoires qui ne ressemblent pas une seconde à du texte standard. Si vous voulez utiliser un passage du Lorem Ipsum, vous devez être sûr qu'il n'y a rien d'embarrassant caché dans le texte. Tous les générateurs de Lorem Ipsum sur Internet tendent à reproduire le même extrait sans fin, ce qui fait de lipsum.com le seul vrai générateur de Lorem Ipsum. Iil utilise un dictionnaire de plus de 200 mots latins, en combinaison de plusieurs structures de phrases, pour générer un Lorem Ipsum irréprochable. Le Lorem Ipsum ainsi obtenu ne contient aucune répétition, ni ne contient des mots farfelus, ou des touches d'humour.",
                    Thumbnail = "postImages/defaultThumbnail.jpg",
                    SeoDescription = "Kotlin ile Mobil Programlama Baştan Sona Adım Adım",
                    SeoTags = "kotlin, android, mobil, programlama",
                    SeoAuthor = "Emre Erdoğan",
                    Date = DateTime.Now,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Kotlin",
                    UserId = 1,
                    ViewsCount = 750,
                    CommentCount = 0
                }
                ,
                new Article
                {
                    Id = 9,
                    CategoryId = 9,
                    Title = "Swift ile IOS Programlama",
                    Content = $"Al contrario di quanto si pensi, Lorem Ipsum non è semplicemente una sequenza casuale di caratteri. Risale ad un classico della letteratura latina del 45 AC, cosa che lo rende vecchio di 2000 anni. Richard McClintock, professore di latino al Hampden-Sydney College in Virginia, ha ricercato una delle più oscure parole latine, consectetur, da un passaggio del Lorem Ipsum e ha scoperto tra i vari testi in cui è citata, la fonte da cui è tratto il testo, le sezioni 1.10.32 and 1.10.33 del 'de Finibus Bonorum et Malorum' di Cicerone. Questo testo è un trattato su teorie di etica, molto popolare nel Rinascimento. La prima riga del Lorem Ipsum, 'Lorem ipsum dolor sit amet..'', è tratta da un passaggio della sezione 1.10.32.",
                    Thumbnail = "postImages/defaultThumbnail.jpg",
                    SeoDescription = "Swift ile IOS Mobil Programlama Baştan Sona Adım Adım",
                    SeoTags = "IOS, android, mobil, programlama",
                    SeoAuthor = "Emre Erdoğan",
                    Date = DateTime.Now,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Swift",
                    UserId = 1,
                    ViewsCount = 14900,
                    CommentCount = 0
                }
                ,
                new Article
                {
                    Id = 10,
                    CategoryId = 10,
                    Title = "Ruby on Rails ile AirBnb Klon Kodlayalım",
                    Content = $"Esistono innumerevoli variazioni dei passaggi del Lorem Ipsum, ma la maggior parte hanno subito delle variazioni del tempo, a causa dell’inserimento di passaggi ironici, o di sequenze casuali di caratteri palesemente poco verosimili. Se si decide di utilizzare un passaggio del Lorem Ipsum, è bene essere certi che non contenga nulla di imbarazzante. In genere, i generatori di testo segnaposto disponibili su internet tendono a ripetere paragrafi predefiniti, rendendo questo il primo vero generatore automatico su intenet. Infatti utilizza un dizionario di oltre 200 vocaboli latini, combinati con un insieme di modelli di strutture di periodi, per generare passaggi di testo verosimili. Il testo così generato è sempre privo di ripetizioni, parole imbarazzanti o fuori luogo ecc.",
                    Thumbnail = "postImages/defaultThumbnail.jpg",
                    SeoDescription = "Ruby, Ruby on Rails Web Programlama, AirBnb Klon",
                    SeoTags = "Ruby on Rails, Ruby, Web Programlama, AirBnb",
                    SeoAuthor = "Emre Erdoğan",
                    Date = DateTime.Now,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Ruby",
                    UserId = 1,
                    ViewsCount = 26777,
                    CommentCount = 0
                }
                );
        }

    }
}