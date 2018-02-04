using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Models.EntityModel
{
    public class Common
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Short Name")]
        public string ShortName { get; set; }
    }
}
