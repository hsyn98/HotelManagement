using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class SQLServiceRepository : IServiceRepository
    {
        private readonly AppDbContext context;

        public SQLServiceRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Services Add(Services service)
        {
            context.Services.Add(service);
            context.SaveChanges();
            return service;
        }

        public Services Delete(int id)
        {
            Services service = context.Services.Find(id);
            if (service != null)
            {
                context.Services.Remove(service);
                context.SaveChanges();
            }
            return service;
        }

        public IEnumerable<Services> GetAllServices()
        {
            return context.Services;
        }

        public Services GetService(int id)
        {
            return context.Services.Find(id);
        }

        public Services Update(Services serviceChanges)
        {
            var service = context.Services.Attach(serviceChanges);
            service.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return serviceChanges;
        }
    }
}
