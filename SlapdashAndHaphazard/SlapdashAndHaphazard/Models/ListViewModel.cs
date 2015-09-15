using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SlapdashAndHaphazard.Domain;

namespace SlapdashAndHaphazard.Models
{
    public class ListViewModel
    {
        public IList<Post> Posts { get; set; }
        public int TotalPosts { get; set; }
    }
}