using AHY.AdvertisementApp.Business.Abstract;
using AHY.AdvertisementApp.Common.Enums;
using AHY.AdvertisementApp.Common.Result.Concrete;
using AHY.AdvertisementApp.Dtos;
using AHY.AdvertisementApp.UI.Extensions;
using AHY.AdvertisementApp.UI.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AHY.AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderManager;
        private readonly IValidator<UserCreateModel> _userCreateModelValidator;
        private readonly IAppUserService _appUserManager;
        private readonly IMapper _mapper;
        public AccountController(IGenderService genderManager, IValidator<UserCreateModel> userCreateModelValidator, IAppUserService appUserManager, IMapper mapper)
        {
            _genderManager = genderManager;
            _userCreateModelValidator = userCreateModelValidator;
            _appUserManager = appUserManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> SignUp()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var genderList = await _genderManager.GetAllAsync();
            var model = new UserCreateModel()
            {
                Genders = new(genderList.Data, "Id", "Definition")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUpAsync(UserCreateModel userCreateModel)
        {
            var result = _userCreateModelValidator.Validate(userCreateModel);
            if (result.IsValid)
            {
                //_appUserManager.CreateWithRoleAsync();
                var dto = _mapper.Map<AppUserCreateDto>(userCreateModel);
                var createResponse = await _appUserManager.CreateWithRoleAsync(dto, (int)RoleType.Member);
                return this.ResponseRedirectToAction(createResponse, "SignIn");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            var genderResponse = await _genderManager.GetAllAsync();
            userCreateModel.Genders = new SelectList(genderResponse.Data, "Id", "Definition");
            return View(userCreateModel);
        }

        public IActionResult SignIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto dto, string returnUrl = "/Home/Index")
        {

            var result = await _appUserManager.CheckUser(dto);
            if (result.ResponseType == ResponseType.Success)
            {
                var roleResult = await _appUserManager.GetRolesByUserIdAsync(result.Data.Id);
                var claims = new List<Claim>();

                if (roleResult.ResponseType == ResponseType.Success)
                {
                    foreach (var item in roleResult.Data)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item.Definition));
                        claims.Add(new Claim(ClaimTypes.Name, result.Data.Firstname));
                    }

                }
                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = dto.RememberMe,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return Redirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", result.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }
    }
}
