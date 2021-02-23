﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Infra.Helpers.JwtHelpers.Interfaces;

namespace TicTacBackend.Infra.Helpers.JwtHelpers
{
    public class JwtHelper : IJwtHelper
    {
        private readonly IConfiguration configuration;

        public JwtHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public JwtSecurityToken GerarTokenAcesso(string nomeCompleto, string cpf, dynamic roles)
        {
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var claims = new[]
			{
			new Claim(JwtRegisteredClaimNames.Sub, cpf.ToString()),
			new Claim("nomeCompleto", nomeCompleto),
			new Claim("roles", "Pizza"),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
		};
			return new JwtSecurityToken(
				issuer: configuration["Jwt:Issuer"],
				audience: configuration["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddDays(1),
				signingCredentials: credentials
			);
		}
    }
}
