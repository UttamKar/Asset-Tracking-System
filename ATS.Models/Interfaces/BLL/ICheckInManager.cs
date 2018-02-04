using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.CheckIn;

namespace ATS.Models.Interfaces.BLL
{
    public interface ICheckInManager: ICommonManager<CheckIn>
    {
        List<CheckInCreateVm> SearchAssetForCheckIn(int id);
        List<CheckInCreateVm> GetAssetById(int id);
    }
}
