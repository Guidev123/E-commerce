﻿using System.Net.Http.Headers;
using YourSneaker.WebAPI.Core.User;
using YourSneaker.WebApp.MVC.Extensions;

namespace YourSneaker.WebApp.MVC.Service.handlers
{
    public class HttpClientAuthDelegatingHandler : DelegatingHandler
    {
        private readonly IAspNetUser _user;

        public HttpClientAuthDelegatingHandler(IAspNetUser user)
        {
            _user = user;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) 
        {
            var authorizationHeader = _user.ObterHttpContext().Request.Headers["Authorization"];

            if(!string.IsNullOrEmpty(authorizationHeader) )
            {
                request.Headers.Add("Authorization", new List<string>() { authorizationHeader });
            }

            var token = _user.ObterUserToken();

            if(token != null ) request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);


            return base.SendAsync(request, cancellationToken);
        }
    }
}
