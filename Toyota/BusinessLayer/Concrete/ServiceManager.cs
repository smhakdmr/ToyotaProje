using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ServiceManager : IServiceService
    {
        IService _service;

        public ServiceManager(IService service)
        {
            _service = service;
        }

        public void Add(Service t)
        {
           _service.Insert(t);
        }

        public void Delete(Service t)
        {
            _service.Delete(t);
        }

        public Service GetById(int id)
        {
            return _service.GetById(id);
        }

        public List<Service> GetList()
        {
            Context context = new Context();
            var list = context.Services.FromSqlRaw("EXEC GetAllServices").ToList();
            return list;
        }

        public void Update(Service t)
        {
            _service.Update(t);
        }
    }
}
