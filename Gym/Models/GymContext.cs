using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class GymContext : DbContext
    {
        public DbSet<GymMaster> GymMasters { get; set; }
        public DbSet<Slave> Slaves { get; set; }
    }
}