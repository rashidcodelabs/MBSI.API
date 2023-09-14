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
	public class VehicleInspectionRegisterService : IVehicleInspectionRegisterService
	{
		#region Variables
		private readonly IVehicleInspectionRegisterRepository _IVehicleInspectionRegister;
		#endregion

		#region Properties
		private IMapper Mapper
		{
			get;
		}
		#endregion

		#region Constructors
		public VehicleInspectionRegisterService(IVehicleInspectionRegisterRepository IVehicleInspectionRegister, IMapper mapper)
		{
			_IVehicleInspectionRegister = IVehicleInspectionRegister;
			this.Mapper = mapper;
		}
		#endregion

		#region Default CRUD Functions
		#endregion
	}
}
