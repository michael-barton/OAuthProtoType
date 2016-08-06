using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace OAuthAttempt.ResourceServer.Controllers
{
    [Authorize]
    public class MeController : ApiController
    {
        [Route("api/me/name")]
        public NameResult GetName()
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            return new NameResult
            {
                Name = identity.Name,
                Claims = identity.Claims?.Select(claim => new ClaimModel { Type = claim.Type, Value = claim.Value }).ToList()
            };
        }

        public class NameResult
        {
            public string Name { get; set; }
            public List<ClaimModel> Claims { get; set; }
        }

        public class ClaimModel
        {
            public string Type { get; set; }
            public string Value { get; set; }
        }
    }
}
