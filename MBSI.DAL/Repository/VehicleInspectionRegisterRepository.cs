using MBSI.Logger.ExceptionHelper;
using MBSI.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSI.DAL.Repository
{
	public class VehicleInspectionRegisterRepository
	{
		#region Variables
		readonly DatabaseContext _dbContext = new();
		#endregion

		#region Constructors
		public VehicleInspectionRegisterRepository(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}
		#endregion

		#region Default CRUD Functions
		#endregion
	}
}
