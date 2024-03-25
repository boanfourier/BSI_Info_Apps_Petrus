using BSI_Info_APIService_Data.Interface;
using BSI_Info_APIService_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_Info_APIService_Data.Interface
{
    public interface IEventsData : ICrudData<Events>
    {
        Task<IEnumerable<Events>> GetByName(string name);
        Task<int> InsertWithIdentity(Events events);
    }
}

