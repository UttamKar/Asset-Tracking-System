using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Common;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Migrations;
using ATS.Repository;

namespace ATS.BLL
{
    public class AttachmentManager: CommonManager<Attachment>, IAttachmentManager
    {
        private IAttachmentRepository _attachmentRepository;
        public AttachmentManager() : base(new AttachmentRepository())
        {
            _attachmentRepository=base._repository as IAttachmentRepository;
        }
    }
}
