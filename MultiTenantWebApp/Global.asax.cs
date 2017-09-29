using MultiTenantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MultiTenantWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            using (var db = new ApplicationDbContext()) //Seed Database with basic data
            {
                if (!db.Tenants.Any())
                {
                    db.Tenants.AddRange(new List<Tenant>()
                    {
                        new Tenant()
                        {
                            Id = 1,
                            Name = "SVCC",
                            Default = true,
                            DomainName = "siliconvalley-codecamp.com",
                        },
                        new Tenant()
                        {
                            Id = 2,
                            Name = "ANGU",
                            Default = false,
                            DomainName = "angularu.com",
                        },
                    });
                    db.SaveChanges();
                }

                if (!db.Speakers.Any())
                {
                    db.Speakers.AddRange(new List<Speaker>()
                    {
                        new Speaker
                        {
                            Id = 1,
                            FirstName = "Chris",
                            LastName = "Love",
                            TenantId = 1
                        },
                        new Speaker
                        {
                            Id = 2,
                            FirstName = "Daniel",
                            LastName = "Egan",
                            TenantId = 1
                        },
                        new Speaker
                        {
                            Id = 3,
                            FirstName = "Igor",
                            LastName = "Minar",
                            TenantId = 2
                        },
                        new Speaker
                        {
                            Id = 4,
                            FirstName = "Brad",
                            LastName = "Green",
                            TenantId = 2
                        },
                        new Speaker
                        {
                            Id = 5,
                            FirstName = "Misko",
                            LastName = "Hevery",
                            TenantId = 2
                        }

                    });
                    db.SaveChanges();
                }
            }
        }
    }
}
