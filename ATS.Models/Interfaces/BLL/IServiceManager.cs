using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models.EntityModel.Partial;
using ATS.Models.Models.ViewModel.PartialView;

namespace ATS.Models.Interfaces.BLL
{
    public interface IServiceManager: ICommonManager<Service>
    {
       List<Service> GetServiceDetails(int id);
    }
}
