using Sarlaft.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarlaft.Core
{
    public interface IConsultarSarlaft
    {
        public List<LaftDTO> QueryLAFT(Dictionary<String, String> qparams);
    }
}
