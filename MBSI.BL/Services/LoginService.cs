using AutoMapper;
using MBSI.BL.IServices;
using MBSI.DAL.Interface;
using MBSI.Logger.ExceptionHelper;
using MBSI.Models.RequestModels;
using MBSI.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSI.BL.Services
{
    public class LoginService : ILoginService
    {
        #region Variables
        private readonly ILoginRepository _ILogin;
        #endregion

        #region Properties
        private IMapper Mapper
        {
            get;
        }
        #endregion

        #region Constructors
        public LoginService(ILoginRepository ILogin, IMapper mapper)
        {
            _ILogin = ILogin;
            this.Mapper = mapper;
        }
        #endregion

        #region Default CRUD Functions
        public UserResponse GetLoginUser(LoginRequest loginData)
        {
            var userResponse = new UserResponse();
            try
            {
                var loginUser = _ILogin.GetLoginUser(loginData.UserName, loginData.Password);

                //Automapping
                userResponse = Mapper.Map<UserResponse>(loginUser.Result);
            }
            catch (Exception ex)
            {
                //Using Exception ex
                ExceptionLogger.WriteLog(ex);
            }

            return userResponse;
        }
        #endregion
    }
}
