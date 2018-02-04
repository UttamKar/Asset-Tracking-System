using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.Audit;

namespace ATS.Models.Interfaces.Repository
{
    public interface IAuditRepository: ICommonRepository<Audit>
    {
        List<AuditCreateVm> SearchAssetByLocationId(int id);
    }
}
