using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asymmetric.Models
{
    public class JwtSettings
    {
        public string HmacSecretKey { get; set; }
        public int ExpiryDays { get; set; }
        public string Issuer { get; set; }
        public bool UseRsa { get; set; }
        public string RsaPrivateKeyXML { get; set; }
        public string RsaPublicKeyXML { get; set; }
    }
    public class JWT
    {
        public string Token { get; set; }
        public long Expires { get; set; }
    }
    public class SignIn
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
