using GymT110Asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymT110Asp.ViewModels
{
    public class BlogVM
    {
        public Blog BlogSingle { get; set; }
        public List<Blog> SameBlogs { get; set; }

    }
}
