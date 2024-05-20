using System.IdentityModel.Tokens.Jwt;

namespace Budgeting.Helpers
{
    public class JwtHelper
    {
        public static DateTime? GetExpirationDate(string accessToken)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(accessToken) as JwtSecurityToken;

                if (jsonToken != null && jsonToken.Payload.TryGetValue("exp", out object exp))
                {
                    if (exp is long expUnix)
                    {
                        var expDateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(expUnix);
                        return expDateTimeOffset.UtcDateTime;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting expiration date: {ex.Message}");
                return null;
            }
        }
    }
}
