using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using task.Domain.Models;
using task.Domain.ViewModels;
using task.Shared.Helpers.Security;
using task.Services.Impl;

namespace task.Controllers
{

    [CustomAuthorizeAttribute]
    public class UserController : Controller
    {


        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;

        public UserController(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        // GET: User
        public async Task<ActionResult> Index()
        {
            var identity = (ClaimsIdentity)User.Identity;

            var userId = identity
                .FindFirst(ClaimTypes.NameIdentifier)
                ?.Value;

            var user = await _userServices.GetUser(int.Parse(userId));

            if (user == null)
            {
                return RedirectToAction("Login", "Index");

            }

            var userMapping =_mapper.Map<UserViewModel>(user);

            

            return View(userMapping);
        }

        public async Task<ActionResult> UpdateUser(UserViewModel userViewModel)
        {
            var user = _mapper.Map<User>(userViewModel);

            await _userServices.Update(user);

            TempData["SuccessMessage"] = Resources.UserMessages.UpdateSuccess;

            return RedirectToAction("Index");
        }
    }
}