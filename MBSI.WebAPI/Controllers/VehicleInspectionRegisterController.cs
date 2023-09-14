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
	[Route("api/vehicleInspectionRegister")]
	[ApiController]
	public class VehicleInspectionRegisterController : ControllerBase
	{
		#region Variables
		private readonly IVehicleInspectionRegisterService _IVehicleInspectionRegister;
		public IConfiguration _configuration;
		#endregion

		#region Constructors
		public VehicleInspectionRegisterController(IVehicleInspectionRegisterService IVehicleInspectionRegister, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
		{
			_IVehicleInspectionRegister = IVehicleInspectionRegister;
			_configuration = configuration;
			HttpContextHelper.Configure(httpContextAccessor);
		}
		#endregion

		#region Default CRUD Actions
		//// GET api/User/
		////User Detail
		//[HttpGet("{id}")]
		//public async Task<ActionResult<ResponseViewModel>> Get(string id)
		//{
		//	var response = new ResponseViewModel();
		//	try
		//	{
		//		var user = await Task.FromResult(_IUser.GetUserDetails(id));

		//		response.Code = Convert.ToString((int)ResponseType.OK);
		//		response.Message = ResponseType.OK.GetDescription<ResponseType>();
		//		response.Data = user;
		//		return Ok(response);
		//	}
		//	catch (Exception)
		//	{
		//		response.Code = Convert.ToString((int)ResponseType.Error);
		//		response.Message = ResponseType.Error.GetDescription<ResponseType>();
		//		return NotFound(response);
		//	}
		//}

		#endregion

		#region Private Functions
		#endregion
	}
}
