using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgeting.Config
{
    public class Config
    {
        #region Singleton

        private static Config _instance;
        public static Config Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Config();
                }
                return _instance;
            }
        }

        #endregion

        #region Constants

        public const string ApiUrl = "http://localhost";

        #endregion

        #region Attributes

        private string _accessToken;

        #endregion

        #region Properties

        public string AccessToken
        {
            get
            {
                return _accessToken;
            }
            set
            {
                _accessToken = value;
                Configuration.AccessToken = value;
            }
        }

        public string RefreshToken { get; set; }

        public Configuration Configuration { get; set; }

        #endregion

        #region Constructor

        public Config()
        {
            Configuration = new Configuration();
            Configuration.BasePath = ApiUrl;
        }

        #endregion
    }
}
