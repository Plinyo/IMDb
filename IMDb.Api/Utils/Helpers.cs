using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace IMDb.Utils
{
    public class Helpers
    {
        public static string ParseToken(string jwtInput)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            jwtInput = jwtInput.Split(" ")[1];

            var readableToken = jwtHandler.CanReadToken(jwtInput);
            string username = string.Empty;
            if (readableToken)
            {
                var token = jwtHandler.ReadJwtToken(jwtInput);
                var claims = token.Claims;
                username = claims.Where(claim => claim.Type == "unique_name").FirstOrDefault().Value;

            }
            return username;
        }
    }
}