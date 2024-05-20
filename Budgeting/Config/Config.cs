using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

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

        public const string ApiUrl = "http://192.168.0.15";

        #endregion

        #region Attributes

        private string _accessToken;
        private string _refreshToken;

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

        public string RefreshToken
        {
            get
            {
                return _refreshToken;
            }
            set
            {
                _refreshToken = value;
                // Add refresh-token to cookies
            }
        }

        public UserRead CurrentUser { get; set; }

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
