using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Common;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel.Partial;
using ATS.Models.Models.ViewModel.PartialView;
using ATS.Repository;

namespace ATS.BLL
{
    public class ServiceManager: CommonManager<Service>, IServiceManager
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceManager() : base(new ServiceRepository())
        {
            _serviceRepository=base._repository as IServiceRepository;
        }

        public List<Service> GetServiceDetails(int id)
        {
            return _serviceRepository.GetServiceDetails(id);
        }
    }
}
