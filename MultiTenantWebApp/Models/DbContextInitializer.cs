using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MultiTenantWebApp.Models
{
    public class DbContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    FirstName = "George",
                    LastName = "Williams"
                },
                new Customer()
                {
                    FirstName = "Donald",
                    LastName = "Wilkinson"
                },
                new Customer()
                {
                    FirstName = "Bob",
                    LastName = "Daniels"
                }
            };

            context.Customers.AddRange(customers);

            context.Tenants.AddRange(new List<Tenant>
            {
                new Tenant
                {
                    Id = 1,
                    Name = "SVCC",
                    Default = true,
                    DomainName = "siliconvalley-codecamp.com",
                },
                new Tenant
                {
                    Id = 1,
                    Name = "ANGU",
                    Default = false,
                    DomainName = "angularu.com",
                }
            });

            context.Speakers.AddRange(new List<Speaker>
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

            base.Seed(context);
        }
    }
}