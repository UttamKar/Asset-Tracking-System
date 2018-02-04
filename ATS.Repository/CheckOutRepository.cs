using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.DatabaseContext;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.SP;
using ATS.Repository.Common;

namespace ATS.Repository
{
    public class CheckOutRepository: CommonRepository<CheckOut>, ICheckOutRepository
    {
        public ATSDBContext Context
        {
            get { return (ATSDBContext)db; }
        }
        public CheckOutRepository() : base(new ATSDBContext())
        {
        }

        public ICollection<SP_CheckOutList> GetCheckOutListReport(string name)
        {
            return Context.GetCheckOutListReport(name);
        }

    }
}
