using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSI.Logger.LogModels
{
    public class ExceptionLogModel
    {
        #region Exception Models
        public string Exception { get; set; }

        public string IPAddress { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }

        public DateTime ExceptionTime { get; set; }
        #endregion
    }
}
