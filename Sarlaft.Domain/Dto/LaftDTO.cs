using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarlaft.Domain.Dto
{
    public class LaftDTO
    {
        public LaftDTO()
        {
            SearchList = new List<LaftSearchDTO>();
        }

        public String GroupNameList { get; set; }

        public List<LaftSearchDTO> SearchList { get; set; }

        public String Name { get; set; }

        public String UrlPath { get; set; }

    }
}
