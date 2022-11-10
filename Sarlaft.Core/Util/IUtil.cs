using System;
using System.Collections.Generic;

namespace Sarlaft.Core.Util
{
    public interface IUtil
    {
        public String GetRestfulService_Str(string url, Dictionary<String, String> headers, Dictionary<String, String> parameters);
    }
}
