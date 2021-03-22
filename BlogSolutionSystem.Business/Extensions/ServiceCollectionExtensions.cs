using BlogSolutionSystem.Business.Implementaions;
using BlogSolutionSystem.Business.Interfaces;
using BlogSolutionSystem.Data.DataContext;
using BlogSolutionSystem.Data.Implementaions;
using BlogSolutionSystem.Data.Interfaces;
using BlogSolutionSystem.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection services)
        {
            services.AddDbContext<BlogSolutionSystemDataContext>();
            services.AddIdentity<User, Role>(opt =>
            {
                opt.Password.RequireDigit = false; //Rakam zorunluluğu 
                opt.Password.RequiredLength = 2; //Bir şifrenin karakter durumu
                opt.Password.RequiredUniqueChars = 0; // Özel karakter sayısının belirlendiği kısım
                opt.Password.RequireNonAlphanumeric = false; //Nokta Ünlem zorunlulugu
                opt.Password.RequireLowercase = false; //Küçük Harf Zorunluluğu 
                opt.Password.RequireUppercase = false; //Büyük Harf Zorunluluğu

                //User 
                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+"; //Kullanıcı adı eklerken izin verilen değerler

            }).AddEntityFrameworkStores<BlogSolutionSystemDataContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IArticleService, ArticleManager>();
            services.AddScoped<ICommentService, CommentManager>();
            return services;
        }
    }
}
