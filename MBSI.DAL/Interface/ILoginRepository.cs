using MBSI.Models.DataModels;
using MBSI.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSI.DAL.Interface
{
    public interface ILoginRepository
    {
        #region Default CRUD Functions
        public Task<UserInfoModel?> GetLoginUser(string Username, string Password);
        #endregion
    }
}
