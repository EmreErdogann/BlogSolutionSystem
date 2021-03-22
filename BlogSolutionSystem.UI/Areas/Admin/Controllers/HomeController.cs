using BlogSolutionSystem.Business.Interfaces;
using BlogSolutionSystem.Core.Utilities.Results.ComplexTypes;
using BlogSolutionSystem.Entities.Concrete;
using BlogSolutionSystem.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSolutionSystem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly UserManager<User> _userManager;
        public HomeController(ICategoryService categoryService, IArticleService articleService, ICommentService commentService, UserManager<User> userManager)
        {
            _categoryService = categoryService;
            _articleService = articleService;
            _commentService = commentService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var categoriesCount = _categoryService.Count();
            var articleCount = _articleService.Count();
            var commentCount = _commentService.Count();
            var userCount = await _userManager.Users.CountAsync();
            var article = _articleService.GetAllByDeleted();
            if (categoriesCount.ResultStatus == ResultStatus.Success && articleCount.ResultStatus == ResultStatus.Success && commentCount.ResultStatus == ResultStatus.Success && userCount > -1 && article.ResultStatus == ResultStatus.Success)
            {
                return View(new DashboardViewModel
                {
                    CategoriesCount = categoriesCount.Data,
                    ArticlesCount = articleCount.Data,
                    CommentsCount = commentCount.Data,
                    UsersCount = userCount,
                    Articles = article.Data
                });
            }
            return NotFound();
        }
    }
}
