using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1illustrios_Blog_Task.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        public string BlogName { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}