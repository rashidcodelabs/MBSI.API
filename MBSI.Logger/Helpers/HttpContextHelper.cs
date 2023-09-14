using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MBSI.Logger.Helpers
{
    public class HttpContextHelper
    {
        #region Variables
        private static IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Configurations
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static HttpContext Current => _httpContextAccessor.HttpContext;
        #endregion
    }
}
