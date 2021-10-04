using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LR4.Models
{
    public class phoneContext: DbContext
    {
        public phoneContext() : base("name=PhoneContext")
        { }
        public DbSet<Spravochnik> sp { get; set; }
    }
}