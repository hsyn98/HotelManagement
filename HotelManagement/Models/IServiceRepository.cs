using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public interface IServiceRepository
    {
        Services Add(Services service);
        Services Update(Services serviceChanges);
        Services Delete(int id);
        Services GetService(int id);
        IEnumerable<Services> GetAllServices();
    }
}
