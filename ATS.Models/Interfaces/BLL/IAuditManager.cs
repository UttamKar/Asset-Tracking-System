using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.Audit;

namespace ATS.Models.Interfaces.BLL
{
    public interface IAuditManager: ICommonManager<Audit>
    {
        List<AuditCreateVm> SearchAssetByLocationId(int id);
    }
}
