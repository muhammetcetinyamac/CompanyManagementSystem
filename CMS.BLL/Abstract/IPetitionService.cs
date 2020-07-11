using CMS.MODEL.Entities;
using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BLL.Abstract
{
   
    public interface IPetitionService : IBaseService<Petition>
    {
        ICollection<Petition> pendingPetition(TransactionStatus confirmation);
    }
}
