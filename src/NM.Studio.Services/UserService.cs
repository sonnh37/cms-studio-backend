using AutoMapper;
using NM.Studio.Domain.Contracts.Repositories.Users;
using NM.Studio.Domain.Contracts.Services.Users;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Domain.CQRS.Commands.Users;
using NM.Studio.Domain.CQRS.Queries.Users;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Utilities;
using NM.Studio.Services.Bases;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NM.Studio.Services
{
    using BCrypt.Net;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using NM.Studio.Domain.Entities;
    using NM.Studio.Domain.Models;
    using NM.Studio.Domain.Results;

    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private DateTime countDown = DateTime.Now.AddMinutes(30);

        public UserService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IConfiguration configuration)
            : base(mapper, unitOfWork)
        {
            _userRepository = unitOfWork.UserRepository;
            _configuration = configuration;
        }

        public async Task<MessageLoginResult<UserResult>> Login(AuthQuery x, CancellationToken cancellationToken = default)
        {
            // Check username or email
            var user = await _userRepository.FindUsernameOrEmail(x);
            var userResult = new UserResult();

            if (user == null)
            {
                return AppMessage.GetMessageLoginResult(userResult, null, null);
            }

            // Check password
            var isPasswordValid = BCrypt.Verify(x.Password, user.Password);
            if (!isPasswordValid)
            {
                return AppMessage.GetMessageLoginResult(userResult, null, null);
            }

            userResult = _mapper.Map<User, UserResult>(user);
            var token = CreateToken(user);
            var msgResult = AppMessage.GetMessageLoginResult(userResult,
                new JwtSecurityTokenHandler().WriteToken(token),
                token.ValidTo.ToString());

            return msgResult;
        }

        public async Task<MessageView<UserView>> Register(UserCreateCommand x, CancellationToken cancellationToken = default)
        {
            x.Password = BCrypt.HashPassword(x.Password);
            return await CreateOrUpdate(x);
        }

        private JwtSecurityToken CreateToken(User user)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
        };

            if (!string.IsNullOrEmpty(user.Email))
            {
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("Appsettings:Token").Value));

            var creeds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: creeds,
                expires: countDown
            );

            return token;
        }
    }

}
