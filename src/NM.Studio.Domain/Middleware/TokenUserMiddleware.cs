using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NM.Studio.Domain.Contracts.Repositories.Users;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Domain.CQRS.Queries.Users;
using NM.Studio.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace NM.Studio.Domain.Middleware
{
    public class TokenUserMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public TokenUserMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
        {
            _next = next;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (!string.IsNullOrEmpty(token) && token != "null")
                {
                    var (email, username) = GetUserEmailWithUsernameFromToken(token);
                    if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(username))
                    {
                        using (var scope = _serviceScopeFactory.CreateScope())
                        {
                            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                            var userRepository = unitOfWork.UserRepository;
                            var user = await userRepository.FindUsernameOrEmail(new AuthQuery { Email = email, Username = username });

                            context.Items["User"] = user;
                        }
                    }
                }
            }
            await _next(context);
        }

        private (string, string) GetUserEmailWithUsernameFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var emailClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "email");
            var usernameClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "sub");
            return (emailClaim?.Value, usernameClaim?.Value);
        }
    }
}
