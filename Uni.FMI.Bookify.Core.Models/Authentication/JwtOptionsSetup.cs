﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Uni.FMI.Bookify.Core.Models.Authentication
{
    public class JwtOptionsSetup(
        IConfiguration configuration) : IConfigureOptions<JwtOptions>
    {
        private const string SectionName = "Jwt";

        public void Configure(JwtOptions options)
        {
configuration.GetSection(SectionName).Bind(options);
        }
    }
}
