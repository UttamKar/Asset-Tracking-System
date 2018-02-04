using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Migrations;
using ATS.Models.Models.EntityModel.Partial;

namespace ATS.Models.Interfaces.BLL
{
    public interface IAssetDetailsManager: ICommonManager<assetDetails>
    {
        IEnumerable<AssetDetails> GetAllAssetDetails(int id);
    }
}
