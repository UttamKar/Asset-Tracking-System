using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.AssetGroup;

namespace ATS.Models.Interfaces.BLL
{
    public interface IAssetGroupManager: ICommonManager<AssetGroup>
    {
        List<AssetGroup> Search(AssetGroupSearchVm model);
        bool IsAssetGroupNameExist(string input);
    }
}
