using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;

using SignalRServer.DataProviders;
using SignalRServer.Models;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer.Hubs
{
    public class LoginHub : Hub
    {
        readonly IConfiguration _configuration;
        public LoginHub(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return;

            if (StaticDatas.Users.Select(x => x.Username).Contains(userName))
                return;


            StaticDatas.Users.Add(new User() { Id = Guid.NewGuid(), Username = userName, Password = password });
            
            await Clients.Caller.SendAsync("Create", true);
        }

        public async Task Login(string userName, string password)
        {
            User user = StaticDatas.Users
                .FirstOrDefault(u => u.Username == userName && u.Password == password);

            Token token = null;

            if (user != null)
            {
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                token = tokenHandler.CreateAccessToken(10);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(10);
            }

            await Clients.Caller.SendAsync("Login", user != null ? token : null);
        }

        public async Task RefreshTokenLogin(string refreshToken)
        {
            User user = StaticDatas.Users.FirstOrDefault(x => x.RefreshToken == refreshToken);

            Token token = null;
            if (user != null && user?.RefreshTokenEndDate > DateTime.Now)
            {
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                token = tokenHandler.CreateAccessToken(10);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(10);
            }
            await Clients.Caller.SendAsync("Login", user != null ? token : null);
        }
    }
}
