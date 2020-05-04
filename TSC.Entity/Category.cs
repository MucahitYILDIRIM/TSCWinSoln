using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Entity
{
    public class Category
    {
        public Category(string Title, Category category)
        {
            this.Title = Title;
            this.ParentCategory = category;
        }
        public string Title { get; set; }
        public Category ParentCategory { get; set; }
    }
}
