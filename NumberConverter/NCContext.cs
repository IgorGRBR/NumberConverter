using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using NumberConverter.Models;

namespace NumberConverter
{
    public class NCContext : DbContext
    {
        public NCContext() : base("name=MyDbCS")
        {

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Conversion> Conversions { get; set; }
    }
}