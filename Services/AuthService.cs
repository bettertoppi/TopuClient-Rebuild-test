using System;
using System.Threading.Tasks;
using CmlLib.Core.Auth;
using CmlLib.Core.Auth.Microsoft;
using TopuClient.Models;

namespace TopuClient.Services
{
    public class AuthService
    {
        public async Task<Account> LoginMicrosoftAsync()
        {
            var loginHandler = JLoginHandler.BuildDefault();
            var session = await loginHandler.AuthenticateInteractively();

            return new Account
            {
                Username = session.Username,
                Uuid = session.UUID,
                AccessToken = session.AccessToken,
                IsMicrosoft = true
            };
        }

        public Account LoginOffline(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                username = "TopuUser";

            var session = MSession.GetOfflineSession(username);
            return new Account
            {
                Username = session.Username,
                Uuid = session.UUID,
                AccessToken = session.AccessToken,
                IsMicrosoft = false
            };
        }
    }
}
