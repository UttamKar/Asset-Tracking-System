using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.SP;

namespace ATS.Models.Interfaces.BLL
{
    public interface ICheckOutManager: ICommonManager<CheckOut>
    {
        ICollection<SP_CheckOutList> GetCheckOutListReport(string name);
    }
}
