using AutoMapper;
using BlogSolutionSystem.Entities.Concrete;
using BlogSolutionSystem.Entities.Dtos.RoleD;
using BlogSolutionSystem.UI.Helpers.Abstract;
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
    public class RoleController : BaseController
    {
        private readonly RoleManager<Role> _roleManager;
        public RoleController(RoleManager<Role> roleManager, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper) : base(userManager, mapper, imageHelper)
        {
            _roleManager = roleManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var role = await _roleManager.Roles.ToListAsync();
            return View(new RoleListDto { Roles = role });
        }

        [Authorize]
        public async Task<IActionResult> Assign(int userId)
        {
            var user = await UserManager.Users.SingleOrDefaultAsync(c => c.Id == userId);
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await UserManager.GetRolesAsync(user);
            UserRoleAssignDto userRoleAssignDto = new UserRoleAssignDto
            {
                UserId = user.Id,
                UserName = user.UserName
            };
            foreach (var role in roles)
            {
                RoleAssignDto roleAssignDto = new RoleAssignDto
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    HasRole = userRoles.Contains(role.Name)
                };
                userRoleAssignDto.RoleAssignDtos.Add(roleAssignDto);
            }
            return PartialView("_RoleAssignPartial", userRoleAssignDto);
        }

        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> Assign(UserRoleAssignDto userRoleAssignDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await UserManager.Users.SingleOrDefaultAsync(x => x.Id == userRoleAssignDto.UserId);
        //        foreach (var item in userRoleAssignDto.RoleAssignDtos)
        //        {
        //            if (item.HasRole)
        //                await UserManager.AddToRoleAsync(user, item.RoleName);
        //            else
        //            {
        //                await UserManager.RemoveFromRoleAsync(user, item.RoleName);
        //            }

        //        }
        //    }
        //}
    }
}
