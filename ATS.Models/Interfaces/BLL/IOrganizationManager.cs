using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;

namespace ATS.Models.Interfaces.BLL
{
    public interface IOrganizationManager: ICommonManager<Organization>
    {
        Organization IsOrganizationNameExist(string name);
    }
}
