using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSI.Models.RequestModels
{
    public class LoginRequest
    {
        #region Constructors
        public LoginRequest()
        {

        }
        #endregion

        #region Data Models
        public string UserName { get; set; }
        //public string? Email { get; set; }
        public string Password { get; set; }
        #endregion

        #region View Models

        #endregion
    }
}
