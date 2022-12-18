using AHY.AdvertisementApp.Business.Abstract;
using AHY.AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

/* 
 1- DTO OLUŞTUR
 2- DTO VALIDATIONLARI OLUŞTUR
 3- DAHA SONRA VALIDATIONLARI EXTENSIONA KAYDET
 4- BU DTO'NUN MAP PROFILE'NI OLUŞTUR, BUNU DEPENDENCY EXTENSIONA KAYDET.
 5- SONRA GEL BUSINESSDAKİ İLGİLİ SERVİS İÇİN ABSTRACT VE CONCRETELERİNİ OLUŞTUR.
 6- SON OLARAK DA OLUŞTURDUKLARINI GEL UI'DA KULLAN.
 */


namespace AHY.AdvertisementApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceService _providedServiceManager;
        private readonly IAdvertisementService _advertisementManager;

        public HomeController(IProvidedServiceService providedServiceManager, IAdvertisementService advertisementManager)
        {
            _providedServiceManager = providedServiceManager;
            _advertisementManager = advertisementManager;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _providedServiceManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> HumanResource()
        {
            var response = await _advertisementManager.GetActivesAsync();
            return this.ResponseView(response);
        }
    }


}

