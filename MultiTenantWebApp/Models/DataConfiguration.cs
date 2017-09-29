using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MultiTenantWebApp.Models
{
    public class DataConfiguration : DbConfiguration
    {
        public DataConfiguration()
        {
            SetDatabaseInitializer(new DbContextInitializer());
        }
    }
}