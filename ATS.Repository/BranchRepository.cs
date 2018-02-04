using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ATS.Models.DatabaseContext;
using ATS.Models.Interfaces;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Repository.Common;

namespace ATS.Repository
{
    public class BranchRepository: CommonRepository<Branch>, IBranchRepository
    {
        public ATSDBContext Context
        {
            get { return (ATSDBContext) db; }
        }

        public BranchRepository() : base(new ATSDBContext())
        {
        }

    }
}
