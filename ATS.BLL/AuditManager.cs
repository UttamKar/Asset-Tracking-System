using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Common;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.Audit;
using ATS.Repository;

namespace ATS.BLL
{
    public class AuditManager: CommonManager<Audit>, IAuditManager
    {
        private readonly IAuditRepository _auditRepository;
        public AuditManager() : base(new AuditRepository())
        {
            _auditRepository=base._repository as IAuditRepository;
        }

        public List<AuditCreateVm> SearchAssetByLocationId(int id)
        {
            return _auditRepository.SearchAssetByLocationId(id);
        }
    }
}
