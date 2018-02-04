using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Common;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.CheckIn;
using ATS.Repository;

namespace ATS.BLL
{
    public class CheckInManager:CommonManager<CheckIn>, ICheckInManager
    {
        private ICheckInRepository _checkInRepository;
        public CheckInManager() : base(new CheckInRepository())
        {
            _checkInRepository=base._repository as ICheckInRepository;
        }

        public List<CheckInCreateVm> SearchAssetForCheckIn(int id)
        {
            return _checkInRepository.SearchAssetForCheckIn(id);
        }

        public List<CheckInCreateVm> GetAssetById(int id)
        {
            return _checkInRepository.GetAssetById(id);
        }
    }
}
