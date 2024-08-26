using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ToyotaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceRepository());
        [HttpPost("AddServiceEntry")]
        public IActionResult Add(Service service)
        {
            ServiceValidator sv = new ServiceValidator();
            ValidationResult results = sv.Validate(service);
            if (results.IsValid)
            {
                service.isActive = true;
                service.CreatedDateTime = DateTime.Now;
                serviceManager.Add(service);
                return Ok(service);
            }
            else
            {
                return BadRequest("Hata!");
            }
        }
        [HttpGet("GetServiceEntry")]
        public IActionResult GetAll()
        {
            var values = serviceManager.GetList();
            return Ok(values);
        }

        [HttpGet("GetServiceEntryById/Id={id}")]
        public IActionResult GetById(int id)
        {
            using var c = new Context();
            var value = c.Services.Find(id);
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("DeleteService/Id={id}")]
        public IActionResult Delete(int id)
        {
            using var c = new Context();
            var value = c.Services.Find(id);
            if (value != null)
            {
                value.isActive= false;
                c.SaveChanges();
                return Ok(value);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("UpdateService/Id={id}")]
        public IActionResult Update(Service service)
        {
            using var c = new Context();
            var value = c.Services.Find(service.Id);
            if (value != null)
            {
                service.CreatedDateTime = value.CreatedDateTime;
                service.isActive = value.isActive;
                value = service;
                c.SaveChanges();
                return Ok(value);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
