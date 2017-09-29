using MultiTenantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MultiTenantWebApp.Controllers
{
    public class MultiTenantMvcController : Controller
    {
        public Tenant tenant
        {
            get
            {
                object multiTenant;
                if (!Request.GetOwinContext().Environment.TryGetValue("MultiTenant",
                    out multiTenant))
                {
                    throw new ApplicationException("Could not find Tenant");
                }

                return (Tenant)multiTenant;
            }
        }
    }
}