using AutoMapper;
using BlogSolutionSystem.Business.Interfaces;
using BlogSolutionSystem.Core.Utilities.Results.ComplexTypes;
using BlogSolutionSystem.Entities.Concrete;
using BlogSolutionSystem.UI.Helpers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlogSolutionSystem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : BaseController
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService, IMapper mapper, IImageHelper imageHelper, UserManager<User> userManager) : base(userManager, mapper, imageHelper)
        {
            _commentService = commentService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var result = _commentService.GetAllByDeleted();
            return View(result.Data);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetDetail(int commentId)
        {
            var result = _commentService.Get(commentId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return PartialView("_CommentDetailPartial", result.Data);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Approve(int commentId)
        {
            var result = _commentService.Approve(commentId, LoggedInUser.UserName);
            var commentResult = JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(commentResult);
        }
    }
}
