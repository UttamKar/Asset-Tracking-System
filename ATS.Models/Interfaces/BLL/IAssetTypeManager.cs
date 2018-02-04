using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.AssetType;

namespace ATS.Models.Interfaces.BLL
{
    public interface IAssetTypeManager: ICommonManager<AssetType>
    {
        List<AssetType> Search(AssetTypeSearchVm model);
        bool IsAssetTypeNameExist(string input);
    }
}
