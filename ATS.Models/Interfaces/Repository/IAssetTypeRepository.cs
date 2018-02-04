using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.AssetType;

namespace ATS.Models.Interfaces.Repository
{
    public interface IAssetTypeRepository: ICommonRepository<AssetType>
    {
        List<AssetType> Search(AssetTypeSearchVm model);
        AssetType IsAssetTypeNameExist(string input);
    }
}
