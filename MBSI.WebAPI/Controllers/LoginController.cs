using MBSI.BL.IServices;
using MBSI.Logger.Helpers;
using MBSI.Models.RequestModels;
using MBSI.Models.ResponseModels;
using MBSI.WebAPI.Common;
using MBSI.WebAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MBSI.WebAPI.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Variables
        private readonly ILoginService _ILogin;
        public IConfiguration _configuration;
        #endregion

        #region Constructors
        public LoginController(ILoginService ILogin, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _ILogin = ILogin;
            _configuration = configuration;
            HttpContextHelper.Configure(httpContextAccessor);
        }
        #endregion

        #region Default CRUD Actions
        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest _loginData)
        {
            LoginResponse login = new LoginResponse();
            try
            {
                //var headerKeyValue = Request.Headers.Where(t => t.Key == "Key").ToList();  //For List

                var appSettingKey = _configuration.GetValue<string>("ApiSecKey");
                var isSecurity = _configuration.GetValue<bool>("IsSecurity");
                if (isSecurity)
                {
                    const string headerKeyName = "Key";
                    Request.Headers.TryGetValue(headerKeyName, out StringValues headerKey);

                    if (!string.IsNullOrWhiteSpace(headerKey))
                    {
                        if (headerKey == appSettingKey)
                        {
                            login = GetUserLogin(_loginData).Result;
                        }
                        else
                        {
                            login.Code = Convert.ToString((int)ResponseType.Error);
                            login.Message = "Unauthorized client.";
                            return NotFound(login);
                        }
                    }
                    else
                    {
                        login.Code = Convert.ToString((int)ResponseType.Error);
                        login.Message = "Api Key was not provided.";
                        return NotFound(login);
                    }
                }
                else
                {
                    login = GetUserLogin(_loginData).Result;
                }

                if (!string.IsNullOrWhiteSpace(login.Token))
                {
                    return Ok(login);
                }
                else
                {
                    return NotFound(login);
                }
            }
            catch (Exception ex)
            {
                login.Code = Convert.ToString((int)ResponseType.Error);
                login.Message = ResponseType.Error.GetDescription<ResponseType>();
                login.Token = null;
                return NotFound(login);
            }
        }
        #endregion

        #region Private Functions
        private async Task<LoginResponse> GetUserLogin(LoginRequest loginData)
        {
            var login = new LoginResponse();
            var userResponse = await Task.FromResult(_ILogin.GetLoginUser(loginData));

            if (userResponse != null)
            {
                var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt_MBSI:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim("UserId", userResponse.Id.ToString()),
                            new Claim("DisplayName", userResponse.UserName),
                            new Claim("UserName", userResponse.UserName),
                            new Claim("Email", userResponse.Email)
                        };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt_MBSI:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt_MBSI:Issuer"],
                    audience: _configuration["Jwt_MBSI:Audience"],
                    expires: DateTime.UtcNow.AddHours(24),
                    claims: claims,
                    signingCredentials: signIn);

                login.Token = new JwtSecurityTokenHandler().WriteToken(token);
                login.Code = Convert.ToString((int)ResponseType.OK);
                login.Message = ResponseType.OK.GetDescription<ResponseType>();

                return login;
            }
            else
            {
                login.Code = Convert.ToString((int)ResponseType.Error);
                login.Message = "Invalid user name or password.";
                return login;
            }
        }
        #endregion
    }
}
