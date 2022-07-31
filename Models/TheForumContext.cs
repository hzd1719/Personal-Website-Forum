using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TheForum.Models
{
    public class TheForumContext : DbContext
    {
        public TheForumContext()
            : base("TheForum")
        {
        }
        public DbSet<TheForumEntry> Entries { get; set; }
    }
}
