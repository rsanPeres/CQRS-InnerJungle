using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerJungle.Infra.Authentication
{
    public class JwtSettings
    {
        public string? Secret { get; init; }
        public string? Issuer { get; init; }
        public string? Audience { get; init;}
        public int ExpirationTimeInMinutes { get; init; }
    }
}
