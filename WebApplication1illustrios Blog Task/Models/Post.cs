using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1illustrios_Blog_Task.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string PostName { get; set; }
        public bool Like { get; set; }
        [ForeignKey("Blog")]
        public int BlogId { get; set; }
        public virtual  Blog Blog { get; set; }

        public ApplicationUser ApplicationUser { get; set; }


    }
}