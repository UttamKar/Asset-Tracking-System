using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel;
using ATS.Models.Models.ViewModel.SP;

namespace ATS.Models.Interfaces.BLL
{
    public interface IAssetEntryManager: ICommonManager<AssetEntry>
    {
        ICollection<Branch> GetBranches(int id);
        ICollection<Location> GetLocations(int id);
        ICollection<AssetGroup> GetAssetGroups(int id);
        ICollection<Manufacturer> GetManufacturers(int id);
        ICollection<AssetModel> GetAssetModels(int id);
        ICollection<SP_AssetList> GetAssetListReport(string name);
    }
}
