using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Common;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel.Partial;
using ATS.Repository;

namespace ATS.BLL
{
    public class FinanceManager:CommonManager<Finance>, IFinanceManager
    {
        private IFinanceRepository _financeRepository;
        public FinanceManager() : base(new FinanceRepository())
        {
            _financeRepository = base._repository as IFinanceRepository;
        }
    }
}
