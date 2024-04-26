using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PruebaTecnicaOnOff.Api.Auth
{
	public class ApiKeyMiddleware
	{
		private readonly RequestDelegate _next;
		private const string ApiKeyName = "ApiKey";
		private readonly string _apiKeyValue;

		public ApiKeyMiddleware(IConfiguration configuration, RequestDelegate next)
		{
			_apiKeyValue = configuration.GetConnectionString("apiKeyValue");
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			if (!context.Request.Headers.TryGetValue(ApiKeyName, out var apiKey) || !string.Equals(_apiKeyValue, apiKey, StringComparison.OrdinalIgnoreCase))

			{
				context.Response.StatusCode = 401;
				await context.Response.WriteAsync("Invalid API key.");
				return;
			}
			await _next(context);
		}
	}
}
