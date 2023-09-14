using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSI.Models.ResponseModels
{
    public class LoginResponse
    {
        #region View Model
        public string Code { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        #endregion
    }
}
