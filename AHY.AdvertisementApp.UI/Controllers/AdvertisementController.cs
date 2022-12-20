using AHY.AdvertisementApp.Business.Abstract;
using AHY.AdvertisementApp.Common.Enums;
using AHY.AdvertisementApp.Common.Result.Concrete;
using AHY.AdvertisementApp.Dtos;
using AHY.AdvertisementApp.Dtos.Concrete.MilitaryStatusDtos;
using AHY.AdvertisementApp.UI.Extensions;
using AHY.AdvertisementApp.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AHY.AdvertisementApp.UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAppUserService _appUserManager;
        private readonly IAdvertisementAppUserService _advertisementAppUserManager;

        public AdvertisementController(IAppUserService appUserManager, IAdvertisementAppUserService advertisementAppUserManager)
        {
            _appUserManager = appUserManager;
            _advertisementAppUserManager = advertisementAppUserManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Member")]
        public async Task<IActionResult> Send(int advertisementId)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var userResponse =await _appUserManager.GetByIdAsync<AppUserListDto>(userId);

            ViewBag.GenderId= userResponse.Data.GenderId;

            var items = Enum.GetValues(typeof(MilitaryStatusType));
            var list = new List<MilitaryStatusListDto>();
            foreach (int item in items)
            {
                list.Add(new MilitaryStatusListDto
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item)
                });
            }

            ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");
            return View(new AdvertisementAppUserCreateModel()
            {
                AppUserId= userId,
                AdvertisementId=advertisementId,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Send(AdvertisementAppUserCreateModel model)
        {
            AdvertisementAppUserCreateDto dto = new();

            if (model.CvFile != null)
            {
                var fileName = Guid.NewGuid().ToString();
                var extName = Path.GetExtension(model.CvFile.FileName);
                string path =Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","cvFiles", fileName + extName);
                var stream = new FileStream(path,FileMode.Create);
                await model.CvFile.CopyToAsync(stream);
                dto.CvPath = path;
            }

            dto.AdvertisementAppUserStatusId = model.AdvertisementAppUserStatusId;
            dto.AdvertisementId = model.AdvertisementId;
            dto.AppUserId = model.AppUserId;
            dto.EndDate = model.EndDate;
            dto.MilitaryStatusId = model.MilitaryStatusId;
            dto.WorkExperience = model.WorkExperience;

            var response = await _advertisementAppUserManager.CreateAsync(dto);



            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var item in response.ValidationErrors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("HumanResource", "Home");
            }
        }
    }
}
