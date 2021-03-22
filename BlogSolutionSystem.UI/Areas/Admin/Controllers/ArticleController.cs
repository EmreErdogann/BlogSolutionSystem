using BlogSolutionSystem.Business.Interfaces;
using BlogSolutionSystem.Core.Utilities.Results.ComplexTypes;
using BlogSolutionSystem.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSolutionSystem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        public ArticleController(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var article = _articleService.GetAllByDeleted();
            if (article.ResultStatus == ResultStatus.Success) return View(article.Data);
            return NotFound();
        }

        public IActionResult Add()
        {
            var result = _categoryService.GetAllByDeleted();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(new ArticleAddViewModel
                {
                    Categories = result.Data.Categories
                });
            }
            return NotFound();
        }
    }
}
