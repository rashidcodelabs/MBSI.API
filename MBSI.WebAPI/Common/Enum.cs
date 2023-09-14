using System.ComponentModel;

namespace MBSI.WebAPI.Common
{
    #region Project Specific
    public enum ResponseType
    {
        [Description("OK")]
        OK = 200,

        [Description("An unexpected error has occurred.")]
        Error = 400
    }
    #endregion
}
