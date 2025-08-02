using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Infrastructure.Tokens
{
    public class TokenSettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SecretKey { get; set; }
        public int AccessTokenExpirationMinutes { get; set; }
    }
}
