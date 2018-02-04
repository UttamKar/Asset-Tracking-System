using ATS.Models.Models;
using ATS.Models.Models.EntityModel;

namespace ATS.Models.Interfaces.Repository
{
    public interface IOrganizationRepository: ICommonRepository<Organization>
    {
        Organization IsOrganizationNameExist(string name);
    }
}
