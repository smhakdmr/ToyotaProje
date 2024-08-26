using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Toyota.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceRepository());

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44332/api/Service/GetServiceEntry");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Service>>(jsonString);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Service service)
        {
            service.isActive = true;
            service.CreatedDateTime = DateTime.Now;
            ServiceValidator sv = new ServiceValidator();
            ValidationResult results = sv.Validate(service);
            if (results.IsValid)
            {
                var httpClient = new HttpClient();
                var jsonService = JsonConvert.SerializeObject(service);
                StringContent content = new StringContent(jsonService, Encoding.UTF8, "application/Json");
                var responseMessage = await httpClient.PostAsync("https://localhost:44332/api/Service/AddServiceEntry",
                     content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Servis başarıyla eklendi.";
                    return RedirectToAction("Index", "Service");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();

            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44332/api/Service/DeleteService/Id=" + Id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonService = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Service>(jsonService);
                TempData["SuccessMessage"] = "Servis başarıyla silindi.";
                return RedirectToAction("Index", "Service");
            }
            else
            {
                return View();
            }
        }
    }
}
