using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarlaft.Domain.Dto
{
    public class LaftSearchDTO
    {        
        public String ListName { get; set; }
             
        public bool? InRisk { get; set; }
             
        public LaftQueryDetailDTO QueryDetail { get; set; }

    }
}
