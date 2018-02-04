using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Common;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel.Partial;
using ATS.Repository;

namespace ATS.BLL
{
    public class NoteManager: CommonManager<Note>, INoteManager
    {
        private INoteRepository _noteRepository;
        public NoteManager() : base(new NoteRepository())
        {
            _noteRepository= base._repository as INoteRepository;
        }
    }
}
