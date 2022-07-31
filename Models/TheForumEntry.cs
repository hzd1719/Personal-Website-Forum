using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForum.Models
{
    public class TheForumEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime DateAdded { get; set; }
    }
}