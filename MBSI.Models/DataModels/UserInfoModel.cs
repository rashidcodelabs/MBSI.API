using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSI.Models.DataModels
{
    public class UserInfoModel
    {
        #region Constructors
        public UserInfoModel()
        {

        }
        #endregion

        #region Data Models
        [Key]
        public int UserId { get; set; }
        public string? DisplayName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        #endregion

        #region View Models

        #endregion
    }
}
