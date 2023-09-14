﻿using MBSI.Models.DataModels;
using MBSI.Models.RequestModels;
using MBSI.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSI.BL.IServices
{
    public interface ILoginService
    {
        #region Default CRUD Functions
        public UserResponse GetLoginUser(LoginRequest loginData);
        #endregion
    }
}
