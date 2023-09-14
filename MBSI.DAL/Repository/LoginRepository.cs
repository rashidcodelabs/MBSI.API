using MBSI.DAL.Interface;
using MBSI.Logger.ExceptionHelper;
using MBSI.Models.DataModels;
using MBSI.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSI.DAL.Repository
{
    public class LoginRepository : ILoginRepository
    {
        #region Variables
        readonly DatabaseContext _dbContext = new();
        #endregion

        #region Constructors
        public LoginRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Default CRUD Functions
        public async Task<UserInfoModel?> GetLoginUser(string Username, string Password)
        {
            UserInfoModel? user = null;
            try
            {
                user = await _dbContext.UserInfos.Where(x => x.UserName == Username && x.Password == Password).FirstOrDefaultAsync();
                if (user != null)
                {
                    return user;
                }
                else
                {
                    //Using message
                    string message = $"Invalid login attempt.";
                    ExceptionLogger.WriteLog(message);
                }
            }
            catch (Exception ex)
            {
                //Using Exception ex
                ExceptionLogger.WriteLog(ex);
            }

            return user;
        }
        #endregion
    }
}
