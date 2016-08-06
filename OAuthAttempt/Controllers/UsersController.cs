using OAuthAttempt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace OAuthAttempt.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        [Route("api/users/me")]
        public IEnumerable<ClaimModel> GetMe()
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            return identity.Claims.Select(claim => new ClaimModel { Type = claim.Type, Value = claim.Value }).ToList();
        }
    }
}
