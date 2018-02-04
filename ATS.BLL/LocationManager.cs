using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Common;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Repository;

namespace ATS.BLL
{
    public class LocationManager: CommonManager<Location>, ILocationManager
    {
        private ILocationRepository _locationRepository;
        public LocationManager() : base(new LocationRepository())
        {
            _locationRepository = (ILocationRepository) _repository;
        }


        //for cascading dropdown
        public ICollection<Branch> GetBranches(int id)
        {
            return _locationRepository.GetBranches(id);
        }
    }
}
