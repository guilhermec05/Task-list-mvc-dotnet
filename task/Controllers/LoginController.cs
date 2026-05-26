using AutoMapper;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using task.Domain.Models;
using task.Domain.ViewModels;
using task.Resources;
using task.Services.Impl;

namespace task.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly IAuthService _authService;
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;


        public LoginController(IAuthService authService, IUserServices userServices, IMapper mapper)
        {
            _authService = authService;
            _userServices = userServices;
            _mapper = mapper;
        }



        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel login)
        {

            try
            {

                if (await _authService.Login(login.User, login.Password))
                {
                    var user = await _userServices.GetUserByEmail(login.User);

                    PassAuth(user);

                    return Redirect("/task/index");

                }
                else
                {
                    TempData["ErrorMessage"] = Message.ErrorToLogin;
                }

            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
            }


            return Redirect("/");
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignUpUser(SignUpViewModel signUp)
        {

            User user = _mapper.Map<User>(signUp);

            await _userServices.CreateUser(user);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext
                .GetOwinContext()
                .Authentication
                .SignOut("ApplicationCookie");

            return RedirectToAction("Index", "Login");
        }

        private void PassAuth(User user)
        {
            if (user == null)
            {
                throw new Exception("UnAuthenticated");
            }

            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.Name , user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(
                "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                "ApplicationCookie"
            )

            };

            var Identity = new ClaimsIdentity(claim, "ApplicationCookie");
            HttpContext.GetOwinContext().Authentication.SignIn(Identity);
        }
    }
}