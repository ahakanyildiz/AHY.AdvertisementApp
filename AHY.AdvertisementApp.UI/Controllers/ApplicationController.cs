using AHY.AdvertisementApp.Business.Abstract;
using AHY.AdvertisementApp.Dtos;
using AHY.AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AHY.AdvertisementApp.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ApplicationController : Controller
    {
        private readonly IAdvertisementService _advertisementManager;

        public ApplicationController(IAdvertisementService advertisementManager)
        {
            _advertisementManager = advertisementManager;
        }

        public async Task<IActionResult> List()
        {
            var response =await _advertisementManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public IActionResult Create()
        {
            return View(new AdvertisementCreateDto());
        }

        [HttpPost]
        public async  Task<IActionResult> Create(AdvertisementCreateDto dto)
        {
            var response =await _advertisementManager.CreateAsync(dto);
            return this.ResponseRedirectToAction(response,"List","Application");
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _advertisementManager.GetByIdAsync<AdvertisementUpdateDto>(id);
            return this.ResponseView(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdvertisementUpdateDto dto)
        {
            var response = await _advertisementManager.UpdateAsync(dto);
            return this.ResponseRedirectToAction(response, "List");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _advertisementManager.RemoveAsync(id);
            return this.ResponseRedirectToAction(response,"List");
        }
    }
}
