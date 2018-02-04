using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ATS.Models.Models.UserRelatedModel
{
    public class ApplicationUser: IdentityUser
    {
        public string Designation { get; set; }
    }
}
