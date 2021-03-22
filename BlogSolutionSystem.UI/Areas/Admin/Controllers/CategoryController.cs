using BlogSolutionSystem.Business.Interfaces;
using BlogSolutionSystem.Core.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSolutionSystem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var result = _categoryService.GetAllByDeleted();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }
        public IActionResult Add()
        {
            return PartialView("_CategoryAddPartial");
        }
    }
}
