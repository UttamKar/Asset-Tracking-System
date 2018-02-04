using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Common;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.SP;
using ATS.Repository;

namespace ATS.BLL
{
    public class CheckOutManager: CommonManager<CheckOut>, ICheckOutManager
    {
        private ICheckOutRepository _checkOutRepository;
        public CheckOutManager() : base(new CheckOutRepository())
        {
            _checkOutRepository=base._repository as ICheckOutRepository;
        }

        public ICollection<SP_CheckOutList> GetCheckOutListReport(string name)
        {
            return _checkOutRepository.GetCheckOutListReport(name);
        }
    }
}
