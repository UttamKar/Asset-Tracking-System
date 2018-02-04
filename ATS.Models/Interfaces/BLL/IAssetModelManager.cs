using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.AssetModel;

namespace ATS.Models.Interfaces.BLL
{
    public interface IAssetModelManager: ICommonManager<AssetModel>
    {
        ICollection<Manufacturer> GetManufacturers(int id);
        List<AssetModel> Search(AssetModelSearchVm model);
    }
}
