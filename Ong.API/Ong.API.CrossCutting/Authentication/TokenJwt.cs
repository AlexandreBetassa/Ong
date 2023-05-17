using System;

namespace Ong.API.CrossCutting.Authentication
{
    public static class TokenJwt 
    {
        public static string Issuer { get; set; }
        public static string Audience { get; set; }
        public static string Key { get; set; }
    }
}
