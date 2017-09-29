using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenantWebApp.Code;

namespace MultiTenantWebApp.Controllers
{
    public class TokenController : MultiTenantMvcController
    {
        [HttpPost]
        public ActionResult TestTokenFull(string tokenValue)
        {
            string plainToken;
            string tenantName;
            var username =
                JwtManager.GetPrincipalAndTenantName
                (tokenValue,
                    out plainToken,
                    out tenantName).Identity.Name;


            var modelData = new ModelData
            {
                Username = username,
                TenantName = tenantName,
                PlainToken = plainToken

            };
            return View("ShowUserFull", modelData);
        }


        [HttpPost]
        public ActionResult TestToken(string tokenValue)
        {
            string plainToken;
            var username = JwtManager.
                GetPrincipal(tokenValue, out plainToken).
                Identity.Name;

            var modelData = new ModelData
            {
                Username = username,
                PlainToken = plainToken

            };
            return View("ShowUser", modelData);

        }


 

        public ActionResult TestToken()
        {
            var modelData = new ModelData
            {
                TokenValue = ""
            };
            return View(modelData);
        }

        public ActionResult TestTokenFull()
        {
            var modelData = new ModelData
            {
                TokenValue = ""
            };
            return View(modelData);
        }


        // GET: Token
        public ActionResult GetToken(string username,
            string tenantName)
        {
            string plainToken;
            var tokenValue =
                JwtManager.GenerateToken(username,
                tenantName,out plainToken);

            var modelData = new ModelData
            {
                PlainToken = plainToken,
                TokenValue = tokenValue
            };
            return View(modelData);
        }

        public class ModelData
        {
            public string TokenValue { get; set; }
            public string PlainToken { get; set; }
            public string Username { get; set; }
            public string TenantName { get; set; }
        }

    }
}