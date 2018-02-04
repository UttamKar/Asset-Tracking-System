using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.DatabaseContext;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel.Partial;
using ATS.Repository.Common;

namespace ATS.Repository
{
    public class FinanceRepository: CommonRepository<Finance>, IFinanceRepository
    {
        public ATSDBContext Context
        {
            get { return (ATSDBContext)db; }
        }
        public FinanceRepository() : base(new ATSDBContext())
        {
        }
    }
}
